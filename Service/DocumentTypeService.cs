using System.Collections;
using System.Dynamic;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Service.Contracts;
using Shared;
using Shared.DocumentType;
using Shared.RequestFeatures;

namespace Service;

internal sealed class DocumentTypeService : ServiceBase, IDocumentTypeService
{
    public DocumentTypeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks) 
        : base(repositoryManager, loggerManager, mapper, documentTypeLinks) {}
    
    
    public async Task<IEnumerable<DocumentTypeDto>> GetAllDocumentTypesAsync(bool trackChanges)
    {
        IEnumerable<DocumentType> documentTypes =  
            await RepositoryManager.DocumentType.GetAllDocumentTypesAsync( trackChanges);
        IEnumerable<DocumentTypeDto>? documentTypesDto =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypes);
        return documentTypesDto;
    }
    
    public async Task<(LinkResponse linkResponse, MetaData metadata)> GetAllDocumentTypesPagingAsync
        (LinkParameters linkParameters, bool trackChanges)
    {
        PagedList<DocumentType> documentTypesWithMetaData =  
            await RepositoryManager.DocumentType
                .GetAllDocumentTypesPagingAsync(linkParameters.DocumentTypeParameters, trackChanges);
        
        IEnumerable<DocumentTypeDto>? documentTypesDto =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypesWithMetaData);
        
        LinkResponse links = DocumentTypeLinks
            .TryGenerateLinks(
                documentTypesDto,
                linkParameters.DocumentTypeParameters.Fields,
            linkParameters.Context);
        
        return (linkResponse: links, metadata: documentTypesWithMetaData.MetaData);
    }

    public async Task<DocumentTypeDto> GetDocumentTypeAsync(Guid id, bool trackChanges)
    {
        DocumentType? documentType =
            await GetDocumentTypeAndCheckIfExitsAsync(id, trackChanges);
        DocumentTypeDto documentTypeDto = Mapper.Map<DocumentTypeDto>(documentType);
        return documentTypeDto;
    }

    public async Task<DocumentTypeDto> CreateDocumentTypeAsync(DocumentTypeForCreationDto documentTypeForCreationDto)
    {
        DocumentType? documentTypeEntity = Mapper.Map<DocumentType>(documentTypeForCreationDto);
        RepositoryManager.DocumentType.CreateDocumentType(documentTypeEntity);
        await RepositoryManager.SaveAsync();

        DocumentTypeDto? documentTypeToReturn = Mapper.Map<DocumentTypeDto>(documentTypeEntity);

        return documentTypeToReturn;
    }

    public async Task<IEnumerable<DocumentTypeDto>> GetDocumentTypeCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<DocumentType> documentTypeEntities =
            await RepositoryManager.DocumentType.GetDocumentTypeCollectionAsync(ids, trackChanges);
        if (ids.Count() != documentTypeEntities.Count())
            throw new CollectionByIdsBadRequestException();
        IEnumerable<DocumentTypeDto>? documentTypesToReturn =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypeEntities);
        return documentTypesToReturn;
    }

    public async Task<(IEnumerable<DocumentTypeDto> documentTypeDtos, string ids)> 
        CreateDocumentTypeCollectionAsync
        (IEnumerable<DocumentTypeForCreationDto> documentTypeCollection)
    {
        if (documentTypeCollection is null)
            throw new CollectionBadRequest();
        IEnumerable<DocumentType>? documentTypeEntities = 
            Mapper.Map<IEnumerable<DocumentType>>(documentTypeCollection);
        foreach (DocumentType documentType in documentTypeEntities)
        {
            RepositoryManager.DocumentType.CreateDocumentType(documentType);
        }
        await RepositoryManager.SaveAsync();

        IEnumerable<DocumentTypeDto>? documentTypeCollectionToReturn =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypeEntities);
        string ids = string.Join(",", documentTypeCollectionToReturn.Select(c => c.Id));
        return (documentTypeCollectionToReturn, ids);
    }

    public async Task DeleteDocumentTypeAsync(Guid documentTypeId, bool trackChanges)
    {
        DocumentType? documentType =
            await GetDocumentTypeAndCheckIfExitsAsync(documentTypeId, trackChanges);
        RepositoryManager.DocumentType.DeleteDocumentType(documentType);
        await RepositoryManager.SaveAsync();
    }

    public async Task DeleteDocumentTypeCollectionAsync(IEnumerable<DocumentTypeDto> documentTypeIdDtos, bool trackChanges)
    {
        if (documentTypeIdDtos is null)
            throw new IdParametersBadRequestException();
        IEnumerable<Guid> ids = documentTypeIdDtos.Select(documentTypeIdDto => documentTypeIdDto.Id).ToList();
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<DocumentType> documentTypes =
            await RepositoryManager.DocumentType.GetDocumentTypeCollectionAsync(ids, trackChanges);
        if (ids.Count() != documentTypes.Count())
            throw new CollectionByIdsBadRequestException();
        foreach (DocumentType documentType in documentTypes)
            RepositoryManager.DocumentType.DeleteDocumentType(documentType);
        await RepositoryManager.SaveAsync();
    }

    public async Task UpdateDocumentTypeAsync
        (Guid documentTypeId, DocumentTypeForUpdateDto documentTypeForUpdateDto, bool trackChanges)
    {
        if (documentTypeForUpdateDto.Label is null)
            throw new NullObjectException(nameof(documentTypeForUpdateDto.Label));
        DocumentType? entity = 
            await GetDocumentTypeAndCheckIfExitsAsync(documentTypeId, trackChanges);
        Mapper.Map(documentTypeForUpdateDto, entity);
        await RepositoryManager.SaveAsync();
    }

    public async Task<(DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity)>
        GetDocumentTypeForPatchAsync(Guid documentTypeId, bool trackChanges)
    {
        DocumentType? documentTypeEntity = 
            await GetDocumentTypeAndCheckIfExitsAsync(documentTypeId, trackChanges);
        DocumentTypeForUpdateDto? documentTypeToPatch =
            Mapper.Map<DocumentTypeForUpdateDto>(documentTypeEntity);
        return (documentTypeToPatch, documentTypeEntity);
    }

    public async Task SaveChangesForPatchAsync(DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity)
    {
        Mapper.Map(documentTypeToPatch, documentTypeEntity);
        await RepositoryManager.SaveAsync();
    }
    
    
    private async Task<DocumentType> GetDocumentTypeAndCheckIfExitsAsync(Guid id, bool trackChanges)
    {
        DocumentType? documentType = await RepositoryManager.DocumentType.GetDocumentTypeAsync(id, trackChanges);
        if (documentType is null)
            throw new DocumentTypeNotFoundException(id);
        return documentType;
    }

    
}