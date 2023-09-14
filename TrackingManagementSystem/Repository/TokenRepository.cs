using System.IdentityModel.Tokens.Jwt;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Repository
{
    public class TokenRepository : ITokenRepository
    {
        public string? GetUserIdFromToken(string userToken)
        {
            //if (userToken == "Bearer ") return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var data = tokenHandler.ReadJwtToken(userToken);
            var userName = data.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value;
            return userName;
        }
    }
} 