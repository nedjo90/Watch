using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface INotificationTypeRepository
{
    Task<IEnumerable<NotificationType>> GetAllAsync(bool trackChanges);
    Task<NotificationType?> GetById(Guid? id, bool trackChanges);
    void CreateAsync(NotificationType newLabel);
    Task<IEnumerable<NotificationType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEntity(NotificationType entity);
    Task<PagedList<NotificationType>> GetAllPagingAsync(NotificationTypeParameters trainingTypeParameters, bool trackChanges);
}