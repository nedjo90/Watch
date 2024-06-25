using Entities.Models;
using Shared.DataTransfertObject.NotificationType;

namespace Service.Contracts;

public interface INotificationTypeService
{
    Task<IEnumerable<NotificationTypeDto>> GetAllAsync(bool trackChanges);
    Task<NotificationTypeDto> GetByIdAsync(Guid guid, bool trackChanges);
    Task<NotificationType?> CheckIfExistAndGetById(Guid? id, bool trackChanges);
    Task<IEnumerable<NotificationTypeDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<NotificationTypeDto> CreateAsync(NotificationTypeForCreationDto notificationTypeForCreation);
    Task<IEnumerable<NotificationTypeDto>> CreateCollectionAsync(IEnumerable<NotificationTypeForCreationDto> notificationTypeForCreationDtos);

}