using AutoMapper;
using Entities.Models;
using Shared;

namespace Main;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DocumentType, DocumentTypeDto>();
        CreateMap<DocumentTypeForCreationDto, DocumentType>();
    }
}