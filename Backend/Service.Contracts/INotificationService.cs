using Entities.Models;
using Shared.DataTransfertObject.Notification;

namespace Service.Contracts;

public interface INotificationService
{
    Task<NotificationDto?> GetByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<NotificationDto>> GetAllAsync(bool trackChanges);
    Task<Notification?> CheckIfExistAndGetByIdAsync(Guid? lateMiss);
    Task<IEnumerable<NotificationDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<NotificationDto> CreateAsync(NotificationForCreationDto notificationForCreationDto);
    Task<IEnumerable<NotificationDto>> CreateCollectionAsync(
        IEnumerable<NotificationForCreationDto> notificationForCreationDtos);
}