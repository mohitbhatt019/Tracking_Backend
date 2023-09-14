using Microsoft.EntityFrameworkCore;
using TrackingManagementSystem.Data;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Repository
{
    public class InvitedPersonRepository : IInvitedPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public InvitedPersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Company> GetAllCompanyForSpecificUser(string userId)
        {
            throw new NotImplementedException();
        }

        //public bool GetAllInvitedUsers(string recieverId)
        //{
        //    if (string.IsNullOrWhiteSpace(recieverId)) throw new ArgumentNullException();
        //    var user= new InvitedUser(ApplicationUserSender);
        //    var allUser = _context.invitedUsers.ToList().Where(x=>x.InvitationReceiverUserId == recieverId);
        //    if (allUser.Count()>0) return true ;
        //    else return false;


        //}

        public ICollection<InvitedUser> GetAllInvitedUsersInvitations(string userId)
        {
            var invitedUser = _context.invitedUsers.Where(id => id.InvitationReceiverUserId == userId && id.Status == Status.Approved).Select(u => new InvitedUser()
            {
                InvitationSenderUserId = u.InvitationSenderUserId,
                ApplicationUserSender = new ApplicationUser()
                {
                    Id = u.ApplicationUserSender.Id,
                    UserName = u.ApplicationUserSender.UserName,
                },
                Action = u.Action,
                Status = u.Status,
            }).ToList();
            
            if(invitedUser==null) return null; return invitedUser;
        }
    }
}
