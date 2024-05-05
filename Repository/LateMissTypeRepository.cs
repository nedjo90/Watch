using Contracts;
using Entities.Models;
using Shared.RequestFeatures;

namespace Repository;

public class LateMissTypeRepository : RepositoryBase<LateMissType>, ILateMissTypeRepository
{
    public LateMissTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public Task<IEnumerable<LateMissType>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<LateMissType?> GetById(Guid? id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAsync(LateMissType newLabel)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LateMissType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
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