using Entities.Models;
using Shared.DataTransfertObject.DocumentStatus;

namespace Service.Contracts;

public interface IDocumentStatusService
{
    Task<DocumentStatus?> CheckIfIdExist(Guid? id, bool trackChanges);
    Task<DocumentStatusDto?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<IEnumerable<DocumentStatusDto>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<DocumentStatusDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    
    Task<DocumentStatusDto> CreateAsync(DocumentStatusForCreationDto documentStatusForCreationDto);
    Task<IEnumerable<DocumentStatusDto>> CreateCollectionAsync(IEnumerable<DocumentStatusForCreationDto> documentStatusForCreationDtos);
}