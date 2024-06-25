using Entities.Models;
using Shared.DataTransfertObject.LateMissStatusHistory;

namespace Service.Contracts;

public interface ILateMissStatusHistoryService 
{
    Task<IEnumerable<LateMissStatusHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( LateMissStatus lateMissStatus, string typeOfModification);
}