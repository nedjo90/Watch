using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMiss;

namespace Main.Mapping;

public class LateMissMapping : Profile
{
    public LateMissMapping()
    {
        CreateMap<LateMiss, LateMissDto>();
        CreateMap<LateMissForCreationDto, LateMiss>();
        CreateMap<LateMissForUpdateDto, LateMiss>();
        CreateMap<LateMissForUpdateDto, LateMiss>().ReverseMap();
    }
}