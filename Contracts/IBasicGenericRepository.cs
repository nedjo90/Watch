using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IBasicGenericRepository<TEntity> 
    where TEntity : BasicGenericEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
    Task<TEntity?> GetById(Guid id, bool trackChanges = false);
    void CreateAsync(TEntity newLabel);
    Task<IEnumerable<TEntity>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges = false);
    void DeleteEntity(TEntity entity);
    Task<PagedList<TEntity>> GetAllPagingAsync(BasicGenericParameters basicGenericParameters, bool trackChanges = false);
}