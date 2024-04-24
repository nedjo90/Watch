using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.BasicGeneric;

namespace Service;

internal abstract class ServiceBaseGeneric<TEntity, TMainDto>
where TEntity : BasicGenericEntity
where TMainDto : BasicGenericDto
{
    private readonly IRepositoryManagerGeneric<TEntity> _repositoryManagerGeneric;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IBasicGenericLinks<TMainDto> _basicGenericLinks;
    protected IRepositoryManagerGeneric<TEntity> RepositoryManagerGeneric => _repositoryManagerGeneric;
    public ILoggerManager LoggerManager => _loggerManager;
    protected IMapper Mapper => _mapper;
    protected IBasicGenericLinks<TMainDto> BasicGenericLinks => _basicGenericLinks;
    
    
    protected ServiceBaseGeneric(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric, ILoggerManager loggerManager, IMapper mapper, IBasicGenericLinks<TMainDto> basicGenericLinks)
    {
        _repositoryManagerGeneric = repositoryManagerGeneric;
        _loggerManager = loggerManager;
        _mapper = mapper;
        _basicGenericLinks = basicGenericLinks;
    }
    
}