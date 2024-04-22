using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BasicRepository<T> : RepositoryBase<T>, IBasicRepository<T> where T : BasicEntity
{
    public BasicRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
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
}