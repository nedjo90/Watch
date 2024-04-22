using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DocumentType;

namespace Repository;

public class DocumentStatusRepository : RepositoryBase<DocumentStatus>, IDocumentStatusRepository
{
    public DocumentStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

    public async Task<IEnumerable<DocumentStatus>> GetAllDocumentStatusAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Label)
            .ToListAsync();
    }

    public async Task<DocumentStatus?> GetDocumentStatusByIdAsync(Guid documentStatusId, bool trackChanges)
    {
        return await 
            FindByCondition(e => 
                e.Id.Equals(documentStatusId), trackChanges)
                .SingleOrDefaultAsync();
    }
    
    
    public void CreateDocumentStatusAsync(DocumentStatus documentStatus)
    {
        Create(documentStatus);
    }

    public async Task<IEnumerable<DocumentStatus>> GetDocumentStatusCollection
        (IEnumerable<Guid> guids, bool trackChanges)
    {
        return await 
            FindByCondition(e => guids.Contains(e.Id), trackChanges)
            .ToListAsync();
    }

    public void DeleteDocumentStatus(DocumentStatus documentStatus)
    {
        Delete(documentStatus);
    }
    
}