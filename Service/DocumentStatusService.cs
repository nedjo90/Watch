using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DocumentStatus;

namespace Service;

internal sealed class DocumentStatusService : ServiceBase, IDocumentStatusService
{
    public DocumentStatusService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
        : base(repositoryManager, loggerManager, mapper, documentTypeLinks) {}
    
    
    public async Task<IEnumerable<DocumentStatusDto>> GetAllDocumentStatusAsync(bool trackChanges)
    {
        IEnumerable<DocumentStatus> documentStatus =
            await RepositoryManager.DocumentStatus.GetAllDocumentStatusAsync(trackChanges);
        IEnumerable<DocumentStatusDto> documentStatusDto = Mapper.Map<IEnumerable<DocumentStatusDto>>(documentStatus);
        return documentStatusDto;
    }

    public async Task<DocumentStatusDto> CreateDocumentStatusAsync
        (DocumentStatusForCreationDto documentStatusForCreationDto)
    {
        DocumentStatus? documentStatus = 
            Mapper.Map<DocumentStatus>(documentStatusForCreationDto);
        RepositoryManager.DocumentStatus.CreateDocumentStatusAsync(documentStatus);
        await RepositoryManager.SaveAsync();
        DocumentStatusDto? documentStatusDto = Mapper.Map<DocumentStatusDto>(documentStatus);
        return documentStatusDto;
    }

    public async Task<DocumentStatusDto> GetDocumentStatusByIdAsync(Guid documentStatusId, bool trackChanges)
    {
        DocumentStatus? documentStatus =
            await RepositoryManager
                .DocumentStatus
                .GetDocumentStatusByIdAsync(documentStatusId, trackChanges);
        DocumentStatusDto documentStatusDto = Mapper.Map<DocumentStatusDto>(documentStatus);
        return documentStatusDto;
    }
    
    public async Task<IEnumerable<DocumentStatusDto>> GetDocumentStatusCollectionAsync(IEnumerable<Guid> guids, bool trackChanges)
    {
        IEnumerable<DocumentStatus> entities = 
            await GetDocumentStatusCollectionByIds(guids, trackChanges);
        IEnumerable<DocumentStatusDto> documentStatusCollection = 
            Mapper.Map<IEnumerable<DocumentStatusDto>>(entities);
        return documentStatusCollection;
    }

    public async Task<(IEnumerable<DocumentStatusDto>, string ids)> CreateDocumentStatusCollection
        (IEnumerable<DocumentStatusForCreationDto> documentStatusCollection)
    {
        if (documentStatusCollection is null)
            throw new CollectionBadRequest();
        IEnumerable<DocumentStatus> documentStatusEntities = 
            Mapper.Map<IEnumerable<DocumentStatus>>(documentStatusCollection);
        foreach (DocumentStatus entity in documentStatusEntities)
            RepositoryManager.DocumentStatus.CreateDocumentStatusAsync(entity);
        await RepositoryManager.SaveAsync();
        IEnumerable<DocumentStatusDto>? documentStatusCollectionToReturn =
            Mapper.Map<IEnumerable<DocumentStatusDto>>(documentStatusEntities);
        string ids = string.Join(",", documentStatusCollectionToReturn.Select(e => e.Id));
        return (documentStatusCollectionToReturn, ids);
    }

    public async Task DeleteDocumentStatusAsync(Guid id, bool trackChanges)
    {
        DocumentStatus entity = 
            await GetDocumentStatusAndCheckIfExitsAsync(id, trackChanges);
        RepositoryManager.DocumentStatus.DeleteDocumentStatus(entity);
        await RepositoryManager.SaveAsync();
    }

    public async Task DeleteDocumentStatusCollectionAsync(IEnumerable<DocumentStatusDto> documentStatusCollection, bool trackChanges)
    {
        IEnumerable<Guid> ids = documentStatusCollection.Select(e => e.Id).ToList();
        IEnumerable<DocumentStatus> entities = 
            await GetDocumentStatusCollectionByIds(ids, trackChanges);
        foreach (DocumentStatus entity in entities)
            RepositoryManager.DocumentStatus.DeleteDocumentStatus(entity);
        await RepositoryManager.SaveAsync();
    }

    public async Task UpdateDocumentStatusAsync
        (Guid guid, DocumentStatusForUpdateDto documentStatusForUpdateDto, bool trackChanges)
    {
        if (documentStatusForUpdateDto.Label is null)
            throw new NullObjectException(nameof(documentStatusForUpdateDto.Label));
        DocumentStatus entity =
            await GetDocumentStatusAndCheckIfExitsAsync(guid, trackChanges);
        Mapper.Map( documentStatusForUpdateDto, entity);
        await RepositoryManager.SaveAsync();
    }

    public async Task<(DocumentStatusForUpdateDto documentStatusToPatch, DocumentStatus entity)>
        GetDocumentStatusForPatchAsync
        (Guid documentStatusId, bool trackChanges)
    {
        DocumentStatus entity = await GetDocumentStatusAndCheckIfExitsAsync(documentStatusId, trackChanges);
        DocumentStatusForUpdateDto? documentStatusToPatch = Mapper.Map<DocumentStatusForUpdateDto>(entity);
        return (documentStatusToPatch, entity);
    }

    public async Task SaveChangesForPatchAsync
        (DocumentStatusForUpdateDto documentStatusToPatch, DocumentStatus entity)
    {
        Mapper.Map(documentStatusToPatch, entity);
        await RepositoryManager.SaveAsync();
    }

    private async Task<DocumentStatus> GetDocumentStatusAndCheckIfExitsAsync(Guid id, bool trackChanges)
    {
        DocumentStatus? documentStatus = 
            await RepositoryManager.DocumentStatus
                .GetDocumentStatusByIdAsync(id, trackChanges);
        if (documentStatus is null)
            throw new DocumentStatusNotFoundException(id);
        return documentStatus;
    }

    private async Task<IEnumerable<DocumentStatus>> GetDocumentStatusCollectionByIds
        (IEnumerable<Guid> guids, bool trackChanges)
    {
        if (guids is null)
            throw new CollectionBadRequest();
        IEnumerable<DocumentStatus> entities = 
            await RepositoryManager.DocumentStatus
                .GetDocumentStatusCollection(guids, trackChanges);
        if (entities.Count() != guids.Count())
            throw new CollectionByIdsBadRequestException();
        return entities;
    }
}