using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDocumentTypeService> _documentTypeService;
    private readonly Lazy<IDocumentStatusService> _documentStatusService;
    public IDocumentTypeService DocumentTypeService => _documentTypeService.Value;
    public IDocumentStatusService DocumentStatusService => _documentStatusService.Value;
 

    public ServiceManager
        (IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
    {
        _documentTypeService =
            new Lazy<IDocumentTypeService>(() =>
                new DocumentTypeService(repositoryManager, loggerManager, mapper, documentTypeLinks));
        _documentStatusService =
            new Lazy<IDocumentStatusService>(() =>
                new DocumentStatusService(repositoryManager, loggerManager, mapper, documentTypeLinks));
    }
    
}