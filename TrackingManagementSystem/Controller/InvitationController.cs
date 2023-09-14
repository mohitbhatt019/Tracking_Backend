using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto;
using System.Runtime.CompilerServices;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Models.ViewModel;
using TrackingManagementSystem.Repository;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Controller
{
    public static class InvitationController
    {
        public static void InviteUserById(this IEndpointRouteBuilder endpoints)
        {

            //this endpoints is to create a new invitation Record in invitation table, and send invitation link to the user's registered email id
            endpoints.MapPost("/InviteUserById",(string RecieverId, IHttpContextAccessor httpContextAccessor, ITokenRepository _tokenRepository,IInvitationRepository _invitationRepository) =>
            {
                string token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                string getSenderId = _tokenRepository.GetUserIdFromToken(token);
                if (getSenderId == null)
                    return Results.BadRequest(new { message = "your token doesnot contain user id " });

                var result = _invitationRepository.CreateInvitation(getSenderId, RecieverId);
                if (result == false) { return Results.NotFound(new { status = 0, message = "No user found with this name" }); }
                return Results.Ok();
            });

            //This end point is to change status in the invitation table 
            endpoints.MapPost("/changeInvitationStatus", (IInvitationRepository _invitationRepository, string receiverId, string senderId, int status) =>
            {
                 var changeStatus=_invitationRepository.ChangeInvitationStatus(receiverId, senderId, status);
                if(!changeStatus) return Results.BadRequest();
                return Results.Ok(changeStatus);
            });

            endpoints.MapGet("/GetAllFromInvitationTable",[Authorize]async(IInvitationRepository _invitationRepository) =>
            {
                var data = _invitationRepository.GetAllRecordsFromInviteTable();
                if (data == null) return Results.NotFound();
                return Results.Ok(new {data=data});
            });

            endpoints.MapPost("/ChangeInvitationAction", async (IInvitationRepository _invitationRepository, string receiverId, string senderId, int action) =>
            {
                var changeInvitation = _invitationRepository.ChangeActionStatus(receiverId, senderId, action);
                if(changeInvitation==false) return Results.BadRequest();
                return Results.Ok(changeInvitation);
            });
            endpoints.MapGet("/GetAllInvitedUser", [Authorize] async (IInvitedPersonRepository _invitationRepository, IHttpContextAccessor _httpContextAccessor, ITokenRepository _searchRepository) =>
            {
                var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var result = _searchRepository.GetUserIdFromToken(token);
                if (result == null) return Results.NotFound();
                var userList = _invitationRepository.GetAllInvitedUsersInvitations( result);
                if(userList==null) return Results.NotFound();
                return Results.Ok(userList);
            });
            endpoints.MapGet("/GetSpecificUserDataInInviteTable", [Authorize] (ICompanyRepository _companyRepository, string id) =>
            {
                if(id==null) return Results.NotFound(id);
                var data=_companyRepository.GetAllCompanies(id);
                if(data==null) return Results.NotFound();
                return Results.Ok(data);
            });

            //InvitationTable crud
       



        }
    }
}
