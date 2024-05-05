using Contracts;
using Entities.Models;

namespace Repository;

public class LateMissTypeHistoryRepository: RepositoryBase<LateMissTypeHistory>, ILateMissTypeHistoryRepository
{
    public LateMissTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}