using TrackingManagementSystem.Models;
using TrackingManagementSystem.Models.ViewModel;

namespace TrackingManagementSystem.Repository.IRepository
{
    public interface ISearchRepository
    {
        public Task<ApplicationUser> SearchUser(string username);
        public ICollection<InviteUsers> SearchUsername(string username);
        public ICollection< InvitedUser> ShowSpecificInvitation(string senderId);
    }
}
