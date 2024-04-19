using Entities.Models;
using Shared;
using Shared.DocumentStatus;

namespace Service.Contracts;

public interface IDocumentStatusService
{
    Task<IEnumerable<DocumentStatusDto>> GetAllDocumentStatusAsync(bool trackChanges);
    Task<DocumentStatusDto> CreateDocumentStatusAsync
        (DocumentStatusForCreationDto documentStatusForCreationDto);
    Task<DocumentStatusDto> GetDocumentStatusByIdAsync(Guid documentStatusId, bool trackChanges);
    Task<IEnumerable<DocumentStatusDto>> GetDocumentStatusCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<DocumentStatusDto>, string ids)> CreateDocumentStatusCollection
        (IEnumerable<DocumentStatusForCreationDto> documentStatusCollection);
    Task DeleteDocumentStatusAsync(Guid id, bool trackChanges);

    Task DeleteDocumentStatusCollectionAsync(IEnumerable<DocumentStatusDto> ids, bool trackChanges);

    Task UpdateDocumentStatusAsync(Guid guid, DocumentStatusForUpdateDto documentStatusForUpdateDto, bool trackChanges);

    Task<(DocumentStatusForUpdateDto documentStatusToPatch, DocumentStatus entity)> GetDocumentStatusForPatchAsync
        (Guid documentStatusId, bool trackChanges);
    Task SaveChangesForPatchAsync
        (DocumentStatusForUpdateDto documentStatusToPatch, DocumentStatus entity);
}