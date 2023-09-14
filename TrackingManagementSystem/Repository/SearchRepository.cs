using Microsoft.AspNetCore.Identity;
using TrackingManagementSystem.Data;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Models.ViewModel;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public SearchRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public  Task<ApplicationUser> SearchUser(string username)
        {
            ApplicationUser user=new ApplicationUser();
            if(username == null) throw new ArgumentNullException("username");
            user = _context.Users.FirstOrDefault(user=>user.UserName== username);
            if (user == null) throw new ArgumentNullException();
            return Task.FromResult<ApplicationUser>(user);
        }

        public ICollection<InviteUsers> SearchUsername(string username)
        {
            var usersInDb = _userManager.Users.ToList();
            return usersInDb.Where(u => u.UserName.Contains(username)).Select(m => new InviteUsers() { Id = m.Id, Username = m.UserName }).ToList();

        }

        public ICollection<InvitedUser> ShowSpecificInvitation(string senderId)
        {
            if (senderId == null) return null;
            var user= _context.invitedUsers.Where(sendId=>sendId.InvitationSenderUserId==senderId).ToList();
            if (user == null) return null;
            return user;
        }

      
    }
}
