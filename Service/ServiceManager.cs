using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IDocumentTypeService> _documentType;
    private readonly Lazy<IDocumentStatusService> _documentStatus;
    private readonly Lazy<IProfessionalStatusService> _professionalStatus;
    public IDocumentTypeService DocumentType => _documentType.Value;
    public IDocumentStatusService DocumentStatus => _documentStatus.Value;
    public IProfessionalStatusService ProfessionalStatus => _professionalStatus.Value;


    public ServiceManager
        (IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
    {
        _documentType =
            new Lazy<IDocumentTypeService>(() =>
                new DocumentTypeService(repositoryManager, loggerManager, mapper, documentTypeLinks));
        _documentStatus =
            new Lazy<IDocumentStatusService>(() =>
                new DocumentStatusService(repositoryManager, loggerManager, mapper, documentTypeLinks));
        _professionalStatus =
            new Lazy<IProfessionalStatusService>(() =>
                new ProfessionalStatusService(repositoryManager, loggerManager, mapper, documentTypeLinks));
    }
    
}