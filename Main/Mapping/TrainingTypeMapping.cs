using AutoMapper;
using Entities.Models;
using Shared.TrainingType;

namespace Main.Mapping;

public class TrainingTypeMapping : Profile
{
    public TrainingTypeMapping()
    {
        CreateMap<TrainingType, TrainingTypeDto>();
        CreateMap<TrainingTypeForCreationDto, TrainingType>();
        CreateMap<TrainingTypeForUpdateDto, TrainingType>();
        CreateMap<TrainingTypeForUpdateDto, TrainingType>().ReverseMap();
    }
}