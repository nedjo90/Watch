using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDocumentTypeService> _documentTypeService;
    public IDocumentTypeService DocumentTypeService => _documentTypeService.Value;
 

    public ServiceManager
        (IRepositoryManager repositoryManager, ILoggerManager loggerManager,IDocumentTypeService documentTypeService)
    {
        _documentTypeService =
            new Lazy<IDocumentTypeService>(() =>
                new DocumentTypeService(repositoryManager, loggerManager));
    }
    
}