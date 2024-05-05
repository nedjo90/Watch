namespace Contracts;

public interface IRepositoryManager
{
    IDocumentHistoryRepository DocumentHistoryRepository { get; }
    IDocumentRepository DocumentRepository { get; }
    IDocumentStatusHistoryRepository DocumentStatusHistoryRepository{ get; } 
    IDocumentStatusRepository DocumentStatusRepository { get; }
    IDocumentTypeHistoryRepository DocumentTypeHistoryRepository{ get; }
    IDocumentTypeRepository DocumentTypeRepository { get; }
    ILateMissDocumentHistoryRepository LateMissDocumentHistoryRepository { get; }
    ILateMissDocumentRepository LateMissDocumentRepository{ get; }
    ILateMissHistoryRepository LateMissHistoryRepository { get; }
    ILateMissRepository LateMissRepository { get; }
    ILateMissStatusHistoryRepository LateMissStatusHistoryRepository { get; }
    ILateMissStatusRepository LateMissStatusRepository { get; }
    ILateMissTypeHistoryRepository LateMissTypeHistoryRepository { get; }
    ILateMissTypeRepository LateMissTypeRepository { get; }
    INotificationHistoryRepository NotificationHistoryRepository { get; }
    INotificationRepository NotificationRepository { get; }
    INotificationTypeHistoryRepository NotificationTypeHistoryRepository { get; }
    INotificationTypeRepository NotificationTypeRepository { get; }
    IProfessionalStatusHistoryRepository ProfessionalStatusHistoryRepository { get; }
    IProfessionalStatusRepository ProfessionalStatusRepository { get; }
    ITrainingHistoryRepository TrainingHistoryRepository { get; }
    ITrainingRepository TrainingRepository { get; }
    ITrainingTypeHistoryRepository TrainingTypeHistoryRepository { get; }
    ITrainingTypeRepository TrainingTypeRepository { get; }
    IUserHistoryRepository UserHistoryRepository { get; }
    IUserRepository UserRepository { get; }
    Task SaveAsync();
}