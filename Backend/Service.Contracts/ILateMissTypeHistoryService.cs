using Entities.Models;
using Shared.DataTransfertObject.LateMissTypeHistory;

namespace Service.Contracts;

public interface ILateMissTypeHistoryService
{
    Task<IEnumerable<LateMissTypeHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( LateMissType lateMissType, string typeOfModification);
}