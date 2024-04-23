using AutoMapper;
using Entities.Models;
using Shared.LateMissStatus;

namespace Main.Mapping;

public class LateMissStatusMapping : Profile
{
    public LateMissStatusMapping()
    {
        CreateMap<LateMissStatus, LateMissStatusDto>();
        CreateMap<LateMissStatusForCreationDto, LateMissStatus>();
        CreateMap<LateMissStatusForUpdateDto, LateMissStatus>();
        CreateMap<LateMissStatusForUpdateDto, LateMissStatus>().ReverseMap();
    }
}