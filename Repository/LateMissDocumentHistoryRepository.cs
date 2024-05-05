using Contracts;
using Entities.Models;

namespace Repository;

public class LateMissDocumentHistoryRepository: RepositoryBase<LateMissDocumentHistory>, ILateMissDocumentHistoryRepository
{
    public LateMissDocumentHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}