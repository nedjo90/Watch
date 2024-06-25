using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class LateMissStatusRepository : RepositoryBase<LateMissStatus>, ILateMissStatusRepository
{
    public LateMissStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissStatus>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<LateMissStatus?> GetById(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public async Task<LateMissStatus?> GetByLabelAsync(string? label, bool trackChanges)
    {
        return await FindByCondition(e => e.Label.Equals(label), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateAsync(LateMissStatus lateMissStatus)
    {
        Create(lateMissStatus);
    }

    public async Task<IEnumerable<LateMissStatus>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void DeleteEntity(LateMissStatus entity)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<LateMissStatus>> GetAllPagingAsync(LateMissStatusParameters trainingTypeParameters, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}