using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class BasicGenericRepository<TEntity> 
    // : RepositoryBase<TEntity>, IBasicGenericRepository<TEntity> 
    // where TEntity : BasicGenericEntity
{
    // public BasicGenericRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    // {
    // }
    //
    // public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges)
    // {
    //     return await FindAll(trackChanges).OrderBy(e => e.Label).ToListAsync();
    // }
    // public async Task<TEntity?> GetById(Guid guid, bool trackChanges)
    // {
    //     return await FindByCondition(e =>
    //         e.Id.Equals(guid)
    //         , trackChanges)
    //         .SingleOrDefaultAsync();
    // }
    //
    // public void CreateAsync(TEntity newLabel)
    // {
    //     Create(newLabel);
    // }
    //
    // public async Task<IEnumerable<TEntity>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    // {
    //     return await FindByCondition(e => ids.Contains(e.Id), trackChanges)
    //         .OrderBy(e => e.Label)
    //         .ToListAsync();
    // }
    //
    // public void DeleteEntity(TEntity entity)
    // {
    //     Delete(entity);
    // }
    //
    // public async Task<PagedList<TEntity>> GetAllPagingAsync
    // (BasicGenericParameters basicGenericParameters,
    //     bool trackChanges)
    // {
    //     IEnumerable<TEntity> entities = await FindAll(trackChanges)
    //         .Search(basicGenericParameters.SearchTerm ?? string.Empty)
    //         .Sort(basicGenericParameters.OrderBy ?? string.Empty)
    //         .ToListAsync();
    //     int count = await FindAll(trackChanges)
    //         .Search(basicGenericParameters.SearchTerm ?? string.Empty)
    //         .CountAsync();
    //     return PagedList<TEntity>
    //         .ToPagedList(entities, count,basicGenericParameters.PageNumber, basicGenericParameters.PageSize);
    // }
}