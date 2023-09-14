namespace TrackingManagementSystem.Models.ViewModel
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            TrackingDetails = new List<TrackingOutput>();
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int EmployeeCount { get; set; } = 0;
        public string? UserId { get; set; } = string.Empty;
        public ApplicationUser? ApplicationUser { get; set; }
        public IList<TrackingOutput> TrackingDetails { get; set; }
    }
}
