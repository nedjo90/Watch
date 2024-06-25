using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.LateMissDocument;

namespace Main.Mapping;

public class LateMissDocumentMapping : Profile
{
    public LateMissDocumentMapping()
    {
        CreateMap<LateMissDocument, LateMissDocumentDto>();
        CreateMap<LateMissDocumentForCreationDto, LateMissDocument>();
        CreateMap<LateMissDocumentForUpdateDto, LateMissDocument>();
        CreateMap<LateMissDocumentForUpdateDto, LateMissDocument>().ReverseMap();
    }
}