using Entities.Models;
using Shared.DataTransfertObject.LateMiss;

namespace Service.Contracts;

public interface ILateMissService
{
    Task<LateMissDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<LateMissDto>> GetAllAsync(bool trackChanges);
    Task<LateMiss?> CheckIfExistAndGetByIdAsync(Guid? lateMiss);
    Task<IEnumerable<LateMissDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<LateMissDto> CreateAsync(LateMissForCreationDto lateMissForCreationDto);
    Task<IEnumerable<LateMissDto>> CreateCollectionAsync(
        IEnumerable<LateMissForCreationDto> lateMissForCreationDtos);
}