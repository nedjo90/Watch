using Entities.Models;

namespace Contracts;

public interface ILateMissRepository
{
    Task<LateMiss?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<IEnumerable<LateMiss>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<LateMiss>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void CreateAsync(LateMiss lateMiss);
}