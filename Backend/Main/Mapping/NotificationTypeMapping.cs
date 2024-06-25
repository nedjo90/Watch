using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.NotificationType;

namespace Main.Mapping;

public class NotificationTypeMapping : Profile
{
    public NotificationTypeMapping()
    {
        CreateMap<NotificationType, NotificationTypeDto>();
        CreateMap<NotificationTypeForCreationDto, NotificationType>();
        CreateMap<NotificationTypeForUpdateDto, NotificationType>();
        CreateMap<NotificationTypeForUpdateDto, NotificationType>().ReverseMap();
    }
}