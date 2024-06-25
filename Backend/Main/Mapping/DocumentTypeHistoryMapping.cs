using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.DocumentTypeHistory;

namespace Main.Mapping;

public class DocumentTypeHistoryMapping : Profile
{
    public DocumentTypeHistoryMapping()
    {
        CreateMap<DocumentTypeHistory, DocumentTypeHistoryDto>();
        CreateMap<DocumentType, DocumentTypeHistory>();
    }
}