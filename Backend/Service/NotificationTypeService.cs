using System.Security.Principal;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.NotificationType;

namespace Service;

internal class NotificationTypeService : ServiceBase, INotificationTypeService
{
    public NotificationTypeService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<NotificationTypeDto> GetByIdAsync(Guid guid, bool trackChanges)
    {
        NotificationType? notificationType =
            await RepositoryManager.NotificationTypeRepository.GetByIdAsync(guid, trackChanges);
        if (notificationType == null)
            throw new IdNotFoundException(guid, "Notification Type");
        NotificationTypeDto notificationTypeDto =
            Mapper.Map<NotificationTypeDto>(notificationType);
        return notificationTypeDto;
    }

    public async Task<IEnumerable<NotificationTypeDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<NotificationType> notificationTypes =
            await RepositoryManager.NotificationTypeRepository.GetAllAsync(trackChanges);
        IEnumerable<NotificationTypeDto> notificationTypeDtos =
            Mapper.Map<IEnumerable<NotificationTypeDto>>(notificationTypes);
        return notificationTypeDtos;
    }

    public async Task<IEnumerable<NotificationTypeDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<NotificationType> notificationType =
            await RepositoryManager.NotificationTypeRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<NotificationTypeDto> notificationTypeDtos =
            Mapper.Map<IEnumerable<NotificationTypeDto>>(notificationType);
        return notificationTypeDtos;
    }

    public async Task<NotificationTypeDto> CreateAsync(NotificationTypeForCreationDto notificationTypeForCreationDto)
    {
        NotificationType? notificationType =
            await CheckIfExistAndGetByLabel(notificationTypeForCreationDto.Label!);
        if (notificationType != null)
            throw new LabelAlreadyExistBadRequest("Notification Type", notificationTypeForCreationDto.Label!);
        notificationType = Mapper.Map<NotificationType>(notificationTypeForCreationDto);
        RepositoryManager.NotificationTypeRepository.CreateAsync(notificationType);
        await ServiceManager.NotificationTypeHistoryService.RegisterModification
            (notificationType, TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        NotificationTypeDto notificationTypeDto = Mapper.Map<NotificationTypeDto>(notificationType);
        return notificationTypeDto;
    }

    public async Task<IEnumerable<NotificationTypeDto>> CreateCollectionAsync(IEnumerable<NotificationTypeForCreationDto> notificationTypeForCreationDtos)
    {
        await ThrowIfListOfNotificationTypeForCreationIsNotValid(notificationTypeForCreationDtos);
        IEnumerable<NotificationType?> notificationType =
            Mapper.Map<IEnumerable<NotificationType>>(notificationTypeForCreationDtos);
        foreach (NotificationType entity in notificationType)
        {
            RepositoryManager.NotificationTypeRepository.CreateAsync(entity);
            await ServiceManager.NotificationTypeHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<NotificationTypeDto> notificationTypeDtos =
            Mapper.Map<IEnumerable<NotificationTypeDto>>(notificationType);
        return notificationTypeDtos;
    }
    
    private async Task ThrowIfListOfNotificationTypeForCreationIsNotValid(
        IEnumerable<NotificationTypeForCreationDto> notificationTypeForCreationDtos)
    {
        Dictionary<object, object> errors = new();
        foreach (NotificationTypeForCreationDto notificationTypeForCreationDto in notificationTypeForCreationDtos)
        {
            NotificationType? entity = await CheckIfExistAndGetByLabel(notificationTypeForCreationDto.Label!);
            if (entity != null)
                errors.Add(notificationTypeForCreationDto.Label!, "The label provided already exists.");
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Existing labels have been detected. Please adjust them to ensure the creation of a valid collection.", errors);
    }

    public async Task<NotificationType?> CheckIfExistAndGetById(Guid? id, bool trackChanges)
    {
        return await RepositoryManager.NotificationTypeRepository.GetByIdAsync(id,trackChanges);
    }

    private async Task<NotificationType?> CheckIfExistAndGetByLabel(string label)
    {
        return await RepositoryManager.NotificationTypeRepository.GetByLabelAsync(label, false);
    }
}