using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.Document;

namespace Service;
internal class DocumentService : ServiceBase, IDocumentService
{
    public DocumentService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<DocumentDto> GetByIdAsync(Guid id, bool trackChanges)
    {
        Document? document =
            await RepositoryManager.DocumentRepository.GetByIdAsync(id, trackChanges);
        if (document is null)
            throw new IdNotFoundException(id, "Document");
        DocumentDto documentDto = Mapper.Map<DocumentDto>(document);
        return documentDto;
    }

    public async Task<IEnumerable<DocumentDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<Document> documentes =
            await RepositoryManager.DocumentRepository.GetAllAsync(trackChanges);
        IEnumerable<DocumentDto> documentDtos =
            Mapper.Map<IEnumerable<DocumentDto>>(documentes);
        return documentDtos;
    }

    public async Task<IEnumerable<DocumentDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<Document> document =
            await RepositoryManager.DocumentRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<DocumentDto> documentDtos =
            Mapper.Map<IEnumerable<DocumentDto>>(document);
        return documentDtos;
    }

    public async Task<DocumentDto> CreateAsync(DocumentForCreationDto documentForCreationDto)
    {
        await ThrowIfDocumentForCreationIsNotValid(documentForCreationDto);
        Document document = Mapper.Map<Document>(documentForCreationDto);
        RepositoryManager.DocumentRepository.CreateAsync(document);
        await ServiceManager.DocumentHistoryService.RegisterModification(document,
            TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        DocumentDto documentDto = Mapper.Map<DocumentDto>(document);
        return documentDto;
    }

    public async Task<IEnumerable<DocumentDto>> CreateCollectionAsync(IEnumerable<DocumentForCreationDto> documentForCreationDtos)
    {
        await ThrowIfListOfDocumentForCreationIsNotValid(documentForCreationDtos);
        IEnumerable<Document?> document =
            Mapper.Map<IEnumerable<Document>>(documentForCreationDtos);
        foreach (Document entity in document)
        {
            RepositoryManager.DocumentRepository.CreateAsync(entity);
            await ServiceManager.DocumentHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<DocumentDto> documentDtos =
            Mapper.Map<IEnumerable<DocumentDto>>(document);
        return documentDtos;
    }

    private async Task ThrowIfDocumentForCreationIsNotValid(DocumentForCreationDto documentForCreationDto)
    {
        List<object> errors = new ();
        if(await ServiceManager.DocumentStatusService.CheckIfIdExist(documentForCreationDto.DocumentStatusId, false) == null)
            errors.Add("Document Status Id doesn't exist.");
        if (await ServiceManager.DocumentTypeService.CheckIfIdExist(documentForCreationDto.DocumentTypeId, false) == null)
            errors.Add("Document Type Id doesn't exist.");
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Non-existent ID(s) detected. Please provide valid ID(s).", errors);
    }
    private async Task ThrowIfListOfDocumentForCreationIsNotValid(IEnumerable<DocumentForCreationDto> documentForCreationDtos)
    {
        Dictionary<object, object> errors = new ();
        foreach (DocumentForCreationDto documentForCreationDto in documentForCreationDtos)
        {
            List<object> specificErrors = new ();
            if(await ServiceManager.DocumentStatusService.CheckIfIdExist(documentForCreationDto.DocumentStatusId, false) == null)
                specificErrors.Add(new{ documentForCreationDto.DocumentStatusId, Detail = "Document Status Id doesn't exist."} );
            if (await ServiceManager.DocumentTypeService.CheckIfIdExist(documentForCreationDto.DocumentTypeId, false) == null)
                specificErrors.Add(new{ documentForCreationDto.DocumentTypeId, Detail = "Document Type Id doesn't exist."});
            if (specificErrors.Count > 0)
                errors.Add(documentForCreationDto, specificErrors);
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException(
                "Invalid document information detected. Please provide valid informations.", errors);
    }
}