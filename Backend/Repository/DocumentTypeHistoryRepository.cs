using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class DocumentTypeHistoryRepository : RepositoryBase<DocumentTypeHistory>, IDocumentTypeHistoryRepository
{
    public DocumentTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<DocumentTypeHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterModification(DocumentTypeHistory documentTypeHistory)
    {
        Create(documentTypeHistory);
    }
}