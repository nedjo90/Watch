using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class TrainingTypeHistoryRepository: RepositoryBase<TrainingTypeHistory>, ITrainingTypeHistoryRepository
{
    public TrainingTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<TrainingTypeHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegistreModification(TrainingTypeHistory trainingTypeHistory)
    {
        Create(trainingTypeHistory);
    }
}