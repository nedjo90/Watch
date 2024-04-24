using AutoMapper;
using Contracts;

namespace Service;

internal abstract class ServiceBase
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    public IRepositoryManager RepositoryManager => _repositoryManager;
    public ILoggerManager LoggerManager => _loggerManager;
    public IMapper Mapper => _mapper;
    
    
    protected ServiceBase(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
}