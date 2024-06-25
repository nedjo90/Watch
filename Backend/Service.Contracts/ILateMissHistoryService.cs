using Entities.Models;
using Shared.DataTransfertObject.LateMissHistory;

namespace Service.Contracts;

public interface ILateMissHistoryService
{
    Task<IEnumerable<LateMissHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( LateMiss lateMiss, string typeOfModification);
}