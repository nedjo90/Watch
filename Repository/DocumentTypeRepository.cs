using Contracts;
using Entities.Models;
using Shared.RequestFeatures;

namespace Repository;

public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public Task<IEnumerable<DocumentType>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<DocumentType?> GetById(Guid? id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAsync(DocumentType newLabel)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DocumentType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void DeleteEntity(DocumentType entity)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<DocumentType>> GetAllPagingAsync(DocumentTypeParameters trainingTypeParameters, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}