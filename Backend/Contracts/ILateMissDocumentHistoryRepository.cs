using Entities.Models;

namespace Contracts;

public interface ILateMissDocumentHistoryRepository 
{
    Task<IEnumerable<LateMissDocumentHistory>> GetAllAsync(bool trackChanges);
    void RegisterModification(LateMissDocumentHistory lateMissDocumentHistory);
}