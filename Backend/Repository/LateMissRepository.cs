using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LateMissRepository: RepositoryBase<LateMiss>, ILateMissRepository
{
    public LateMissRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<LateMiss?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        var lateMiss = await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        return lateMiss;
    }

    public async Task<IEnumerable<LateMiss>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<LateMiss>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void CreateAsync(LateMiss lateMiss)
    {
        Create(lateMiss);
    }
}