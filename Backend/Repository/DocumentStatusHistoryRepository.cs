using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class DocumentStatusHistoryRepository: RepositoryBase<DocumentStatusHistory>, IDocumentStatusHistoryRepository
{
    public DocumentStatusHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<DocumentStatusHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterModification(DocumentStatusHistory documentStatusHistory)
    {
        Create(documentStatusHistory);
    }
}