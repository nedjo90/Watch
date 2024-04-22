using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;

namespace Service;

internal class BasicService<TEntity, TMainDto, TCreationDto> 
    : ServiceBaseGeneric<TEntity>,
        IBasicService<TEntity, TMainDto, TCreationDto>
    where TEntity : class
    where TMainDto : class
    where TCreationDto : class
{
    public BasicService(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric,
        ILoggerManager loggerManager,
        IMapper mapper, 
        IDocumentTypeLinks documentTypeLinks) 
        : base(repositoryManagerGeneric, loggerManager, mapper, documentTypeLinks)
    {
    }

    public async Task<TMainDto> GetByIdAsync(Guid guid, bool trackChanges)
    {
        TEntity? entity = await RepositoryManagerGeneric.BasicRepository.GetById(guid, false);
        if (entity is null)
            throw new NotFoundException($"{guid} doesn't exist.");
        TMainDto? mainDto = Mapper.Map<TMainDto>(entity);
        return mainDto;
    }

    public async Task<TMainDto> CreateAsync(TCreationDto creationDto)
    {
        TEntity? entity = Mapper.Map<TEntity>(creationDto);
        RepositoryManagerGeneric.BasicRepository.CreateAsync(entity);
        await RepositoryManagerGeneric.SaveAsync();
        
        TMainDto? mainDto = Mapper.Map<TMainDto>(entity);
        return mainDto;
    }
}
