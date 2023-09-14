namespace TrackingManagementSystem.Models.ViewModel
{
    public class TrackingViewModel
    {
        public string TrackingId { get; set; } = Guid.NewGuid().ToString();
        public int CompanyId { get; set; } = 0;
        public string UserId { get; set; } = string.Empty;

        public DateTime TrackingDate { get; set; } = DateTime.Now;
    }
}
