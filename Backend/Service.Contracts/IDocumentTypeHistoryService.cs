using Entities.Models;
using Shared.DataTransfertObject.DocumentTypeHistory;

namespace Service.Contracts;

public interface IDocumentTypeHistoryService 
{
    Task<IEnumerable<DocumentTypeHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification(DocumentType documentType, string typeOfModification);
}