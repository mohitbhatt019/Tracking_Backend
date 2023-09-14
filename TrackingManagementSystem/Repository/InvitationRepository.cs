using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using TrackingManagementSystem.Data;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Models.ViewModel;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Repository
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public InvitationRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public bool CreateInvitation(string senderInvitationId, string ReceiverInvitationId)
        {
             var validatasender = _userManager.FindByIdAsync(senderInvitationId).Result;
            var validateReceiver = _userManager.FindByIdAsync(ReceiverInvitationId).Result;
            if (validateReceiver == null || validatasender == null && senderInvitationId==ReceiverInvitationId)
                return false;
            //here we will get token

            if (senderInvitationId == null && ReceiverInvitationId==null) throw new ArgumentNullException();

            //Here we add check To avoid multiple invitations
            var checkInvitationInDb = _context.invitedUsers.Where(sendId => sendId.InvitationSenderUserId == senderInvitationId && sendId.InvitationReceiverUserId == ReceiverInvitationId).ToList();
            if (checkInvitationInDb.Count!=0 ) return false;
           
            InvitedUser invitedUser = new InvitedUser
            {
                InvitationSenderUserId = senderInvitationId,
                InvitationReceiverUserId = ReceiverInvitationId,
                InvitationSenderUserName=validatasender.UserName,
                InvitationReceiverUserName= validateReceiver.UserName,
                Status = Status.Pending,
                Action = Models.Action.Disable
            };
            _context.invitedUsers.Add(invitedUser);
            var saveInvitation = _context.SaveChanges() == 1 ? true : false;
            if (!saveInvitation)
                return false;
            var sendEmailToUser = _emailSender.SendEmailAsync(validateReceiver.Email, senderInvitationId,ReceiverInvitationId );
            if (sendEmailToUser == null) return false;
            return true;
        }
       



        //Token
        public string? GetUserIdFromToken(string userToken)
        {
            if (userToken == "Bearer") return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var data = tokenHandler.ReadJwtToken(userToken);
            var userName = data.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value;
            return userName;
        }

        public bool ChangeInvitationStatus(string receiverId, string senderId, int status)
        {
            if(receiverId == null && senderId==null && status==null) return false;
           // if(status!=1 || status!=2) return false;
            
            var changeStatusId1 = _context.invitedUsers.FirstOrDefault(x => x.InvitationReceiverUserId == receiverId && x.InvitationSenderUserId == senderId);
            // var changeStatusId2 = _context.invitedUsers.FirstOrDefault(x => x.InvitationSenderUserId == senderId);
            changeStatusId1.Status = (Status) status;
                if (changeStatusId1.Status == Status.Approved || changeStatusId1.Status == Status.Pending) 
                {
                   changeStatusId1.Status=Status.Approved;
                changeStatusId1.Action=Models.Action.Enable;
                       _context.SaveChanges();
                return true;
            }
            else
            {

                changeStatusId1.Status = Status.Reject;
                changeStatusId1.Action = Models.Action.Disable;
                _context.SaveChanges();
            }

            return true;

        }

        public List<InvitedUser> GetAllRecordsFromInviteTable()
        {
            var usersInInviteTable=_context.invitedUsers.ToList();
            if (usersInInviteTable.Count == 0) return null;
            return usersInInviteTable;
        }

        public bool ChangeActionStatus(string receiverId, string senderId, int action)
        {
            if(receiverId==null && senderId == null && action == null) return false;
            var findUserInTable = _context.invitedUsers.FirstOrDefault(user => user.InvitationSenderUserId == senderId && user.InvitationReceiverUserId == receiverId);
            if(findUserInTable == null) return false;
            InvitedUser invitedUser = new InvitedUser
            {
                InvitationReceiverUserId= receiverId,
                InvitationSenderUserId=senderId
            };
            
            switch(action) 
            {
                case 1:
                    findUserInTable.Action = Models.Action.Enable; break;
                case 2:
                    findUserInTable.Action = Models.Action.Disable;
                    break;
                case 3:
                    findUserInTable.Action = Models.Action.Deleted;
                    break;
                default:
                    return false; // Handle unknown action

            }
            var updateInDb=_context.invitedUsers.Update(findUserInTable);
            var save = _context.SaveChanges();
            return true;
            
        }




































        //public ICollection<InviteUsers> FindPersons(string personName, string senderInvitationId)
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<InviteUsers> InvitationComesFromUser(string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<InviteUsers> InvitedPersonList(string senderId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool TakeActionOnInvitedPerson(string receiverId, string senderId, int action)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
