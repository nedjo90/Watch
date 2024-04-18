using AutoMapper;
using Entities.Models;
using Shared;
using Shared.DocumentStatus;
using Shared.DocumentType;

namespace Main.Mapping;

public class DocumentTypeMapping : Profile
{
    public DocumentTypeMapping()
    {
        CreateMap<DocumentType, DocumentTypeDto>();
        CreateMap<DocumentTypeForCreationDto, DocumentType>();
        CreateMap<DocumentTypeForUpdateDto, DocumentType>();
        CreateMap<DocumentTypeForUpdateDto, DocumentType>().ReverseMap();
    }
}