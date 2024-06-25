using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LateMissDocumentRepository: RepositoryBase<LateMissDocument>, ILateMissDocumentRepository
{
    public LateMissDocumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissDocument>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<LateMissDocument?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<LateMissDocument>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void CreateAsync(LateMissDocument lateMissDocument)
    {
        Create(lateMissDocument);
    }
}