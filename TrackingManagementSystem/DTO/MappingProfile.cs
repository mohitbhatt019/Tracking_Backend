using AutoMapper;
using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
       
    }
}
