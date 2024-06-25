using Entities.Models;
using Shared.DataTransfertObject.DocumentStatusHistory;

namespace Service.Contracts;

public interface IDocumentStatusHistoryService
{
    Task<IEnumerable<DocumentStatusHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( DocumentStatus documentStatus, string typeOfModification);
}