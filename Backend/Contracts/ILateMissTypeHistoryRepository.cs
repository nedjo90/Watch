using Entities.Models;

namespace Contracts;

public interface ILateMissTypeHistoryRepository
{
    Task<IEnumerable<LateMissTypeHistory>> GetAllAsync(bool trackChanges);
    void RegisterModification(LateMissTypeHistory lateMissTypeHistory);
}