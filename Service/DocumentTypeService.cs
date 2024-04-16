using System.Collections;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared;

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
    public IEnumerable<DocumentTypeDto> GetAllDocumentTypes(bool trackChanges)
    {
        IEnumerable<DocumentType>? documentTypes = 
            _repositoryManager.DocumentType.GetAllDocumentTypes(trackChanges);
        IEnumerable<DocumentTypeDto>? documentTypesDto =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypes);
        return documentTypesDto;
    }

    public DocumentTypeDto GetDocumentType(Guid id, bool trackChanges)
    {
        DocumentType? documentType = _repositoryManager.DocumentType.GetDocumentType(id, trackChanges);
        if (documentType is null)
            throw new DocumentTypeNotFoundException(id);
        DocumentTypeDto documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
        return documentTypeDto;
    }

    public DocumentTypeDto CreateDocumentType(DocumentTypeForCreationDto documentTypeForCreationDto)
    {
        var documentTypeEntity = _mapper.Map<DocumentType>(documentTypeForCreationDto);
        
        _repositoryManager.DocumentType.CreateDocumentType(documentTypeEntity);
        _repositoryManager.Save();

        var documentTypeToReturn = _mapper.Map<DocumentTypeDto>(documentTypeEntity);

        return documentTypeToReturn;
    }

    public IEnumerable<DocumentTypeDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<DocumentType> documentTypeEntities =
            _repositoryManager.DocumentType.GetByIds(ids, trackChanges);
        if (ids.Count() != documentTypeEntities.Count())
            throw new CollectionByIdsBadRequestException();
        IEnumerable<DocumentTypeDto>? documentTypesToReturn =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypeEntities);
        return documentTypesToReturn;
    }

    public (IEnumerable<DocumentTypeDto> documentTypeDtos, string ids) CreateDocumentTypeCollection
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
        _repositoryManager.Save();

        IEnumerable<DocumentTypeDto>? documentTypeCollectionToReturn =
            _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypeEntities);
        string ids = string.Join(",", documentTypeCollectionToReturn.Select(c => c.Id));
        return (documentTypeCollectionToReturn, ids);
    }

    public void DeleteDocumentType(Guid documentTypeId, bool trackChanges)
    {
        DocumentType? documentType =
            _repositoryManager.DocumentType.GetDocumentType(documentTypeId, trackChanges);
        if (documentType is null)
            throw new DocumentTypeNotFoundException(documentTypeId);
        _repositoryManager.DocumentType.DeleteDocumentType(documentType);
        _repositoryManager.Save();
    }

    public void DeleteDocumentTypeCollection(IEnumerable<DocumentTypeDto> documentTypeIdDtos, bool trackChanges)
    {
        if (documentTypeIdDtos is null)
            throw new IdParametersBadRequestException();
        IEnumerable<Guid> ids = documentTypeIdDtos.Select(documentTypeIdDto => documentTypeIdDto.Id).ToList();
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<DocumentType> documentTypes = _repositoryManager.DocumentType.GetByIds(ids, trackChanges);
        if (ids.Count() != documentTypes.Count())
            throw new CollectionByIdsBadRequestException();
        foreach (DocumentType documentType in documentTypes)
        {
            Console.WriteLine(documentType.Id);
            _repositoryManager.DocumentType.DeleteDocumentType(documentType);
        }
        _repositoryManager.Save();
    }

    public void UpdateDocumentType(Guid documentTypeId, DocumentTypeForUpdateDto documentTypeForUpdateDto, bool trackChanges)
    {
        if (documentTypeForUpdateDto.Label is null)
            throw new NullObjectException(nameof(documentTypeForUpdateDto.Label));
        DocumentType? documentType = _repositoryManager.DocumentType.GetDocumentType(documentTypeId, trackChanges);
        if (documentType is null)
            throw new DocumentTypeNotFoundException(documentTypeId);
        _mapper.Map(documentTypeForUpdateDto, documentType);
        _repositoryManager.Save();
    }
}