using Contracts;
using Entities.Models;

namespace Repository;

public class LateMissDocumentRepository: RepositoryBase<LateMissDocument>, ILateMissDocumentRepository
{
    public LateMissDocumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}