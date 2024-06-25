using Entities.Models;
using Shared.DataTransfertObject.NotificationType;
using Shared.DataTransfertObject.NotificationTypeHistory;

namespace Service.Contracts;

public interface INotificationTypeHistoryService 
{
    Task<IEnumerable<NotificationTypeHistoryDto>> GetAllAsync(bool trackChanges);
    Task<NotificationTypeHistoryDto> GetById(Guid id, bool trackChanges);
    Task RegisterModification( NotificationType notificationType, string typeOfModification);
}