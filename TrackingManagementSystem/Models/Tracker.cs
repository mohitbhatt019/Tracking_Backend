using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingManagementSystem.Models
{
    public class Tracker
    {
        [Key]
        public string? TrackingId { get; set; }=Guid.NewGuid().ToString();
        public DateTime TrackingDate { get; set; }=DateTime.Now;

        public string? UserId { get; set; } = string.Empty;
        public string? UserIdName { get; set; } = string.Empty;


        public string? DataChangeUserId { get; set; } = string.Empty;
        public string? DataChangeUserIdName { get; set; } = string.Empty;


        public int CompanyId { get; set; } // Foreign key property

        
        public TrackingAction TrackingAction { get; set; }
        // public bool IsDeleted { get; set; } = false;

    }


}
