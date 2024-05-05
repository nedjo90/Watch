using Contracts;
using Entities.Models;

namespace Repository;

public class LateMissHistoryRepository: RepositoryBase<LateMissHistory>, ILateMissHistoryRepository
{
    public LateMissHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}