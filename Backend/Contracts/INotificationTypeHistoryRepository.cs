using Entities.Models;

namespace Contracts;

public interface INotificationTypeHistoryRepository 
{
    Task<IEnumerable<NotificationTypeHistory>> GetAllAsync(bool trackChanges);
    void RegistreModification(NotificationTypeHistory notificationTypeHistory);
}