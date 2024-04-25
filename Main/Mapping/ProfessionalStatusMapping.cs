using AutoMapper;
using Entities.Models;
using Shared.ProfessionalStatus;

namespace Main.Mapping;

public class ProfessionalStatusMapping : Profile
{
    public ProfessionalStatusMapping()
    {
        CreateMap<ProfessionalStatus, ProfessionalStatusDto>();
        CreateMap<ProfessionalStatusForCreationDto, ProfessionalStatus>();
        CreateMap<ProfessionalStatusForUpdateDto, ProfessionalStatus>();
        CreateMap<ProfessionalStatusForUpdateDto, ProfessionalStatus>().ReverseMap();
    }
}