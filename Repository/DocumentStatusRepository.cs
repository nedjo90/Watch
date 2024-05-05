using Contracts;
using Entities.Models;
using Shared.RequestFeatures;

namespace Repository;

public class DocumentStatusRepository : RepositoryBase<DocumentStatus>,IDocumentStatusRepository
{
    public DocumentStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public Task<IEnumerable<DocumentStatus>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<DocumentStatus?> GetById(Guid? id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAsync(DocumentStatus newLabel)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DocumentStatus>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void DeleteEntity(DocumentStatus entity)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<DocumentStatus>> GetAllPagingAsync(DocumentStatusParameters trainingTypeParameters, bool trackChanges)
    {
        throw new NotImplementedException();
    }

}