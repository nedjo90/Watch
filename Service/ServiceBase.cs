using AutoMapper;
using Contracts;

namespace Service;

internal abstract class ServiceBase
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IDocumentTypeLinks _documentTypeLinks;
    public IRepositoryManager RepositoryManager => _repositoryManager;
    public ILoggerManager LoggerManager => _loggerManager;
    public IMapper Mapper => _mapper;
    public IDocumentTypeLinks DocumentTypeLinks => _documentTypeLinks;
    
    
    protected ServiceBase(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
        _documentTypeLinks = documentTypeLinks;
    }
}