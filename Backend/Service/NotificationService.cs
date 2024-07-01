using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.Notification;
using Shared.DataTransfertObject.NotificationType;

namespace Service;

internal class NotificationService: ServiceBase, INotificationService
{
    public NotificationService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<NotificationDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<Notification> notifications =
            await RepositoryManager.NotificationRepository.GetAllAsync(trackChanges);
        IEnumerable<NotificationDto> notificationDtos =
            Mapper.Map<IEnumerable<NotificationDto>>(notifications);
        return notificationDtos;
    }

    public async Task<Notification?> CheckIfExistAndGetByIdAsync(Guid? id)
    {
        return await RepositoryManager.NotificationRepository.GetByIdAsync(id, false);
    }

    public async Task<IEnumerable<NotificationDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<Notification> notification =
            await RepositoryManager.NotificationRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<NotificationDto> notificationDtos =
            Mapper.Map<IEnumerable<NotificationDto>>(notification);
        return notificationDtos;
    }

    public async Task<NotificationDto?> GetByIdAsync(Guid id, bool trackChanges)
    {
        Notification? notification =
            await RepositoryManager.NotificationRepository.GetByIdAsync(id, trackChanges);
        if (notification == null)
            throw new IdNotFoundException(id, "Notification");
        NotificationDto notificationDto = Mapper.Map<NotificationDto>(notification);
        return notificationDto;
    }

    public async Task<NotificationDto> CreateAsync(NotificationForCreationDto notificationForCreationDto)
    {
        await ThrowIfNotificationForCreationIsNotValid(notificationForCreationDto);
        Notification notification = Mapper.Map<Notification>(notificationForCreationDto);
        RepositoryManager.NotificationRepository.CreateAsync(notification);
        await ServiceManager.NotificationHistoryService
            .RegisterModification(notification, TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        NotificationDto notificationDto = Mapper.Map<NotificationDto>(notification);
        return notificationDto;
    }

    public async Task<IEnumerable<NotificationDto>> CreateCollectionAsync(IEnumerable<NotificationForCreationDto> notificationForCreationDtos)
    {
        await ThrowIfListOfNotificationForCreationIsNotValid(notificationForCreationDtos);
        IEnumerable<Notification?> notification =
            Mapper.Map<IEnumerable<Notification>>(notificationForCreationDtos);
        foreach (Notification entity in notification)
        {
            RepositoryManager.NotificationRepository.CreateAsync(entity);
            await ServiceManager.NotificationHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<NotificationDto> notificationDtos =
            Mapper.Map<IEnumerable<NotificationDto>>(notification);
        return notificationDtos;
    }
    
    private async Task ThrowIfListOfNotificationForCreationIsNotValid(IEnumerable<NotificationForCreationDto> notificationForCreationDtos)
    {
        List<object> errors = new ();
        foreach (NotificationForCreationDto notificationForCreationDto in notificationForCreationDtos)
        {
            List<object> specificError = await ReturnListOfErrors(notificationForCreationDto);
            if (specificError.Count > 0)
                errors.Add(specificError);
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException(
                "Invalid notification information detected. Please provide valid informations.", errors);
    }
    private async Task ThrowIfNotificationForCreationIsNotValid(NotificationForCreationDto notificationForCreationDto)
    {
        List<object> errors = await ReturnListOfErrors(notificationForCreationDto);
        if (errors.Count > 0)
            throw new BadRequestMultipleException(
                "Invalid notification information detected. Please provide valid informations.", errors);
    }
    private async Task<List<object>> ReturnListOfErrors(NotificationForCreationDto notificationForCreationDto)
    {
        List<object> errors = new();
        if (await ServiceManager.NotificationTypeService.CheckIfExistAndGetById(notificationForCreationDto.NotificationTypeId, false) == null)
            errors.Add(
            new {
                notificationForCreationDto.NotificationTypeId,
                detail = "Notification Type Id doesn't exist."
            });
        if(await ServiceManager.UserService.CheckIfUserIdIsExisting(notificationForCreationDto.UserId) == false)
            errors.Add(
            new {
                notificationForCreationDto.UserId,
                detail = "User Id doesn't exist."
            });
        return errors;
    }
}