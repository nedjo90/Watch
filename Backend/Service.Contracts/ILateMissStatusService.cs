using Entities.Models;
using Shared.DataTransfertObject.LateMissStatus;

namespace Service.Contracts;

public interface ILateMissStatusService
{
    Task<IEnumerable<LateMissStatusDto>> GetAllAsync(bool trackChanges);
    Task<LateMissStatusDto?> GetByIdAsync(Guid? id, bool trackChanges);
    public Task<LateMissStatus?> CheckIfExistAndGetById(Guid? id, bool trackChanges);
    Task<IEnumerable<LateMissStatusDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<LateMissStatusDto> CreateAsync(LateMissStatusForCreationDto lateMissStatusForCreationDto);
    Task<IEnumerable<LateMissStatusDto>> CreateCollectionAsync(IEnumerable<LateMissStatusForCreationDto> lateMissStatusForCreationDtos);
}