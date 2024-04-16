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

    public DocumentType GetDocumentType(Guid documentTypeId, bool trackChanges)
    {
        return 
            FindByCondition
                (c => c.Id.Equals(documentTypeId), trackChanges)
                .SingleOrDefault();
    }

    public void CreateDocumentType(DocumentType? documentType)
    {
        Create(documentType);
    }

    public IEnumerable<DocumentType> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        return FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
    }

    public void DeleteDocumentType(DocumentType documentType)
    {
        Delete(documentType);
    }
}