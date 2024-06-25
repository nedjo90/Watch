using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class NotificationTypeHistoryRepository: RepositoryBase<NotificationTypeHistory>, INotificationTypeHistoryRepository
{
    public NotificationTypeHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<NotificationTypeHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegistreModification(NotificationTypeHistory notificationTypeHistory)
    {
        Create(notificationTypeHistory);
    }
}