using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class LateMissTypeRepository : RepositoryBase<LateMissType>, ILateMissTypeRepository
{
    public LateMissTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LateMissType>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<LateMissType?> GetById(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public async Task<LateMissType?> GetByLabelAsync(string? label, bool trackChanges)
    {
        return await FindByCondition(e => e.Label.Equals(label), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateAsync(LateMissType lateMissType)
    {
        Create(lateMissType);
    }

    public async Task<IEnumerable<LateMissType>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void DeleteEntity(LateMissType entity)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<LateMissType>> GetAllPagingAsync(LateMissTypeParameters trainingTypeParameters, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}