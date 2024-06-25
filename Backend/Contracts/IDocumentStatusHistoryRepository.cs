using Entities.Models;

namespace Contracts;

public interface IDocumentStatusHistoryRepository
{
    Task<IEnumerable<DocumentStatusHistory>> GetAllAsync(bool trackChanges);
    void RegisterModification(DocumentStatusHistory documentStatusHistory);
}