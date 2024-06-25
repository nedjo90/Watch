using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.DocumentStatusHistory;

namespace Main.Mapping;

public class DocumentStatusHistoryMapping : Profile
{
    public DocumentStatusHistoryMapping()
    {
        CreateMap<DocumentStatusHistory, DocumentStatusHistoryDto>();
        CreateMap<DocumentStatus, DocumentStatusHistory>();
    }
}