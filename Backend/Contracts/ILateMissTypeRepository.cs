using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ILateMissTypeRepository
{
    Task<IEnumerable<LateMissType>> GetAllAsync(bool trackChanges);
    Task<LateMissType?> GetById(Guid? id, bool trackChanges);
    Task<LateMissType?> GetByLabelAsync(string? label, bool trackChanges);
    Task<IEnumerable<LateMissType>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void CreateAsync(LateMissType lateMissType);
    void DeleteEntity(LateMissType entity);
    Task<PagedList<LateMissType>> GetAllPagingAsync(LateMissTypeParameters trainingTypeParameters, bool trackChanges);
}