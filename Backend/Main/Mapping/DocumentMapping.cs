using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.Document;

namespace Main.Mapping;

public class DocumentMapping : Profile
{
    public DocumentMapping()
    {
        CreateMap<Document, DocumentDto>();
        CreateMap<DocumentDto, Document>();
        CreateMap<DocumentForCreationDto, DocumentDto>();
        CreateMap<DocumentForCreationDto, Document>();
        CreateMap<Document, DocumentForCreationDto>();
        CreateMap<DocumentForUpdateDto, DocumentDto>();
        CreateMap<DocumentForUpdateDto, DocumentDto>().ReverseMap();
    }
}