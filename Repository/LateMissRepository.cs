using Contracts;
using Entities.Models;

namespace Repository;

public class LateMissRepository: RepositoryBase<LateMiss>, ILateMissRepository
{
    public LateMissRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}