using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LateMissTypeHistoryRepository: RepositoryBase<LateMissTypeHistory>, ILateMissTypeHistoryRepository
{
    public LateMissTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissTypeHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterModification(LateMissTypeHistory lateMissTypeHistory)
    {
        Create(lateMissTypeHistory);
    }
}