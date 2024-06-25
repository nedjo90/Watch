using Entities.Models;
using Shared.DataTransfertObject.LateMissType;

namespace Service.Contracts;

public interface ILateMissTypeService
{
    Task<IEnumerable<LateMissTypeDto>> GetAllAsync(bool trackChanges);
    Task<LateMissTypeDto?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<LateMissType?> CheckIfExistAndGetById(Guid? id, bool trackChanges);
    Task<IEnumerable<LateMissTypeDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<LateMissTypeDto> CreateAsync(LateMissTypeForCreationDto lateMissTypeForCreationDto);
    Task<IEnumerable<LateMissTypeDto>> CreateCollectionAsync(IEnumerable<LateMissTypeForCreationDto> lateMissTypeForCreationDtos);
}