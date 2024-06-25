using Entities.Models;
using Shared.DataTransfertObject.NotificationHistory;

namespace Service.Contracts;

public interface INotificationHistoryService 
{
    Task<IEnumerable<NotificationHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( Notification notification, string typeOfModification);
}