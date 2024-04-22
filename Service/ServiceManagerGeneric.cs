using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManagerGeneric<TEntity, TMainDto, TCreationDto> 
    : IServiceManagerGeneric<TEntity, TMainDto, TCreationDto>
    where TEntity : class
    where TMainDto : class
    where TCreationDto : class
{
    private readonly Lazy<IBasicService<TEntity, TMainDto, TCreationDto>> _basicService;
    public IBasicService<TEntity, TMainDto, TCreationDto> BasicService => _basicService.Value;

    public ServiceManagerGeneric(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric,
            ILoggerManager loggerManager,
            IMapper mapper, 
            IDocumentTypeLinks documentTypeLinks)
    {
        _basicService = new Lazy<IBasicService<TEntity, TMainDto, TCreationDto>>(() =>
            new BasicService<TEntity, TMainDto, TCreationDto>(repositoryManagerGeneric,
                loggerManager,
                mapper,
                documentTypeLinks));
    }
}