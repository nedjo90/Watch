using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class DocumentStatusRepository : RepositoryBase<DocumentStatus>,IDocumentStatusRepository
{
    public DocumentStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<DocumentStatus>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<DocumentStatus?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public async Task<DocumentStatus?> GetByLabelAsync(string? label, bool trackChanges)
    {
        return await FindByCondition(e => e.Label.Equals(label), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateAsync(DocumentStatus documentStatus)
    {
        Create(documentStatus);
    }

    public async Task<IEnumerable<DocumentStatus>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
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