using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.DocumentType;

namespace Main.Mapping;

public class DocumentTypeMapping : Profile
{
    public DocumentTypeMapping()
    {
        CreateMap<DocumentType, DocumentTypeDto>();
        CreateMap<DocumentTypeDto, DocumentType>();
        CreateMap<DocumentTypeForCreationDto, DocumentTypeDto>();
        CreateMap<DocumentTypeForCreationDto, DocumentType>();
        CreateMap<DocumentType, DocumentTypeForCreationDto>();
        CreateMap<DocumentTypeForUpdateDto, DocumentTypeDto>();
        CreateMap<DocumentTypeForUpdateDto, DocumentTypeDto>().ReverseMap();
    }
}