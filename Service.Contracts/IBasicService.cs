using Entities.Models;
using Shared.Basic;
using Shared.BasicGeneric;
using Shared.LateMissStatus;

namespace Service.Contracts;

public interface IBasicService<TEntity, TMainDto, TCreationDto,TUpdateDto> 
    where TEntity : BasicGenericEntity
    where TMainDto : BasicGenericDto
    where TCreationDto : BasicGenericForCreationDto
    where TUpdateDto : BasicGenericForUpdateDto
{
    Task<IEnumerable<TMainDto>> GetAllAsync(bool trackChanges);
    Task<TMainDto> GetByIdAsync(Guid guid, bool trackChanges);
    Task<IEnumerable<TMainDto>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<TMainDto> CreateAsync(TCreationDto creationDto);
    Task<(IEnumerable<TMainDto> mainDtos, string ids)> CreateCollectionAsync
        (IEnumerable<TCreationDto> collectionForCreation);
    Task DeleteCollectionAsync(IEnumerable<TMainDto> mainDtos, bool trackChanges);
    Task DeleteAsync(Guid id, bool trackChanges);
    Task UpdateAsync(Guid guid, TUpdateDto updateDto, bool trackChanges);
    Task<(TUpdateDto updateDto, TEntity entity)> PatchAsync(Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(TUpdateDto updateDto, TEntity entity);
}