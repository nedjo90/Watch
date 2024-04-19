using AutoMapper;
using Entities.Models;
using Shared;
using Shared.DocumentStatus;
using Shared.DocumentType;

namespace Main.Mapping;

public class DocumentStatusMapping : Profile
{
    public DocumentStatusMapping()
    {
        CreateMap<DocumentStatus, DocumentStatusDto>();
        CreateMap<DocumentStatusForCreationDto, DocumentStatus>();
        CreateMap<DocumentStatusForUpdateDto, DocumentStatus>();
        CreateMap<DocumentStatusForUpdateDto, DocumentStatus>().ReverseMap();
    }
}