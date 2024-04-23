using System.Linq.Dynamic.Core;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BasicGenericRepository<T> : RepositoryBase<T>, IBasicGenericRepository<T> where T : BasicGenericEntity
{
    public BasicGenericRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(e => e.Label).ToListAsync();
    }
    public async Task<T?> GetById(Guid guid, bool trackChanges)
    {
        return await FindByCondition(e =>
            e.Id.Equals(guid)
            , trackChanges)
            .SingleOrDefaultAsync();
    }
    
    public void CreateAsync(T newLabel)
    {
        Create(newLabel);
    }

    public async Task<IEnumerable<T>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges)
            .OrderBy(e => e.Label)
            .ToListAsync();
    }

    public void DeleteEntity(T entity)
    {
        Delete(entity);
    }
}