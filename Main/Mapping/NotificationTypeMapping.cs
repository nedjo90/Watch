using AutoMapper;
using Entities.Models;
using Shared.NotificationType;

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