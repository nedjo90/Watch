using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<DocumentType>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<DocumentType?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        DocumentType? documentType = await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        return documentType;
    }

    public async Task<DocumentType?> GetByLabelAsync(string label, bool trackChanges)
    {
        return await FindByCondition(e => e.Label!.Equals(label), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateAsync(DocumentType documentType)
    {
        Create(documentType);
    }

    public async Task<IEnumerable<DocumentType>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
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