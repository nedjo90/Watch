using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public ServiceManager
        (IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper mapper, 
            UserManager<User> userManager,
            IOptionsMonitor<JwtConfiguration> configuration)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(
                loggerManager, mapper, userManager, configuration));
    }
}