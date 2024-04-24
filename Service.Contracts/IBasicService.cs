using Entities.LinkModels;
using Entities.Models;
using Shared.BasicGeneric;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IBasicService<TEntity, TMainDto, TCreationDto,TUpdateDto> 
    where TEntity : BasicGenericEntity
    where TMainDto : BasicGenericDto
    where TCreationDto : BasicGenericForCreationDto
    where TUpdateDto : BasicGenericForUpdateDto
{
    Task<IEnumerable<TMainDto>> GetAllAsync(bool trackChanges = false);
    Task<TMainDto> GetByIdAsync(Guid guid, bool trackChanges = false);
    Task<IEnumerable<TMainDto>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges = false);
    Task<TMainDto> CreateAsync(TCreationDto creationDto);
    Task<(IEnumerable<TMainDto> mainDtos, string ids)> CreateCollectionAsync
        (IEnumerable<TCreationDto> collectionForCreation);
    Task DeleteCollectionAsync(IEnumerable<TMainDto> mainDtos, bool trackChanges = false);
    Task DeleteAsync(Guid id, bool trackChanges = false);
    Task UpdateAsync(Guid guid, TUpdateDto updateDto, bool trackChanges = true);
    Task<(TUpdateDto updateDto, TEntity entity)> PatchAsync(Guid id, bool trackChanges = true);
    Task SaveChangesForPatchAsync(TUpdateDto updateDto, TEntity entity);
    Task<(LinkResponse linkResponse, MetaData metadata)> GetAllPagingAsync(LinkParameters linkParameters,
        string url = "", bool trackChanges = false);
}