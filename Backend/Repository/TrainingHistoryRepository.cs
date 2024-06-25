using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class TrainingHistoryRepository: RepositoryBase<TrainingHistory>, ITrainingHistoryRepository
{
    public TrainingHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<TrainingHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegistreModification(TrainingHistory trainingHistory)
    {
        Create(trainingHistory);
    }
}