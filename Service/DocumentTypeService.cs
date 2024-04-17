using System.Collections;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared;
using Shared.RequestFeatures;

namespace Service;

internal sealed class DocumentTypeService : IDocumentTypeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public DocumentTypeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DocumentTypeDto>> GetAllDocumentTypesAsync(bool trackChanges)
    {
        IEnumerable<DocumentType> documentTypes =  
            await _repositoryManager.DocumentType.GetAllDocumentTypesAsync( trackChanges);
        IEnumerable<DocumentTypeDto>? documentTypesDto =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypes);
        return documentTypesDto;
    }
    
    public async Task<(IEnumerable<DocumentTypeDto> documentTypeDtos, MetaData metadata)> GetAllDocumentTypesPagingAsync(
        DocumentTypeParameters documentTypeParameters, bool trackChanges)
    {
        PagedList<DocumentType> documentTypesWithMetaData =  
            await _repositoryManager.DocumentType
                .GetAllDocumentTypesPagingAsync(documentTypeParameters, trackChanges);
        IEnumerable<DocumentTypeDto>? documentTypesDto =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypesWithMetaData);
        return (documentTypesDto, documentTypesWithMetaData.MetaData);
    }

    public async Task<DocumentTypeDto> GetDocumentTypeAsync(Guid id, bool trackChanges)
    {
        DocumentType? documentType =
            await GetDocumentTypeAndCheckIfExitsAsync(id, trackChanges);
        DocumentTypeDto documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
        return documentTypeDto;
    }

    public async Task<DocumentTypeDto> CreateDocumentTypeAsync(DocumentTypeForCreationDto documentTypeForCreationDto)
    {
        DocumentType? documentTypeEntity = _mapper.Map<DocumentType>(documentTypeForCreationDto);
        _repositoryManager.DocumentType.CreateDocumentType(documentTypeEntity);
        await _repositoryManager.SaveAsync();

        DocumentTypeDto? documentTypeToReturn = _mapper.Map<DocumentTypeDto>(documentTypeEntity);

        return documentTypeToReturn;
    }

    public async Task<IEnumerable<DocumentTypeDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<DocumentType> documentTypeEntities =
            await _repositoryManager.DocumentType.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != documentTypeEntities.Count())
            throw new CollectionByIdsBadRequestException();
        IEnumerable<DocumentTypeDto>? documentTypesToReturn =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypeEntities);
        return documentTypesToReturn;
    }

    public async Task<(IEnumerable<DocumentTypeDto> documentTypeDtos, string ids)> CreateDocumentTypeCollectionAsync
        (IEnumerable<DocumentTypeForCreationDto> documentTypeCollection)
    {
        if (documentTypeCollection is null)
            throw new DocumentTypeCollectionBadRequest();
        IEnumerable<DocumentType>? documentTypeEntities = 
            _mapper.Map<IEnumerable<DocumentType>>(documentTypeCollection);
        foreach (DocumentType documentType in documentTypeEntities)
        {
            _repositoryManager.DocumentType.CreateDocumentType(documentType);
        }
        await _repositoryManager.SaveAsync();

        IEnumerable<DocumentTypeDto>? documentTypeCollectionToReturn =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypeEntities);
        string ids = string.Join(",", documentTypeCollectionToReturn.Select(c => c.Id));
        return (documentTypeCollectionToReturn, ids);
    }

    public async Task DeleteDocumentTypeAsync(Guid documentTypeId, bool trackChanges)
    {
        DocumentType? documentType =
            await GetDocumentTypeAndCheckIfExitsAsync(documentTypeId, trackChanges);
        _repositoryManager.DocumentType.DeleteDocumentType(documentType);
        await _repositoryManager.SaveAsync();
    }

    public async Task DeleteDocumentTypeCollectionAsync(IEnumerable<DocumentTypeDto> documentTypeIdDtos, bool trackChanges)
    {
        if (documentTypeIdDtos is null)
            throw new IdParametersBadRequestException();
        IEnumerable<Guid> ids = documentTypeIdDtos.Select(documentTypeIdDto => documentTypeIdDto.Id).ToList();
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<DocumentType> documentTypes =
            await _repositoryManager.DocumentType.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != documentTypes.Count())
            throw new CollectionByIdsBadRequestException();
        foreach (DocumentType documentType in documentTypes)
            _repositoryManager.DocumentType.DeleteDocumentType(documentType);
        await _repositoryManager.SaveAsync();
    }
    


    public async Task UpdateDocumentTypeAsync(Guid documentTypeId, DocumentTypeForUpdateDto documentTypeForUpdateDto,
        bool trackChanges)
    {
        if (documentTypeForUpdateDto.Label is null)
            throw new NullObjectException(nameof(documentTypeForUpdateDto.Label));
        DocumentType? documentType = 
            await GetDocumentTypeAndCheckIfExitsAsync(documentTypeId, trackChanges);
        _mapper.Map(documentTypeForUpdateDto, documentType);
        await _repositoryManager.SaveAsync();
    }

    public async Task<(DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity)>
        GetDocumentTypeForPatchAsync(Guid documentTypeId, bool trackChanges)
    {
        DocumentType? documentTypeEntity = 
            await GetDocumentTypeAndCheckIfExitsAsync(documentTypeId, trackChanges);
        DocumentTypeForUpdateDto? documentTypeToPatch =
            _mapper.Map<DocumentTypeForUpdateDto>(documentTypeEntity);
        return (documentTypeToPatch, documentTypeEntity);
    }

    public async Task SaveChangesForPatchAsync(DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity)
    {
        _mapper.Map(documentTypeToPatch, documentTypeEntity);
        await _repositoryManager.SaveAsync();
    }
    
    
    private async Task<DocumentType> GetDocumentTypeAndCheckIfExitsAsync(Guid id, bool trackChanges)
    {
        DocumentType documentType = await _repositoryManager.DocumentType.GetDocumentTypeAsync(id, trackChanges);
        if (documentType is null)
            throw new DocumentTypeNotFoundException(id);
        return documentType;
    }
}