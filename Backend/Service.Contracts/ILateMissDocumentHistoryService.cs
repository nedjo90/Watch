using Entities.Models;
using Shared.DataTransfertObject.LateMissDocumentHistory;

namespace Service.Contracts;

public interface ILateMissDocumentHistoryService 
{
    Task<IEnumerable<LateMissDocumentHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( LateMissDocument lateMissDocument, string typeOfModification);
}