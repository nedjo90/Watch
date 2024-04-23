using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Basic;
using Shared.BasicGeneric;

namespace Service;

internal class BasicService<TEntity, TMainDto, TCreationDto, TUpdateDto> 
    : ServiceBaseGeneric<TEntity>, 
        IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto>
    where TEntity : BasicGenericEntity
    where TMainDto : BasicGenericDto
    where TCreationDto : BasicGenericForCreationDto
    where TUpdateDto : BasicGenericForUpdateDto
{
    public BasicService(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric,
        ILoggerManager loggerManager,
        IMapper mapper, 
        IDocumentTypeLinks documentTypeLinks) 
        : base(repositoryManagerGeneric, loggerManager, mapper, documentTypeLinks)
    {
    }

    public async Task<IEnumerable<TMainDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<TEntity> entities =
            await RepositoryManagerGeneric.BasicGenericRepository.GetAllAsync(trackChanges);
        IEnumerable<TMainDto> mainDtos =
            Mapper.Map<IEnumerable<TMainDto>>(entities);
        return mainDtos;
    }

    public async Task<TMainDto> GetByIdAsync(Guid guid, bool trackChanges)
    {
        TEntity? entity = await RepositoryManagerGeneric.BasicGenericRepository.GetById(guid, trackChanges);
        if (entity is null)
            throw new NotFoundException($"{guid} doesn't exist.");
        TMainDto? mainDto = Mapper.Map<TMainDto>(entity);
        return mainDto;
    }

    public async Task<IEnumerable<TMainDto>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();            
        IEnumerable<TEntity> entities =
            await RepositoryManagerGeneric.BasicGenericRepository.GetCollectionAsync(ids, trackChanges);
        if (ids.Count() != entities.Count())
            throw new CollectionByIdsBadRequestException();
        IEnumerable<TMainDto> mainDtos =
            Mapper.Map<IEnumerable<TMainDto>>(entities);
        return mainDtos;
    }

    public async Task<TMainDto> CreateAsync(TCreationDto creationDto)
    {
        TEntity? entity = Mapper.Map<TEntity>(creationDto);
        RepositoryManagerGeneric.BasicGenericRepository.CreateAsync(entity);
        await RepositoryManagerGeneric.SaveAsync();
        
        TMainDto? mainDto = Mapper.Map<TMainDto>(entity);
        return mainDto;
    }

    public async Task<(IEnumerable<TMainDto> mainDtos, string ids)> CreateCollectionAsync
        (IEnumerable<TCreationDto> collectionForCreation)
    {
        if (collectionForCreation is null)
            throw new CollectionBadRequest();
        IEnumerable<TEntity>? entities = 
            Mapper.Map<IEnumerable<TEntity>>(collectionForCreation);
        foreach (TEntity entity in entities)
        {
            RepositoryManagerGeneric.BasicGenericRepository.CreateAsync(entity);
        }
        await RepositoryManagerGeneric.SaveAsync();
        IEnumerable<TMainDto>? collectionForCreationToReturn =
            Mapper.Map<IEnumerable<TMainDto>>(entities);
        string ids = string.Join(",", collectionForCreationToReturn.Select(c => c.Id));
        return (collectionForCreationToReturn, ids);
    }

    public async Task DeleteCollectionAsync(IEnumerable<TMainDto> mainDtos, bool trackChanges)
    {
        if (mainDtos is null)
            throw new CollectionBadRequest();
        IEnumerable<Guid> ids = mainDtos.Select(e => e.Id).ToList();
        if (ids is null)
            throw new IdParametersBadRequestException();
        IEnumerable<TEntity> entities =
            await RepositoryManagerGeneric.BasicGenericRepository.GetCollectionAsync(ids, trackChanges);
        if (ids.Count() != entities.Count())
            throw new CollectionByIdsBadRequestException();
        foreach (TEntity entity in entities)
            RepositoryManagerGeneric.BasicGenericRepository.DeleteEntity(entity);
        await RepositoryManagerGeneric.SaveAsync();
    }

    public async Task DeleteAsync(Guid id, bool trackChanges)
    {
        TEntity entity = await GetAndCheckIfExitsAsync(id, trackChanges);
        RepositoryManagerGeneric.BasicGenericRepository.DeleteEntity(entity);
        await RepositoryManagerGeneric.SaveAsync();
    }
    


    public async Task UpdateAsync(Guid guid, TUpdateDto updateDto, bool trackChanges)
    {
        if (updateDto.Label is null)
            throw new NullObjectException($"Label is null.");
        TEntity entity =
            await GetAndCheckIfExitsAsync(guid, trackChanges);
        Mapper.Map(updateDto, entity);
        await RepositoryManagerGeneric.SaveAsync();
    }

    public async Task<(TUpdateDto updateDto, TEntity entity)> PatchAsync(Guid id, bool trackChanges)
    {
        TEntity entity = 
            await GetAndCheckIfExitsAsync(id, trackChanges);
        TUpdateDto? updateDto =
            Mapper.Map<TUpdateDto>(entity);
        return (updateDto, entity);
    }

    public async Task SaveChangesForPatchAsync(TUpdateDto updateDto, TEntity entity)
    {
        Mapper.Map(updateDto, entity);
        await RepositoryManagerGeneric.SaveAsync();
    }

    private async Task<TEntity> GetAndCheckIfExitsAsync(Guid id, bool trackChanges)
    {
        TEntity? entity = await RepositoryManagerGeneric.BasicGenericRepository.GetById(id, trackChanges);
        if (entity is null)
            throw new NotFoundException($"{id} is not found.");
        return entity;
    }
}
