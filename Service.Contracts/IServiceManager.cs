using Contracts;

namespace Service.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
    IDocumentHistoryService DocumentHistoryService { get; }
    IDocumentService DocumentService { get; }
    IDocumentStatusHistoryService DocumentStatusHistoryService{ get; } 
    IDocumentStatusService DocumentStatusService { get; }
    IDocumentTypeHistoryService DocumentTypeHistoryService{ get; }
    IDocumentTypeService DocumentTypeService { get; }
    ILateMissDocumentHistoryService LateMissDocumentHistoryService { get; }
    ILateMissDocumentService LateMissDocumentService{ get; }
    ILateMissHistoryService LateMissHistoryService { get; }
    ILateMissService LateMissService { get; }
    ILateMissStatusHistoryService LateMissStatusHistoryService { get; }
    ILateMissStatusService LateMissStatusService { get; }
    ILateMissTypeHistoryService LateMissTypeHistoryService { get; }
    ILateMissTypeService LateMissTypeService { get; }
    INotificationHistoryService NotificationHistoryService { get; }
    INotificationService NotificationService { get; }
    INotificationTypeHistoryService NotificationTypeHistoryService { get; }
    INotificationTypeService NotificationTypeService { get; }
    IProfessionalStatusHistoryService ProfessionalStatusHistoryService { get; }
    IProfessionalStatusService ProfessionalStatusService { get; }
    ITrainingHistoryService TrainingHistoryService { get; }
    ITrainingService TrainingService { get; }
    ITrainingTypeHistoryService TrainingTypeHistoryService { get; }
    ITrainingTypeService TrainingTypeService { get; }
    IUserHistoryService UserHistoryService { get; }
    IUserService UserService { get; }
}