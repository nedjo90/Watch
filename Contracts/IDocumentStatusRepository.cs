using Entities.Models;
using Shared.DocumentStatus;

namespace Contracts;

public interface IDocumentStatusRepository
{
    Task<IEnumerable<DocumentStatus>> GetAllDocumentStatusAsync(bool trackChanges);
    public Task<DocumentStatus?> GetDocumentStatusByIdAsync(Guid documentStatusId, bool trackChanges);
    void CreateDocumentStatusAsync(DocumentStatus documentStatus);
    public Task<IEnumerable<DocumentStatus>> GetDocumentStatusCollection
        (IEnumerable<Guid> guids, bool trackChanges);
    public void DeleteDocumentStatus(DocumentStatus documentStatus);
}