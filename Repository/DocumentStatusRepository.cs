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

    public async Task<DocumentStatus?> GetDocumentStatusById(Guid documentStatusId, bool trackChanges)
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
}