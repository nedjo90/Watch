using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.TrainingTypeHistory;

namespace Main.Mapping;

public class TrainingTypeHistoryMapping : Profile
{
    public TrainingTypeHistoryMapping()
    {
        CreateMap<TrainingTypeHistory, TrainingTypeHistoryDto>();
        CreateMap<TrainingType, TrainingTypeHistory>();
    }
}