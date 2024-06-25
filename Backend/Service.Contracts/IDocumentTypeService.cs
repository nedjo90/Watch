using Entities.Models;
using Shared.DataTransfertObject.DocumentType;

namespace Service.Contracts;

public interface IDocumentTypeService
{
    Task<DocumentType?> CheckIfIdExist(Guid? id, bool trackChanges);
    Task<DocumentTypeDto?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<IEnumerable<DocumentTypeDto>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<DocumentTypeDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<DocumentTypeDto> CreateAsync(DocumentTypeForCreationDto documentTypeForCreationDto);
    Task<IEnumerable<DocumentTypeDto>> CreateCollectionAsync(IEnumerable<DocumentTypeForCreationDto> documentTypeForCreationDtos);
}