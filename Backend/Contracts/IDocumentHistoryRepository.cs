using Entities.Models;
using Shared.DataTransfertObject.Document;
using Shared.DataTransfertObject.DocumentHistory;

namespace Contracts;

public interface IDocumentHistoryRepository
{
    Task<IEnumerable<DocumentHistory>> GetAllAsync(bool trackChanges);

    void RegisterForModification(DocumentHistory documentHistory);
}