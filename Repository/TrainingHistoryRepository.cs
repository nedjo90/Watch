using Contracts;
using Entities.Models;

namespace Repository;

public class TrainingHistoryRepository: RepositoryBase<TrainingHistory>, ITrainingHistoryRepository
{
    public TrainingHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}