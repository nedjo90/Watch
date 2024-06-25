using Entities.Models;

namespace Contracts;

public interface IDocumentTypeHistoryRepository 
{
    Task<IEnumerable<DocumentTypeHistory>> GetAllAsync(bool trackChanges);
    void RegisterModification(DocumentTypeHistory documentTypeHistory);
}