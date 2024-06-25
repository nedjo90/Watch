using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.TrainingHistory;

namespace Main.Mapping;

public class TrainingHistoryMapping : Profile
{
    public TrainingHistoryMapping()
    {
        CreateMap<TrainingHistory, TrainingHistoryDto>();
        CreateMap<Training, TrainingHistory>();
    }
}