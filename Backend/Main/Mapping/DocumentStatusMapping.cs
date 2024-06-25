using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.DocumentStatus;


namespace Main.Mapping;

public class DocumentStatusMapping : Profile
{
    public DocumentStatusMapping()
    {
        CreateMap<DocumentStatus, DocumentStatusDto>();
        CreateMap<DocumentStatusDto, DocumentStatus>();
        CreateMap<DocumentStatusForCreationDto, DocumentStatusDto>();
        CreateMap<DocumentStatusForCreationDto, DocumentStatus>();
        CreateMap<DocumentStatus, DocumentStatusForCreationDto>();
        CreateMap<DocumentStatusForUpdateDto, DocumentStatusDto>();
        CreateMap<DocumentStatusForUpdateDto, DocumentStatusDto>().ReverseMap();
    }
}