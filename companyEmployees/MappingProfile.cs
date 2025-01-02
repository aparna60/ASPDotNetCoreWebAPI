using AutoMapper;
using Entities.Models;
using Shared.DataTrannsferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
             opt => opt.MapFrom(x => (x.Address ?? string.Empty).Trim() + " " + (x.Country ?? string.Empty).Trim()));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
