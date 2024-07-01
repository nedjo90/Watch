using Entities.Models;
using Shared.DataTransfertObject.DocumentHistory;

namespace Service.Contracts;

public interface IDocumentHistoryService
{
    Task<IEnumerable<DocumentHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification(Document document, string typeOfModification, string? userId = null);
}