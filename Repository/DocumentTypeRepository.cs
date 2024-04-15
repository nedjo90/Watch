using Contracts;
using Entities.Models;

namespace Repository;

public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<DocumentType> GetAllDocumentTypes(bool trackChanges)
    {
        return FindAll(trackChanges)
            .OrderBy(c => c.Label)
            .ToList();
    }
}