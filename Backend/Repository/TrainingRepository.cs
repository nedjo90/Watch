using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class TrainingRepository : RepositoryBase<Training>,ITrainingRepository
{
    public TrainingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Training>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public Task<Training?> GetByIdAsync(Guid id, bool trackChanges)
    {
        return FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateTraining(Training training)
    {
        Create(training);
    }
}