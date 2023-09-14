using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository;
using TrackingManagementSystem.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrackingManagementSystem.Controller
{

    public static class CompanyController
    {

        public static void CompanyEndPoints(this IEndpointRouteBuilder endpoints)
        {

            //this endpoint is to create a new record in company table
            endpoints.MapPost("/CreateCompany", [Authorize] async  (Company company, ICompanyRepository _companyRepository, IHttpContextAccessor httpContextAccessor,
                IInvitationRepository invitationRepository, ITrackingRepository trackingRepository) =>
            {

                    var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                    var IdFromToken =  invitationRepository.GetUserIdFromToken(token);
                var PersonData=trackingRepository.CheckPersonsId(company.ApplicationUserId);
                var ChangePersonData=trackingRepository.CheckPersonsId(IdFromToken);
                if (PersonData == null) return Results.BadRequest();
                    if (IdFromToken == null) return Results.BadRequest();
                if (company.ApplicationUserId == IdFromToken)
                {
                    await _companyRepository.AddCompany(company);
                    Tracker tracker = new Tracker()
                    {
                        UserId = PersonData.Id,
                        TrackingDate = DateTime.Now,
                        DataChangeUserId = IdFromToken,
                        TrackingAction = TrackingAction.Add,
                        CompanyId = company.Id,
                        UserIdName = PersonData.UserName,
                        DataChangeUserIdName = ChangePersonData.UserName,

                    };
                    var track = trackingRepository.CreateTracking(tracker);

                }
                else
                {
                    
                    var addComapnyInDB = await _companyRepository.AddCompany(company);
                    if(!addComapnyInDB) return Results.BadRequest();
                    Tracker tracker = new Tracker()
                    {
                        UserId = PersonData.Id,
                        TrackingDate = DateTime.Now,
                        DataChangeUserId = IdFromToken,
                        TrackingAction = TrackingAction.Add,
                        CompanyId=company.Id,
                        UserIdName=PersonData.UserName,
                        DataChangeUserIdName= ChangePersonData.UserName,
                       

                    };
                     var track= trackingRepository.CreateTracking(tracker);
                    if(!track) return Results.BadRequest();
                    
                }
                 

                return Results.Ok(company);
                });

            //this endpoint is to get all the records from company table
            endpoints.MapGet("/GetAllCompanySpecific", [Authorize] async (string id, ICompanyRepository _companyRepository) =>
            {
                var result = _companyRepository.GetAllCompanies(id);
                if (result == null) { return Results.NotFound(); }
                return Results.Ok(result);
            });

            //This endpoint is to find record from company table by Copmany Id
            endpoints.MapGet("/FindCompanyById", [Authorize] async (ICompanyRepository _companyRepository, int id) =>
            {
                var findCompany = _companyRepository.GetById(id);
                if (findCompany == null) { return Results.NotFound(); }
                return Results.Ok(findCompany);
            });

            //This endpoint is to find record from company table by company name
            endpoints.MapGet("/FindCompanyByName", [Authorize] async (ICompanyRepository _companyRepository, string username) =>
            {
                var findCompany = _companyRepository.GetByName(username);
                if (findCompany == null) { return Results.NotFound(); }
                return Results.Ok(findCompany);
            });

            //This endpoint to dlete record from company table by companyId
            //endpoints.MapDelete("/DeleteCompany", [Authorize] async (IHttpContextAccessor _httpContextAccessor,
            //    IInvitationRepository invitationRepository, ICompanyRepository _companyRepository, ITrackingRepository _trackingRepository, int id) =>
            //{
            //    var deleteCompany = _companyRepository.DeleteById(id);
            //    if (!deleteCompany) { return Results.NotFound(); }
            //    return Results.Ok(new { data = id, status = 1 });

            //});

            endpoints.MapDelete("/DeleteCompany", [Authorize] async (IHttpContextAccessor _httpContextAccessor,
                IInvitationRepository invitationRepository, ICompanyRepository _companyRepository, ITrackingRepository _trackingRepository, int id) =>
            {

                var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var IdFromToken = invitationRepository.GetUserIdFromToken(token);
                var PersonData = _companyRepository.GetById(id);
                if (PersonData == null) return Results.NotFound();
                var ChangePersonData = _trackingRepository.CheckPersonsId(IdFromToken);
                var ChangePersonDataName = _trackingRepository.CheckPersonsId(PersonData.ApplicationUserId);
                if (PersonData == null) return Results.BadRequest();
                if (IdFromToken == null) return Results.BadRequest();
                if (PersonData.ApplicationUserId == IdFromToken)
                {
                    _trackingRepository.DeleteTracking(IdFromToken, PersonData.ApplicationUserId);
                    _companyRepository.DeleteById(id);

                }
                else
                {
                    PersonData.IsChange = true;

                    Tracker tracker = new Tracker()
                    {
                        UserId = PersonData.ApplicationUserId,
                        TrackingDate = DateTime.Now,
                        DataChangeUserId = IdFromToken,
                        TrackingAction = TrackingAction.Delete,
                        CompanyId = PersonData.Id,
                        UserIdName = ChangePersonDataName.UserName,
                        DataChangeUserIdName = ChangePersonData.UserName,
                    };
                    var track = _trackingRepository.CreateTracking(tracker);
                    if (!track) return Results.BadRequest();

                }


                return Results.Ok(id);

            });

            //This endpoint is to update record from company table
            endpoints.MapPut("/UpdateCompany", [Authorize] async (ICompanyRepository _companyRepository,
               IInvitationRepository invitationRepository, IHttpContextAccessor _httpContextAccessor, ITrackingRepository _trackingRepository, ITokenRepository _tokenRepository, [FromBody] Company company) =>
            {

                var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var IdFromToken = invitationRepository.GetUserIdFromToken(token);
                var PersonData = _trackingRepository.CheckPersonsId(company.ApplicationUserId);
                var ChangePersonData = _trackingRepository.CheckPersonsId(IdFromToken);
                if (PersonData == null) return Results.BadRequest();
                if (IdFromToken == null) return Results.BadRequest();
                if (company.ApplicationUserId == IdFromToken)
                {

                         _companyRepository.UpdateCompany(company);
                        Tracker tracker = new Tracker()
                        {
                            UserId = PersonData.Id,
                            TrackingDate = DateTime.Now,
                            DataChangeUserId = IdFromToken,
                            TrackingAction = TrackingAction.Update,
                            CompanyId = company.Id,
                            UserIdName = PersonData.UserName,
                            DataChangeUserIdName = ChangePersonData.UserName,

                        };
                        var track = _trackingRepository.CreateTracking(tracker);

                    

                }
                else
                {

                    var addBook =  _companyRepository.UpdateCompany(company);
                    if (!addBook) return Results.BadRequest();
                    Tracker tracker = new Tracker()
                    {
                        UserId = PersonData.Id,
                        TrackingDate = DateTime.Now,
                        DataChangeUserId = IdFromToken,
                        TrackingAction = TrackingAction.Update,
                        CompanyId = company.Id,
                        UserIdName = PersonData.UserName,
                        DataChangeUserIdName = ChangePersonData.UserName,


                    };
                    var track = _trackingRepository.CreateTracking(tracker);
                    if (!track) return Results.BadRequest();

                }


                return Results.Ok();
            });


            //string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            //string getSenderId = _tokenRepository.GetUserIdFromToken(token);
            //if (getSenderId == null)
            //    return Results.BadRequest(new { message = "your token doesnot contain user id " });

            //var updateCompany = _companyRepository.UpdateCompany(company);
            //if (!updateCompany) return Results.BadRequest();
            //return Results.Ok(company);
      

            //This endpoind is to send invite link to the user that we want to invite

            endpoints.MapPost("/email", async (IEmailSender _emailSender, string email, string subject, string htmlMessage) =>
            {
                await _emailSender.SendEmailAsync(email, subject, htmlMessage);
                return Results.Ok();
            });
        }
    }
}
