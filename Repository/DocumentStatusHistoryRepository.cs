using Contracts;
using Entities.Models;

namespace Repository;

public class DocumentStatusHistoryRepository: RepositoryBase<DocumentStatusHistory>, IDocumentStatusHistoryRepository
{
    public DocumentStatusHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}