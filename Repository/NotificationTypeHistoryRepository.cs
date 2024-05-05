using Contracts;
using Entities.Models;

namespace Repository;

public class NotificationTypeHistoryRepository: RepositoryBase<NotificationTypeHistory>, INotificationTypeHistoryRepository
{
    public NotificationTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}