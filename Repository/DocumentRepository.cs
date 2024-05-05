using Contracts;
using Entities.Models;

namespace Repository;

public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
{
    public DocumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}