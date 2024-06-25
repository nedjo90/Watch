using System.ComponentModel;
using System.Net;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.Document;
using Shared.DataTransfertObject.DocumentStatus;

namespace Service;

internal class DocumentStatusService : ServiceBase, IDocumentStatusService
{
    public DocumentStatusService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    
    public async Task<DocumentStatus?> CheckIfIdExist(Guid? id, bool trackChanges)
    {
        return await RepositoryManager.DocumentStatusRepository.GetByIdAsync(id, trackChanges);
    }
    
    public async Task<DocumentStatusDto?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        DocumentStatus? documentStatus = await CheckIfIdExist(id, trackChanges);
        if (documentStatus == null)
            throw new IdNotFoundException(id, "Document Status");
        DocumentStatusDto documentStatusDto = Mapper.Map<DocumentStatusDto>(documentStatus);
        return documentStatusDto;
    }

    public async Task<IEnumerable<DocumentStatusDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<DocumentStatus> documentStatus =
            await RepositoryManager.DocumentStatusRepository.GetAllAsync(trackChanges);
        IEnumerable<DocumentStatusDto> documentStatusDtos =
            Mapper.Map<IEnumerable<DocumentStatusDto>>(documentStatus);
        return documentStatusDtos;
    }

    public async Task<IEnumerable<DocumentStatusDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges)
    {
        IEnumerable<DocumentStatus> documentStatus =
            await RepositoryManager.DocumentStatusRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<DocumentStatusDto> documentStatusDtos =
            Mapper.Map<IEnumerable<DocumentStatusDto>>(documentStatus);
        return documentStatusDtos;
    }

    public async Task<DocumentStatusDto> CreateAsync(DocumentStatusForCreationDto documentStatusForCreationDto)
    {
        DocumentStatus? documentStatus = await CheckIfExistAndGetByLabel(documentStatusForCreationDto.Label!, false);
        if (documentStatus is not null)
            throw new LabelAlreadyExistBadRequest("Document Status", documentStatusForCreationDto.Label!);
        documentStatus = Mapper.Map<DocumentStatus>(documentStatusForCreationDto);
        RepositoryManager.DocumentStatusRepository.CreateAsync(documentStatus);
        await ServiceManager.DocumentStatusHistoryService.RegisterModification(documentStatus, TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        DocumentStatusDto documentStatusDto = Mapper.Map<DocumentStatusDto>(documentStatus);
        return documentStatusDto;
    }

    public async Task<IEnumerable<DocumentStatusDto>> CreateCollectionAsync(IEnumerable<DocumentStatusForCreationDto> documentStatusForCreationDtos)
    {
        await ThrowIfListOfDocumentStatusForCreationIsNotValid(documentStatusForCreationDtos);
        IEnumerable<DocumentStatus?> documentStatus =
            Mapper.Map<IEnumerable<DocumentStatus>>(documentStatusForCreationDtos);
        foreach (DocumentStatus entity in documentStatus)
        {
            RepositoryManager.DocumentStatusRepository.CreateAsync(entity);
            await ServiceManager.DocumentStatusHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<DocumentStatusDto> documentStatusDtos =
            Mapper.Map<IEnumerable<DocumentStatusDto>>(documentStatus);
        return documentStatusDtos;
    }

    private async Task ThrowIfListOfDocumentStatusForCreationIsNotValid(
        IEnumerable<DocumentStatusForCreationDto> documentStatusForCreationDtos)
    {
        Dictionary<object, object> errors = new ();
        foreach (DocumentStatusForCreationDto documentStatusForCreationDto in documentStatusForCreationDtos)
        {
            DocumentStatus? entity = await CheckIfExistAndGetByLabel(documentStatusForCreationDto.Label!, false);
            if (entity != null)
                errors.Add(documentStatusForCreationDto.Label!, "The label provided already exists.");
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Existing labels have been detected. Please adjust them to ensure the creation of a valid collection.", errors);
    }
    
    private async Task<DocumentStatus?> CheckIfExistAndGetByLabel(string label, bool trackChanges)
    {
        return await RepositoryManager.DocumentStatusRepository.GetByLabelAsync(label, trackChanges);
    }
}