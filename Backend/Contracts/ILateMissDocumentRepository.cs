using Entities.Models;

namespace Contracts;

public interface ILateMissDocumentRepository
{
    Task<IEnumerable<LateMissDocument>> GetAllAsync(bool trackChanges);
    Task<LateMissDocument?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<IEnumerable<LateMissDocument>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void CreateAsync(LateMissDocument lateMissDocument);
}