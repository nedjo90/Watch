using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMissHistory;

namespace Main.Mapping;

public class LateMissHistoryMapping : Profile
{
    public LateMissHistoryMapping()
    {
        CreateMap<LateMissHistory, LateMissHistoryDto>();
        CreateMap<LateMiss, LateMissHistory>();
    }
}