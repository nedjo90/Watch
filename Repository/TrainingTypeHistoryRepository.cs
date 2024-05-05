using Contracts;
using Entities.Models;

namespace Repository;

public class TrainingTypeHistoryRepository: RepositoryBase<TrainingTypeHistory>, ITrainingTypeHistoryRepository
{
    public TrainingTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}