using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.Notification;

namespace Main.Mapping;

public class NotificationMapping : Profile
{
    public NotificationMapping()
    {
        CreateMap<Notification, NotificationDto>();
        CreateMap<NotificationForCreationDto, Notification>();
        CreateMap<NotificationForUpdateDto, Notification>();
        CreateMap<NotificationForUpdateDto, Notification>().ReverseMap();
    }
}