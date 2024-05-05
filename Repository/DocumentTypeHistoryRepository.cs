using Contracts;
using Entities.Models;

namespace Repository;

public class DocumentTypeHistoryRepository : RepositoryBase<DocumentTypeHistory>, IDocumentTypeHistoryRepository
{
    public DocumentTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}