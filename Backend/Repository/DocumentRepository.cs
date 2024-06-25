using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
{
    public DocumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<Document?> GetByIdAsync(Guid id, bool trackChanges)
    {
        return
            await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Document>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Document>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void CreateAsync(Document document)
    {
        Create(document);
    }
}