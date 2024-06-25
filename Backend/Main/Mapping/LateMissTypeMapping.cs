using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMissType;

namespace Main.Mapping;

public class LateMissTypeMapping : Profile
{
    public LateMissTypeMapping()
    {
        CreateMap<LateMissType, LateMissTypeDto>();
        CreateMap<LateMissTypeForCreationDto, LateMissType>();
        CreateMap<LateMissTypeForUpdateDto, LateMissType>();
        CreateMap<LateMissTypeForUpdateDto, LateMissType>().ReverseMap();
    }
}