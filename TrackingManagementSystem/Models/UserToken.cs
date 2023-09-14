using System.ComponentModel.DataAnnotations;

namespace TrackingManagementSystem.Models
{
    public class UserToken
    {
        [Required]
        public string Token { get; set; }
    
    }
}
