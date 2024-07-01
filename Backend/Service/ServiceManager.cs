using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;
    private readonly IOptions<JwtConfiguration> _configuration;
    private readonly UserManager<User?> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly Lazy<IDocumentHistoryService> _documentHistoryService;
    private readonly Lazy<IDocumentService> _documentService;
    private readonly Lazy<IDocumentTypeHistoryService> _documentTypeHistoryService;
    private readonly Lazy<IDocumentTypeService> _documentTypeService;
    private readonly Lazy<IDocumentStatusHistoryService> _documentStatusHistoryService;
    private readonly Lazy<IDocumentStatusService> _documentStatusService;
    private readonly Lazy<ILateMissHistoryService> _lateMissHistoryService;
    private readonly Lazy<ILateMissService> _lateMissService;
    private readonly Lazy<ILateMissDocumentHistoryService> _lateMissDocumentHistoryService;
    private readonly Lazy<ILateMissDocumentService> _lateMissDocumentService;
    private readonly Lazy<ILateMissStatusHistoryService> _lateMissStatusHistoryService;
    private readonly Lazy<ILateMissStatusService> _lateMissStatusService;
    private readonly Lazy<ILateMissTypeHistoryService> _lateMissTypeHistoryService;
    private readonly Lazy<ILateMissTypeService> _lateMissTypeService;
    private readonly Lazy<IProfessionalStatusHistoryService> _professionalStatusHistoryService;
    private readonly Lazy<IProfessionalStatusService> _professionalStatusService;
    private readonly Lazy<INotificationHistoryService> _notificationHistoryService;
    private readonly Lazy<INotificationService> _notificationService;
    private readonly Lazy<INotificationTypeHistoryService> _notificationTypeHistoryService;
    private readonly Lazy<INotificationTypeService> _notificationTypeService;
    private readonly Lazy<ITrainingHistoryService> _trainingHistoryService;
    private readonly Lazy<ITrainingService> _trainingService;
    private readonly Lazy<ITrainingTypeHistoryService> _trainingTypeHistoryService;
    private readonly Lazy<ITrainingTypeService> _trainingTypeService;
    private readonly Lazy<IUserHistoryService> _userHistoryService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IDocumentHistoryService DocumentHistoryService => _documentHistoryService.Value;
    public IDocumentService DocumentService => _documentService.Value;
    public IDocumentTypeHistoryService DocumentTypeHistoryService => _documentTypeHistoryService.Value;
    public IDocumentTypeService DocumentTypeService => _documentTypeService.Value;
    public IDocumentStatusHistoryService DocumentStatusHistoryService => _documentStatusHistoryService.Value;
    public IDocumentStatusService DocumentStatusService => _documentStatusService.Value;
    public ILateMissHistoryService LateMissHistoryService => _lateMissHistoryService.Value;
    public ILateMissService LateMissService => _lateMissService.Value;
    public ILateMissDocumentHistoryService LateMissDocumentHistoryService => _lateMissDocumentHistoryService.Value;
    public ILateMissDocumentService LateMissDocumentService => _lateMissDocumentService.Value;
    public ILateMissStatusHistoryService LateMissStatusHistoryService => _lateMissStatusHistoryService.Value;
    public ILateMissStatusService LateMissStatusService => _lateMissStatusService.Value;
    public ILateMissTypeHistoryService LateMissTypeHistoryService => _lateMissTypeHistoryService.Value;
    public ILateMissTypeService LateMissTypeService => _lateMissTypeService.Value;

    public IProfessionalStatusHistoryService ProfessionalStatusHistoryService =>
        _professionalStatusHistoryService.Value;

    public IProfessionalStatusService ProfessionalStatusService => _professionalStatusService.Value;
    public INotificationHistoryService NotificationHistoryService => _notificationHistoryService.Value;
    public INotificationService NotificationService => _notificationService.Value;
    public INotificationTypeHistoryService NotificationTypeHistoryService => _notificationTypeHistoryService.Value;
    public INotificationTypeService NotificationTypeService => _notificationTypeService.Value;
    public ITrainingHistoryService TrainingHistoryService => _trainingHistoryService.Value;
    public ITrainingService TrainingService => _trainingService.Value;
    public ITrainingTypeHistoryService TrainingTypeHistoryService => _trainingTypeHistoryService.Value;
    public ITrainingTypeService TrainingTypeService => _trainingTypeService.Value;
    public IUserHistoryService UserHistoryService => _userHistoryService.Value;
    public IUserService UserService => _userService.Value;

    public ServiceManager
    (IHttpContextAccessor httpContextAccessor,
        IRepositoryManager repositoryManager,
        ILoggerManager loggerManager,
        IMapper mapper,
        IOptions<JwtConfiguration> configuration,
        UserManager<User?> userManager,
        RoleManager<Role> roleManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
        _configuration = configuration;
        _userManager = userManager;
        _roleManager = roleManager;
        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(loggerManager, mapper, userManager, roleManager, configuration));
        _documentHistoryService = new Lazy<IDocumentHistoryService>(() =>
            new DocumentHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _documentService = new Lazy<IDocumentService>(() =>
            new DocumentService(userManager, httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _documentTypeHistoryService = new Lazy<IDocumentTypeHistoryService>(() =>
            new DocumentTypeHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _documentTypeService = new Lazy<IDocumentTypeService>(() =>
            new DocumentTypeService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _documentStatusHistoryService = new Lazy<IDocumentStatusHistoryService>(() =>
            new DocumentStatusHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _documentStatusService = new Lazy<IDocumentStatusService>(() =>
            new DocumentStatusService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissHistoryService = new Lazy<ILateMissHistoryService>(() =>
            new LateMissHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissService = new Lazy<ILateMissService>(() =>
            new LateMissService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissDocumentHistoryService = new Lazy<ILateMissDocumentHistoryService>(() =>
            new LateMissDocumentHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissDocumentService = new Lazy<ILateMissDocumentService>(() =>
            new LateMissDocumentService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissStatusHistoryService = new Lazy<ILateMissStatusHistoryService>(() =>
            new LateMissStatusHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissStatusService = new Lazy<ILateMissStatusService>(() =>
            new LateMissStatusService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissTypeHistoryService = new Lazy<ILateMissTypeHistoryService>(() =>
            new LateMissTypeHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _lateMissTypeService = new Lazy<ILateMissTypeService>(() =>
            new LateMissTypeService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _professionalStatusHistoryService = new Lazy<IProfessionalStatusHistoryService>(() =>
            new ProfessionalStatusHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _professionalStatusService = new Lazy<IProfessionalStatusService>(() =>
            new ProfessionalStatusService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _notificationHistoryService = new Lazy<INotificationHistoryService>(() =>
            new NotificationHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _notificationService = new Lazy<INotificationService>(() =>
            new NotificationService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _notificationTypeHistoryService = new Lazy<INotificationTypeHistoryService>(() =>
            new NotificationTypeHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _notificationTypeService = new Lazy<INotificationTypeService>(() =>
            new NotificationTypeService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _trainingHistoryService = new Lazy<ITrainingHistoryService>(() =>
            new TrainingHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _trainingService = new Lazy<ITrainingService>(() =>
            new TrainingService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _trainingTypeHistoryService = new Lazy<ITrainingTypeHistoryService>(() =>
            new TrainingTypeHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _trainingTypeService = new Lazy<ITrainingTypeService>(() =>
            new TrainingTypeService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _userHistoryService = new Lazy<IUserHistoryService>(() =>
            new UserHistoryService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
        _userService = new Lazy<IUserService>(() =>
            new UserService(userManager,httpContextAccessor, this, repositoryManager, loggerManager, mapper));
    }
}