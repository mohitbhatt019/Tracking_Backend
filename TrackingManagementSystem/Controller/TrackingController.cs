using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TrackingManagementSystem.DTO;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Repository.IRepository;

namespace TrackingManagementSystem.Controller
{
    public static class TrackingController
    {
        public static void TrackingEndPoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/GetTrackingById", async (IHttpContextAccessor httpContextAccessor, ITrackingRepository _trackingRepository, string id) =>
            {
                var track = _trackingRepository.GetCompany(id);
                if (track == null) { return null; }
                return Results.Ok(track);
            });

            endpoints.MapGet("/getuserdatas/{id}", async (IMapper _mapper, IHttpContextAccessor httpContextAccessor, ITrackingRepository _trackingRepository,
                string id) =>
             {
                if (string.IsNullOrEmpty(id))
                    return Results.BadRequest();

                var data = _trackingRepository.GetSpecificUserData(id);
                IList<CompanyDTO> companyDTOs = _mapper.Map<IList<CompanyDTO>>(data);

                if (data.Count == 0)
                    return Results.Ok(data);

                var findTracking = _trackingRepository.GetAll(data.FirstOrDefault().ApplicationUserId).ToList();

                foreach (var tracking in findTracking)
                {
                    var trackingOutput = new TrackingOutput()
                    {
                        TrackingId = tracking.TrackingId,
                        CompanyId = tracking.CompanyId,
                        DataChangeId = tracking.DataChangeUserId,
                        DataChangeUser = _trackingRepository.CheckPersonsId(tracking.UserId),
                        UserActions = (TrackingOutput.Action)tracking.TrackingAction,
                        TrackingDate = tracking.TrackingDate,
                        DataChangeName = tracking.DataChangeUserIdName,
                        //IsDeleted = false, // Set the IsDeleted property to false for each TrackingOutput object
                    };

                    companyDTOs.FirstOrDefault(u => u.Id == tracking.CompanyId).TrackingDetails.Add(trackingOutput);
                }

                return Results.Ok(companyDTOs);
            });

        }
    }
}
