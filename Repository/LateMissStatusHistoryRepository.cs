using Contracts;
using Entities.Models;

namespace Repository;

public class LateMissStatusHistoryRepository : RepositoryBase<LateMissStatusHistory>, ILateMissStatusHistoryRepository
{
    public LateMissStatusHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}