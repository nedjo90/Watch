using Entities.Models;

namespace Contracts;

public interface ILateMissHistoryRepository
{
    Task<IEnumerable<LateMissHistory>> GetAllAsync(bool trackChanges);
    void RegisterModification(LateMissHistory lateMissHistory);
}