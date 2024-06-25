using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LateMissDocumentHistoryRepository: RepositoryBase<LateMissDocumentHistory>, ILateMissDocumentHistoryRepository
{
    public LateMissDocumentHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissDocumentHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterModification(LateMissDocumentHistory lateMissDocumentHistory)
    {
        Create(lateMissDocumentHistory);
    }
}