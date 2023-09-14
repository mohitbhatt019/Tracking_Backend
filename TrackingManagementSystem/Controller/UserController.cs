using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Controller
{
    public static class UserController
    {
        public static void UserEndPoints(this IEndpointRouteBuilder endpoints)
        {
            //this endpoint is to register a new user in company
            endpoints.MapPost("/register", async (IUserRepository _userRepository, [FromBody] RegisterModel registerModel) =>
            {
                var result = await _userRepository.RegisterUser(registerModel);
                if (!result) { return Results.NotFound(); }
                return Results.Ok();
            });

            //this endpoint is to Authenticate user and check user credentials
        
            endpoints.MapPost("/login", async (IUserRepository _userRepository, LoginModel loginModel) =>
            {
                if(loginModel == null) { return Results.NotFound(); }   
                var authenticate = _userRepository.Authenticate(loginModel);
                if (authenticate.Result==null)  return Results.BadRequest(); 
                return Results.Ok(authenticate.Result);
            });

            //this endpoint is to get all usetlist from aspnetusers
            endpoints.MapGet("/AllUsers", (IUserRepository _userRepository) =>
            {
                var users= _userRepository.GetUsers();
                if (users.Count() > 0) { return users; }
                else return null;
               
            });


        }
    }
}
