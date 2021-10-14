using AutoMapper;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Models;
using static PrisonManagementSystem.Models.UserDto;

namespace PrisonManagementSystem.Config
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()

        {
            CreateMap<User, UserRegistrationModel>().ReverseMap();
            CreateMap<Prisoner, CreatePrisonerDto>().ReverseMap();
            CreateMap<Visiting, CreateVisitorDto>().ReverseMap();
            CreateMap<Visitor, CreateVisitorDto>().ReverseMap();
            CreateMap<OfficerForm, OfficersInfoViewModel>().ReverseMap();
            CreateMap<Duty, CreateDutyViewModel>().ReverseMap();
           
         
        }
    }
}
