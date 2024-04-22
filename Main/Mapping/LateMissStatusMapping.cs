using AutoMapper;
using AutoMapper.Internal;
using Entities.Models;
using Shared.LateMissStatus;

namespace Main.Mapping;

public class LateMissStatusMapping : Profile
{
    public LateMissStatusMapping()
    {
        CreateMap<LateMissStatus, LateMissStatusDto>();
        CreateMap<LateMissStatusForCreationDto, LateMissStatus>();

    }
}