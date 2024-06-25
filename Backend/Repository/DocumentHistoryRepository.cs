using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransfertObject.Document;
using Shared.DataTransfertObject.DocumentHistory;

namespace Repository;

public class DocumentHistoryRepository : RepositoryBase<DocumentHistory>, IDocumentHistoryRepository
{
    public DocumentHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<DocumentHistory>> GetAllAsync(bool trackChanges)
    {
        return
            await FindAll(trackChanges).ToListAsync();
    }

    public void RegisterForModification(DocumentHistory documentHistory)
    {
        Create(documentHistory);
    }
}