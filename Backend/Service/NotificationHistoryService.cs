using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.NotificationHistory;

namespace Service;

internal class NotificationHistoryService : ServiceBase, INotificationHistoryService
{
    public NotificationHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<NotificationHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<NotificationHistory> notificationHistories =
            await RepositoryManager.NotificationHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<NotificationHistoryDto> notificationHistoryDtos =
            Mapper.Map<IEnumerable<NotificationHistoryDto>>(notificationHistories);
        return notificationHistoryDtos;
    }

    public async Task RegisterModification(Notification notification, string typeOfModification)
    {
        NotificationHistory notificationHistory =
            Mapper.Map<NotificationHistory>(notification);
        notificationHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        notificationHistory.NotificationId = notification.Id;
        notificationHistory.TypeOfModification = typeOfModification;
        notificationHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.NotificationHistoryRepository
            .RegistreModification(notificationHistory);
    }
}