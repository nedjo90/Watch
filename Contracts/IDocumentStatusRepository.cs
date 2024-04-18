using Entities.Models;

namespace Contracts;

public interface IDocumentStatusRepository
{
    Task<IEnumerable<DocumentStatus>> GetAllDocumentStatusAsync(bool trackChanges);
    void CreateDocumentStatusAsync(DocumentStatus documentStatus);
    public Task<DocumentStatus?> GetDocumentStatusById(Guid documentStatusId, bool trackChanges);

}