using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.Training;

namespace Main.Mapping;

public class TrainingMapping : Profile
{
    public TrainingMapping()
    {
        CreateMap<Training, TrainingDto>();
        CreateMap<TrainingForCreationDto, Training>();
        CreateMap<TrainingForUpdateDto, Training>();
        CreateMap<TrainingForUpdateDto, Training>().ReverseMap();
    }
}