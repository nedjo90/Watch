using Contracts;
using Entities.Models;

namespace Repository;

public class NotificationRepository: RepositoryBase<Notification>, INotificationRepository
{
    public NotificationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}