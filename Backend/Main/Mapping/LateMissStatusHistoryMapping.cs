using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMissStatus;
using Shared.DataTransfertObject.LateMissStatusHistory;

namespace Main.Mapping;

public class LateMissStatusHistoryMapping : Profile
{
    public LateMissStatusHistoryMapping()
    {
        CreateMap<LateMissStatus, LateMissStatusHistory>();
        CreateMap<LateMissStatusHistory, LateMissStatusHistoryDto>();
    }
}