using AutoMapper;
using Contracts;

namespace Service;

internal abstract class ServiceBaseGeneric<TEntity>
where TEntity : class
{
    private readonly IRepositoryManagerGeneric<TEntity> _repositoryManagerGeneric;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IDocumentTypeLinks _documentTypeLinks;
    public IRepositoryManagerGeneric<TEntity> RepositoryManagerGeneric => _repositoryManagerGeneric;
    public ILoggerManager LoggerManager => _loggerManager;
    public IMapper Mapper => _mapper;
    public IDocumentTypeLinks DocumentTypeLinks => _documentTypeLinks;
    
    
    protected ServiceBaseGeneric(IRepositoryManagerGeneric<TEntity> repositoryManagerGeneric, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
    {
        _repositoryManagerGeneric = repositoryManagerGeneric;
        _loggerManager = loggerManager;
        _mapper = mapper;
        _documentTypeLinks = documentTypeLinks;
    }
    
}