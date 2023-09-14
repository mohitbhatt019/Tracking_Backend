namespace TrackingManagementSystem.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int EmployeeCount { get; set; }
        public bool IsChange { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } // Navigation property
        //public int InvitedUserId { get; set; }
        //public InvitedUser InvitedUser { get; set; }
    }
}
