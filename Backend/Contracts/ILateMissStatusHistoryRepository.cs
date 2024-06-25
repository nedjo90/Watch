using Entities.Models;

namespace Contracts;

public interface ILateMissStatusHistoryRepository 
{
    Task<IEnumerable<LateMissStatusHistory>> GetAllAsync(bool trackChanges);
    void RegisterModification(LateMissStatusHistory lateMissStatusHistory);
}