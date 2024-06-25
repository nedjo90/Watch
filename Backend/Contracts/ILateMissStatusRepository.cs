using Entities.Models;
using Shared.DataTransfertObject.LateMissStatus;
using Shared.RequestFeatures;

namespace Contracts;

public interface ILateMissStatusRepository
{
    Task<IEnumerable<LateMissStatus>> GetAllAsync(bool trackChanges);
    Task<LateMissStatus?> GetById(Guid? id, bool trackChanges);
    Task<LateMissStatus?> GetByLabelAsync(string? label, bool trackChanges);
    void CreateAsync(LateMissStatus lateMissStatus);
    Task<IEnumerable<LateMissStatus>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void DeleteEntity(LateMissStatus entity);
    Task<PagedList<LateMissStatus>> GetAllPagingAsync(LateMissStatusParameters trainingTypeParameters, bool trackChanges);
}