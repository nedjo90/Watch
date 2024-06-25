using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LateMissHistoryRepository: RepositoryBase<LateMissHistory>, ILateMissHistoryRepository
{
    public LateMissHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterModification(LateMissHistory lateMissHistory)
    {
        Create(lateMissHistory);
    }
}