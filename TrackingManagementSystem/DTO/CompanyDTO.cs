using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.DTO
{
    public class CompanyDTO
    {
        public CompanyDTO()
        {
            TrackingDetails = new List<TrackingOutput>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int EmployeeCount { get; set; }
        public bool IsChange { get; set; }

        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public IList<TrackingOutput> TrackingDetails { get; set; }
    }
}
