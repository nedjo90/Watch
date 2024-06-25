using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.DocumentHistory;

namespace Main.Mapping;

public class DocumentHistoryMapping : Profile
{
    public DocumentHistoryMapping()
    {
        CreateMap<DocumentHistory, DocumentHistoryDto>();
        CreateMap<Document, DocumentHistory>();
    }
}