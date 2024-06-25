using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.ProfessionalStatusHistory;

namespace Main.Mapping;

public class ProfessionalStatusHistoryMapping : Profile
{
    public ProfessionalStatusHistoryMapping()
    {
        CreateMap<ProfessionalStatusHistory, ProfessionalStatusHistoryDto>();
        CreateMap<ProfessionalStatus, ProfessionalStatusHistory>();
    }
}