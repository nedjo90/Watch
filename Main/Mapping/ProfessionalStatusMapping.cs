using AutoMapper;
using Entities.Models;
using Shared.ProfessionalStatus;

namespace Main.Mapping;

public class ProfessionalStatusMapping : Profile
{
    public ProfessionalStatusMapping()
    {
        CreateMap<ProfessionalStatus, ProfessionalStatusDto>();
        CreateMap<ProfessionalStatusForCreation, ProfessionalStatus>();
        CreateMap<ProfessionalStatus, ProfessionalStatusDto>();
    }
}