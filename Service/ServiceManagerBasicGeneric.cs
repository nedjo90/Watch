using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;
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
    private readonly Lazy<IAuthenticationService> _authenticationService;
    public IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto> BasicService => _basicService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;

    public ServiceManagerBasicGeneric(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric,
            ILoggerManager loggerManager,
            IMapper mapper,
            UserManager<User> userManager,
            IOptionsMonitor<JwtConfiguration> configuration,  
            IBasicGenericLinks<TMainDto> basicGenericLinks)
    {
        _basicService = new Lazy<IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto>>(() =>
            new BasicService<TEntity, TMainDto, TCreationDto, TUpdateDto>(repositoryManagerGeneric,
                loggerManager,
                mapper,
                basicGenericLinks));
        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(
                loggerManager, mapper ,userManager, configuration));
    }
}