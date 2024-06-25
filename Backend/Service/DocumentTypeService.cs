using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentType;

namespace Service;

internal class DocumentTypeService : ServiceBase, IDocumentTypeService
{
    public DocumentTypeService(IHttpContextAccessor httpContextAccessor, IServiceManager serviceManager,
        IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,
        loggerManager, mapper)
    {
    }

    public async Task<DocumentType?> CheckIfIdExist(Guid? id, bool trackChanges)
    {
        return await RepositoryManager.DocumentTypeRepository.GetByIdAsync(id, trackChanges);
    }
    public async Task<DocumentTypeDto?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        DocumentType? documentType = await CheckIfIdExist(id, trackChanges);
        if (documentType == null)
            throw new IdNotFoundException(id, "Document Type");
        DocumentTypeDto documentTypeDto = Mapper.Map<DocumentTypeDto>(documentType);
        return documentTypeDto;
    }

    public async Task<IEnumerable<DocumentTypeDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<DocumentType> documentType =
            await RepositoryManager.DocumentTypeRepository.GetAllAsync(trackChanges);
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentType);
        return documentTypeDtos;
    }

    public async Task<IEnumerable<DocumentTypeDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<DocumentType> documentType =
            await RepositoryManager.DocumentTypeRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentType);
        return documentTypeDtos;
    }

    public async Task<DocumentTypeDto> CreateAsync(DocumentTypeForCreationDto documentTypeForCreationDto)
    {
        DocumentType? documentType = await CheckIfExistAndGetByLabel(documentTypeForCreationDto.Label!);
        if (documentType != null)
            throw new LabelAlreadyExistBadRequest("Document Type",documentTypeForCreationDto.Label!);
        documentType = Mapper.Map<DocumentType>(documentTypeForCreationDto);
        RepositoryManager.DocumentTypeRepository.CreateAsync(documentType);
        await ServiceManager.DocumentTypeHistoryService.RegisterModification(documentType, TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        DocumentTypeDto documentTypeDto = Mapper.Map<DocumentTypeDto>(documentType);
        return documentTypeDto;
    }
    
    public async Task<IEnumerable<DocumentTypeDto>> CreateCollectionAsync(IEnumerable<DocumentTypeForCreationDto> documentTypeForCreationDtos)
    {
        await ThrowIfListOfDocumentTypeForCreationIsNotValid(documentTypeForCreationDtos);
        IEnumerable<DocumentType?> documentType =
            Mapper.Map<IEnumerable<DocumentType>>(documentTypeForCreationDtos);
        foreach (DocumentType entity in documentType)
        {
            RepositoryManager.DocumentTypeRepository.CreateAsync(entity);
            await ServiceManager.DocumentTypeHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<DocumentTypeDto> documentTypeDtos =
            Mapper.Map<IEnumerable<DocumentTypeDto>>(documentType);
        return documentTypeDtos;
    }

    private async Task ThrowIfListOfDocumentTypeForCreationIsNotValid(
        IEnumerable<DocumentTypeForCreationDto> documentTypeForCreationDtos)
    {
        Dictionary<object, object> errors = new();
        foreach (DocumentTypeForCreationDto documentTypeForCreationDto in documentTypeForCreationDtos)
        {
            DocumentType? entity = await CheckIfExistAndGetByLabel(documentTypeForCreationDto.Label!);
            if (entity != null)
                errors.Add(documentTypeForCreationDto.Label!, "The label provided already exists.");
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Existing labels have been detected. Please adjust them to ensure the creation of a valid collection.", errors);
    }
    
    private async Task<DocumentType?> CheckIfExistAndGetByLabel(string label)
    {
        DocumentType? documentType = await RepositoryManager.DocumentTypeRepository.GetByLabelAsync(label, false);
        return documentType;
    }
}