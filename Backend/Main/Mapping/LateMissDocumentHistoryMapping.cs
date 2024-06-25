using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMissDocumentHistory;

namespace Main.Mapping;

public class LateMissDocumentHistoryMapping : Profile
{
    public LateMissDocumentHistoryMapping()
    {
        CreateMap<LateMissDocumentHistory, LateMissDocumentHistoryDto>();
        CreateMap<LateMissDocument, LateMissDocumentHistory>();
    }
}