using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;

    private readonly Lazy<IDocumentHistoryRepository> _documentHistoryRepository;
    private readonly Lazy<IDocumentRepository> _documentRepository;
    private readonly Lazy<IDocumentTypeHistoryRepository> _documentTypeHistoryRepository;
    private readonly Lazy<IDocumentTypeRepository> _documentTypeRepository;
    private readonly Lazy<IDocumentStatusHistoryRepository> _documentStatusHistoryRepository;
    private readonly Lazy<IDocumentStatusRepository> _documentStatusRepository;
    private readonly Lazy<ILateMissHistoryRepository> _lateMissHistoryRepository;
    private readonly Lazy<ILateMissRepository> _lateMissRepository;
    private readonly Lazy<ILateMissDocumentHistoryRepository> _lateMissDocumentHistoryRepository;
    private readonly Lazy<ILateMissDocumentRepository> _lateMissDocumentRepository;
    private readonly Lazy<ILateMissStatusHistoryRepository> _lateMissStatusHistoryRepository;
    private readonly Lazy<ILateMissStatusRepository> _lateMissStatusRepository;
    private readonly Lazy<ILateMissTypeHistoryRepository> _lateMissTypeHistoryRepository;
    private readonly Lazy<ILateMissTypeRepository> _lateMissTypeRepository;
    private readonly Lazy<IProfessionalStatusHistoryRepository> _professionalStatusHistoryRepository;
    private readonly Lazy<IProfessionalStatusRepository> _professionalStatusRepository;
    private readonly Lazy<INotificationHistoryRepository> _notificationHistoryRepository;
    private readonly Lazy<INotificationRepository> _notificationRepository;
    private readonly Lazy<INotificationTypeHistoryRepository> _notificationTypeHistoryRepository;
    private readonly Lazy<INotificationTypeRepository> _notificationTypeRepository;
    private readonly Lazy<ITrainingHistoryRepository> _trainingHistoryRepository;
    private readonly Lazy<ITrainingRepository> _trainingRepository;
    private readonly Lazy<ITrainingTypeHistoryRepository> _trainingTypeHistoryRepository;
    private readonly Lazy<ITrainingTypeRepository> _trainingTypeRepository;
    private readonly Lazy<IUserHistoryRepository> _userHistoryRepository;
    private readonly Lazy<IUserRepository> _userRepository;
    
    public IDocumentHistoryRepository DocumentHistoryRepository => _documentHistoryRepository.Value; 
    public IDocumentRepository DocumentRepository => _documentRepository.Value; 
    public IDocumentTypeHistoryRepository DocumentTypeHistoryRepository => _documentTypeHistoryRepository.Value; 
    public IDocumentTypeRepository DocumentTypeRepository => _documentTypeRepository.Value; 
    public IDocumentStatusHistoryRepository DocumentStatusHistoryRepository => _documentStatusHistoryRepository.Value; 
    public IDocumentStatusRepository DocumentStatusRepository => _documentStatusRepository.Value; 
    public ILateMissHistoryRepository LateMissHistoryRepository => _lateMissHistoryRepository.Value; 
    public ILateMissRepository LateMissRepository => _lateMissRepository.Value; 
    public ILateMissDocumentHistoryRepository LateMissDocumentHistoryRepository => _lateMissDocumentHistoryRepository.Value; 
    public ILateMissDocumentRepository LateMissDocumentRepository => _lateMissDocumentRepository.Value; 
    public ILateMissStatusHistoryRepository LateMissStatusHistoryRepository => _lateMissStatusHistoryRepository.Value; 
    public ILateMissStatusRepository LateMissStatusRepository => _lateMissStatusRepository.Value; 
    public ILateMissTypeHistoryRepository LateMissTypeHistoryRepository => _lateMissTypeHistoryRepository.Value; 
    public ILateMissTypeRepository LateMissTypeRepository => _lateMissTypeRepository.Value; 
    public IProfessionalStatusHistoryRepository ProfessionalStatusHistoryRepository => _professionalStatusHistoryRepository.Value; 
    public IProfessionalStatusRepository ProfessionalStatusRepository => _professionalStatusRepository.Value; 
    public INotificationHistoryRepository NotificationHistoryRepository => _notificationHistoryRepository.Value; 
    public INotificationRepository NotificationRepository => _notificationRepository.Value; 
    public INotificationTypeHistoryRepository NotificationTypeHistoryRepository => _notificationTypeHistoryRepository.Value; 
    public INotificationTypeRepository NotificationTypeRepository => _notificationTypeRepository.Value; 
    public ITrainingHistoryRepository TrainingHistoryRepository => _trainingHistoryRepository.Value; 
    public ITrainingRepository TrainingRepository => _trainingRepository.Value; 
    public ITrainingTypeHistoryRepository TrainingTypeHistoryRepository => _trainingTypeHistoryRepository.Value; 
    public ITrainingTypeRepository TrainingTypeRepository => _trainingTypeRepository.Value; 
    public IUserHistoryRepository UserHistoryRepository => _userHistoryRepository.Value; 
    public IUserRepository UserRepository => _userRepository.Value; 

    
    
    
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _documentHistoryRepository = new Lazy<IDocumentHistoryRepository> (() => 
            new DocumentHistoryRepository(repositoryContext));
        _documentRepository = new Lazy<IDocumentRepository> (() => 
            new DocumentRepository(repositoryContext));
        _documentTypeHistoryRepository = new Lazy<IDocumentTypeHistoryRepository> (() => 
            new DocumentTypeHistoryRepository(repositoryContext));
        _documentTypeRepository = new Lazy<IDocumentTypeRepository> (() => 
            new DocumentTypeRepository(repositoryContext));
        _documentStatusHistoryRepository = new Lazy<IDocumentStatusHistoryRepository> (() => 
            new DocumentStatusHistoryRepository(repositoryContext));
        _documentStatusRepository = new Lazy<IDocumentStatusRepository> (() => 
            new DocumentStatusRepository(repositoryContext));
        _lateMissHistoryRepository = new Lazy<ILateMissHistoryRepository> (() => 
            new LateMissHistoryRepository(repositoryContext));
        _lateMissRepository = new Lazy<ILateMissRepository> (() => 
            new LateMissRepository(repositoryContext));
        _lateMissDocumentHistoryRepository = new Lazy<ILateMissDocumentHistoryRepository> (() => 
            new LateMissDocumentHistoryRepository(repositoryContext));
        _lateMissDocumentRepository = new Lazy<ILateMissDocumentRepository> (() => 
            new LateMissDocumentRepository(repositoryContext));
        _lateMissStatusHistoryRepository = new Lazy<ILateMissStatusHistoryRepository> (() => 
            new LateMissStatusHistoryRepository(repositoryContext));
        _lateMissStatusRepository = new Lazy<ILateMissStatusRepository> (() => 
            new LateMissStatusRepository(repositoryContext));
        _lateMissTypeHistoryRepository = new Lazy<ILateMissTypeHistoryRepository> (() => 
            new LateMissTypeHistoryRepository(repositoryContext));
        _lateMissTypeRepository = new Lazy<ILateMissTypeRepository> (() => 
            new LateMissTypeRepository(repositoryContext));
        _professionalStatusHistoryRepository = new Lazy<IProfessionalStatusHistoryRepository> (() => 
            new ProfessionalStatusHistoryRepository(repositoryContext));
        _professionalStatusRepository = new Lazy<IProfessionalStatusRepository> (() => 
            new ProfessionalStatusRepository(repositoryContext));
        _notificationHistoryRepository = new Lazy<INotificationHistoryRepository> (() => 
            new NotificationHistoryRepository(repositoryContext));
        _notificationRepository = new Lazy<INotificationRepository> (() => 
            new NotificationRepository(repositoryContext));
        _notificationTypeHistoryRepository = new Lazy<INotificationTypeHistoryRepository> (() => 
            new NotificationTypeHistoryRepository(repositoryContext));
        _notificationTypeRepository = new Lazy<INotificationTypeRepository> (() => 
            new NotificationTypeRepository(repositoryContext));
        _trainingHistoryRepository = new Lazy<ITrainingHistoryRepository> (() => 
            new TrainingHistoryRepository(repositoryContext));
        _trainingRepository = new Lazy<ITrainingRepository> (() => 
            new TrainingRepository(repositoryContext));
        _trainingTypeHistoryRepository = new Lazy<ITrainingTypeHistoryRepository> (() => 
            new TrainingTypeHistoryRepository(repositoryContext));
        _trainingTypeRepository = new Lazy<ITrainingTypeRepository> (() => 
            new TrainingTypeRepository(repositoryContext));
        _userHistoryRepository = new Lazy<IUserHistoryRepository> (() => 
            new UserHistoryRepository(repositoryContext));
        _userRepository = new Lazy<IUserRepository> (() => 
            new UserRepository(repositoryContext));
    }
    
    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}