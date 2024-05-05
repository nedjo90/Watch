using Contracts;
using Entities.Models;
using Shared.RequestFeatures;

namespace Repository;

public class LateMissStatusRepository : RepositoryBase<LateMissStatus>, ILateMissStatusRepository
{
    public LateMissStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public Task<IEnumerable<LateMissStatus>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<LateMissStatus?> GetById(Guid? id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAsync(LateMissStatus newLabel)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LateMissStatus>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
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