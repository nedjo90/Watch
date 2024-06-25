using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissDocument;

namespace Service;

internal class LateMissDocumentService: ServiceBase, ILateMissDocumentService
{
    public LateMissDocumentService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<LateMissDocumentDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissDocument> lateMissDocuments =
            await RepositoryManager.LateMissDocumentRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissDocumentDto> lateMissDocumentDtos =
            Mapper.Map<IEnumerable<LateMissDocumentDto>>(lateMissDocuments);
        return lateMissDocumentDtos;
    }

    public async Task<IEnumerable<LateMissDocumentDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<LateMissDocument> lateMissDocument =
            await RepositoryManager.LateMissDocumentRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<LateMissDocumentDto> lateMissDocumentDtos =
            Mapper.Map<IEnumerable<LateMissDocumentDto>>(lateMissDocument);
        return lateMissDocumentDtos;
    }

    public async Task<LateMissDocumentDto> GetByIdAsync(Guid id, bool trackChanges)
    {
        LateMissDocument? lateMissDocument =
            await RepositoryManager.LateMissDocumentRepository.GetByIdAsync(id, trackChanges);
        if (lateMissDocument == null)
            throw new IdNotFoundException(id, "Late Miss Document");
        LateMissDocumentDto lateMissDocumentDto =
            Mapper.Map<LateMissDocumentDto>(lateMissDocument);
        return lateMissDocumentDto;
    }

    public async Task<LateMissDocumentDto> CreateAsync(LateMissDocumentForCreationDto lateMissDocumentForCreationDto)
    {
        await ThrowIfLateMissDocumentForCreationIsNotValid(lateMissDocumentForCreationDto);
        LateMissDocument lateMissDocument =
            Mapper.Map<LateMissDocument>(lateMissDocumentForCreationDto);
        RepositoryManager.LateMissDocumentRepository.CreateAsync(lateMissDocument);
        await ServiceManager.LateMissDocumentHistoryService.RegisterModification(lateMissDocument,
            TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        LateMissDocumentDto lateMissDocumentDto = Mapper.Map<LateMissDocumentDto>(lateMissDocument);
        return lateMissDocumentDto;
    }

    public async Task<IEnumerable<LateMissDocumentDto>> CreateCollectionAsync(IEnumerable<LateMissDocumentForCreationDto> lateMissDocumentForCreationDtos)
    {
        await ThrowIfListOfLateMissDocumentForCreationIsNotValid(lateMissDocumentForCreationDtos);
        IEnumerable<LateMissDocument?> lateMissDocument =
            Mapper.Map<IEnumerable<LateMissDocument>>(lateMissDocumentForCreationDtos);
        foreach (LateMissDocument entity in lateMissDocument)
        {
            RepositoryManager.LateMissDocumentRepository.CreateAsync(entity);
            await ServiceManager.LateMissDocumentHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<LateMissDocumentDto> lateMissDocumentDtos =
            Mapper.Map<IEnumerable<LateMissDocumentDto>>(lateMissDocument);
        return lateMissDocumentDtos;
    }
    
    private async Task ThrowIfListOfLateMissDocumentForCreationIsNotValid(
        IEnumerable<LateMissDocumentForCreationDto> lateMissDocumentForCreationDtos)
    {
        List<object> errors = new();
        foreach (LateMissDocumentForCreationDto lateMissDocumentForCreationDto in lateMissDocumentForCreationDtos)
        {
            LateMiss? entity = await ServiceManager.LateMissService
                    .CheckIfExistAndGetByIdAsync(lateMissDocumentForCreationDto.LateMissId);
            if (entity == null)
                errors.Add(
                    new
                    {
                        lateMissDocumentForCreationDto.LateMissId,
                        detail = "Late Miss Id doesn't exists."
                    });
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Invalid late Miss information detected. Please provide valid informations.", errors);
    }
    
    private async Task ThrowIfLateMissDocumentForCreationIsNotValid(
        LateMissDocumentForCreationDto lateMissDocumentForCreationDto)
    {
        LateMiss? entity = await ServiceManager.LateMissService
            .CheckIfExistAndGetByIdAsync(lateMissDocumentForCreationDto.LateMissId);
        if (entity == null)
            throw new IdNotFoundException(lateMissDocumentForCreationDto.LateMissId, "Late Miss Id");
    }
}