using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingManagementSystem.Models
{
    public class ApplicationUser: IdentityUser
    {
        public UserStatusTillNow UserStatus { get; set; }
        [NotMapped]
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenValidDate { get; set; }
        [NotMapped]
        public string? Role { get; set; }
    }
    public enum UserStatusTillNow
    {
        Active=1,Inactive=2,Removed=3
    }
}
