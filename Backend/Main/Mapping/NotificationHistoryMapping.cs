using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.NotificationHistory;

namespace Main.Mapping;

public class NotificationHistoryMapping : Profile
{
    public NotificationHistoryMapping()
    {
        CreateMap<NotificationHistory, NotificationHistoryDto>();
        CreateMap<Notification, NotificationHistory>();
    }
}