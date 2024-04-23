using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.Basic;
using Shared.BasicGeneric;

namespace Service;

public class ServiceManagerBasicGeneric<TEntity, TMainDto, TCreationDto, TUpdateDto> 
    : IServiceManagerBasicGeneric<TEntity, TMainDto, TCreationDto, TUpdateDto>
    where TEntity : BasicGenericEntity
    where TMainDto : BasicGenericDto
    where TCreationDto : BasicGenericForCreationDto
    where TUpdateDto : BasicGenericForUpdateDto
{
    private readonly Lazy<IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto>> _basicService;
    public IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto> BasicService => _basicService.Value;

    public ServiceManagerBasicGeneric(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric,
            ILoggerManager loggerManager,
            IMapper mapper, 
            IDocumentTypeLinks documentTypeLinks)
    {
        _basicService = new Lazy<IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto>>(() =>
            new BasicService<TEntity, TMainDto, TCreationDto, TUpdateDto>(repositoryManagerGeneric,
                loggerManager,
                mapper,
                documentTypeLinks));
    }
}