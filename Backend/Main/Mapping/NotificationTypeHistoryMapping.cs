using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.NotificationTypeHistory;

namespace Main.Mapping;

public class NotificationTypeHistoryMapping : Profile
{
    public NotificationTypeHistoryMapping()
    {
        CreateMap<NotificationTypeHistory, NotificationTypeHistoryDto>();
        CreateMap<NotificationType, NotificationTypeHistory>();
    }
}