using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.ObjectModel;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Models.ViewModel;

namespace TrackingManagementSystem.Repository.IRepository
{
    public interface IInvitationRepository
    {
        public bool CreateInvitation(string senderInvitationId, string ReceiverInvitationId);
        public List<InvitedUser> GetAllRecordsFromInviteTable();
        public string? GetUserIdFromToken(string userToken);
        public bool ChangeInvitationStatus(string receiverId, string senderId, int status);
        public bool ChangeActionStatus(string receiverId, string senderId, int action);

    }

}














































//public ICollection<InviteUsers> FindPersons(string personName, string senderInvitationId);
//public bool TakeActionOnInvitedPerson(string receiverId, string senderId, int action);
//public ICollection<InviteUsers> InvitedPersonList(string senderId);
//public ICollection<InviteUsers> InvitationComesFromUser(string userId);
//public bool ChangeInvitationStatus(string receiverId, string senderId, int status);