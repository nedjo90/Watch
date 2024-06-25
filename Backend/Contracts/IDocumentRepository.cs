using Entities.Models;

namespace Contracts;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<Document>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<Document>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void CreateAsync(Document document);
}