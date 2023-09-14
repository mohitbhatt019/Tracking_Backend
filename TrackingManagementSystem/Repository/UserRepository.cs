using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrackingManagementSystem.Data;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository.IRepository;


namespace TrackingManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly AppSettings _appSettings;

        public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<ApplicationUser> Authenticate(LoginModel loginModel)
        {
            LoginModel loginModel1 = loginModel;
            if (loginModel is null) return null;
            var applicationUser = _context.Users.FirstOrDefault(a => a.UserName == loginModel.Username);

            var user = _context.Users.FirstOrDefault(u => u.UserName == loginModel.Username);
            if (user == null) return null; // user not found

            // hash the input password using the same algorithm used to generate the stored password hash
            var passwordHasher = new PasswordHasher<LoginModel>();
            var result = passwordHasher.VerifyHashedPassword(loginModel, user.PasswordHash, loginModel.Password);
            if (result != PasswordVerificationResult.Success) return null; // password matched

            // Jwt
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name,applicationUser.Id),
            new Claim(ClaimTypes.Email,applicationUser.Email),

                }),
                Expires = DateTime.UtcNow.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            applicationUser.Token = tokenHandler.WriteToken(token);
            ApplicationUser applicationUser2 = new ApplicationUser()
            {
                UserName=applicationUser.UserName,
                Id = applicationUser.Id,
                Token=applicationUser.Token,
                Email=applicationUser.Email, 
            };
            return applicationUser2;
        }


        public ICollection<ApplicationUser> GetUsers()
        {
            var userList=_context.Users.ToList();
            return userList;
        }

        public bool IsUniqueUser(string username)
        {
            if (username != null)
            {
                var chkUserInDb = _context.Users.FirstOrDefault(user => user.UserName == username);
                if (chkUserInDb != null) return true;
            }
            return false;
        }

        public bool LockUnlockUser(string id)
        {
            bool isLocked = false;
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userInDb == null)
                return false;
            if (userInDb != null && userInDb.LockoutEnd > DateTime.Now)
            {
                userInDb.LockoutEnd = DateTime.Now;
                isLocked = false;
            }
            else
            {
                userInDb.LockoutEnd = DateTime.Now.AddYears(100);
                isLocked = true;
            }
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> RegisterUser(RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
                PasswordHash = registerModel.Password,
            };
            if (registerModel != null)
            {
                var register = await _userManager.CreateAsync(user, registerModel.Password);
                if (!register.Succeeded)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

       
    }
}
