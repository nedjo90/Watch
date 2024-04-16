using System.IO.Pipes;
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
            _repositoryManager.DocumentType?.GetAllDocumentTypes(trackChanges);
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
        DocumentType? documentTypeEntity = _mapper.Map<DocumentType>(documentTypeForCreationDto);
        
        _repositoryManager.DocumentType.CreateDocumentType(documentTypeEntity);
        _repositoryManager.Save();

        DocumentTypeDto? documentTypeToReturn = _mapper.Map<DocumentTypeDto>(documentTypeEntity);

        return documentTypeToReturn;

    }
}