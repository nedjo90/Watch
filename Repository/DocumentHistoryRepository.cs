using Contracts;
using Entities.Models;

namespace Repository;

public class DocumentHistoryRepository : RepositoryBase<DocumentHistory>, IDocumentHistoryRepository
{
    public DocumentHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}