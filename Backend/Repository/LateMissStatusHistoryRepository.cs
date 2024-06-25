using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LateMissStatusHistoryRepository : RepositoryBase<LateMissStatusHistory>, ILateMissStatusHistoryRepository
{
    public LateMissStatusHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissStatusHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterModification(LateMissStatusHistory lateMissStatusHistory)
    {
        Create(lateMissStatusHistory);
    }
}