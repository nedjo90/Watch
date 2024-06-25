using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;

namespace Service;

internal abstract class ServiceBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IServiceManager _serviceManager;
    protected IRepositoryManager RepositoryManager => _repositoryManager;
    protected ILoggerManager LoggerManager => _loggerManager;
    protected IMapper Mapper => _mapper;
    protected IHttpContextAccessor HttpContextAccessor => _httpContextAccessor;
    protected IServiceManager ServiceManager => _serviceManager;
    
    
    protected ServiceBase(IHttpContextAccessor httpContextAccessor, IServiceManager serviceManager, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
        _serviceManager = serviceManager;
    }
}