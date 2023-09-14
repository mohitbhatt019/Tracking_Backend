using System.Collections.Generic;
using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.Repository.IRepository
{
    public interface IInvitedPersonRepository
    {
        //public  bool GetAllInvitedUsers(string recieverId);
        public ICollection<InvitedUser> GetAllInvitedUsersInvitations(string userId);
        public ICollection<Company> GetAllCompanyForSpecificUser(string userId);
    }
}
