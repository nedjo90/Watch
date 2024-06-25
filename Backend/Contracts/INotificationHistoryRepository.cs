using Entities.Models;

namespace Contracts;

public interface INotificationHistoryRepository 
{
    Task<IEnumerable<NotificationHistory>> GetAllAsync(bool trackChanges);
    void RegistreModification(NotificationHistory notificationHistory);
}