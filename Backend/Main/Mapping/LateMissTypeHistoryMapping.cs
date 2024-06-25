using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMissTypeHistory;

namespace Main.Mapping;

public class LateMissTypeHistoryMapping : Profile
{
    public LateMissTypeHistoryMapping()
    {
        CreateMap<LateMissType, LateMissTypeHistory>();
        CreateMap<LateMissTypeHistory, LateMissTypeHistoryDto>();
    }
}