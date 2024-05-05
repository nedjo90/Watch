using Contracts;
using Entities.Models;

namespace Repository;

public class NotificationHistoryRepository : RepositoryBase<NotificationHistory>, INotificationHistoryRepository
{
    public NotificationHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}