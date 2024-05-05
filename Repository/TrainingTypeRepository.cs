using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class TrainingTypeRepository : RepositoryBase<TrainingType>,ITrainingTypeRepository
{
    public TrainingTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<TrainingType>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(e => e.Label).ToListAsync();
    }
    public async Task<TrainingType?> GetById(Guid? guid, bool trackChanges)
    {
        return await FindByCondition(e =>
                    e.Id.Equals(guid)
                , trackChanges)
            .SingleOrDefaultAsync();
    }
    
    public void CreateAsync(TrainingType newLabel)
    {
        Create(newLabel);
        
    }

    public async Task<IEnumerable<TrainingType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges)
            .OrderBy(e => e.Label)
            .ToListAsync();
    }

    public void DeleteEntity(TrainingType entity)
    {
        Delete(entity);
    }
    
    public async Task<PagedList<TrainingType>> GetAllPagingAsync
    (TrainingTypeParameters trainingTypeParameters,
        bool trackChanges)
    {
        throw new Exception();
    }
}