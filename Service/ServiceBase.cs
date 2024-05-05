using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Service;

internal abstract class ServiceBase
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    protected IRepositoryManager RepositoryManager => _repositoryManager;
    protected ILoggerManager LoggerManager => _loggerManager;
    protected IMapper Mapper => _mapper;
    protected IHttpContextAccessor HttpContext => _httpContext;
    
    
    protected ServiceBase(IHttpContextAccessor httpContext,IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _httpContext = httpContext;
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
}