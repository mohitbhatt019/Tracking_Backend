using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Controller
{
    public static class SearchUserController
    {
        public static void SearchUser(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/searchuser", async (ISearchRepository _searchRepository, IHttpContextAccessor _httpContextAccessor, string userName) =>
            {
                //var token= _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var result = _searchRepository.SearchUsername(userName);
                if (result == null) { return Results.NotFound(new { status = 0, message = "No user found with this name" }); }
                return Results.Ok(result);
            });

            endpoints.MapPost("/LockUnlockUser",  async (string id, IUserRepository _userRepository) =>
            {
                if (id == null) return Results.NotFound(new { status = 0, error = "UserId not exist" });
                var lockUser = _userRepository.LockUnlockUser(id);
                if (!lockUser) return Results.NotFound(new { data = "Failed to lock user" });
                return Results.Ok(new { data = 1, message = "Lock unlock sucesfull" });
            });
            
            endpoints.MapGet("/specificuserinvitation", [Authorize] async ( ITokenRepository _tokenRepository, IHttpContextAccessor _httpContextAccessor, IUserRepository _userRepository, ISearchRepository _searchRepository) =>
            {
                var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var senderId = _tokenRepository.GetUserIdFromToken(token);
                var specificuserinvitation= _searchRepository.ShowSpecificInvitation(senderId);
                if (specificuserinvitation==null) return Results.NotFound(new { status = 0, message = "No Invitation Found" });
                return Results.Ok(specificuserinvitation);
            });
        }

    }
}
