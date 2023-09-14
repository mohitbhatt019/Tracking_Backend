using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingManagementSystem.Models
{
    public class InvitedUser
    {
        [Key]
        public int Id { get; set; }
        //public string Email { get; set; }
        public string InvitationSenderUserId { get; set; } = string.Empty;
        [ForeignKey("InvitationSenderUserId")]
        public ApplicationUser? ApplicationUserSender { get; set; }
        public string InvitationSenderUserName { get; set; } = string.Empty;

        public string InvitationReceiverUserId { get; set; } = string.Empty;
        [ForeignKey("InvitationReceiverUserId")]
        public ApplicationUser? ApplicationUserReceiver { get; set; }
        public string InvitationReceiverUserName { get; set; } = string.Empty;

        public Action Action { get; set; }
        public Status Status { get; set; }
    }
}
