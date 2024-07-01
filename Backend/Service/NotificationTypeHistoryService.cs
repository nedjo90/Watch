using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.NotificationType;
using Shared.DataTransfertObject.NotificationTypeHistory;

namespace Service;

internal class NotificationTypeHistoryService: ServiceBase, INotificationTypeHistoryService
{
    public NotificationTypeHistoryService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<NotificationTypeHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<NotificationTypeHistory> notificationTypeHistories =
            await RepositoryManager.NotificationTypeHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<NotificationTypeHistoryDto> notificationHistoryTypeDtos =
            Mapper.Map<IEnumerable<NotificationTypeHistoryDto>>(notificationTypeHistories);
        return notificationHistoryTypeDtos;
    }

    public Task<NotificationTypeHistoryDto> GetById(Guid id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task RegisterModification(NotificationType notificationType, string typeOfModification)
    {
        NotificationTypeHistory notificationTypeHistory = new NotificationTypeHistory();
        notificationTypeHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        notificationTypeHistory.Label = notificationType.Label!;
        notificationTypeHistory.NotificationTypeId = notificationType.Id;
        notificationTypeHistory.TypeOfModification = typeOfModification;
        notificationTypeHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.NotificationTypeHistoryRepository.RegistreModification(notificationTypeHistory);        
    }
}