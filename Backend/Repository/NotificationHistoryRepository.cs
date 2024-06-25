using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class NotificationHistoryRepository : RepositoryBase<NotificationHistory>, INotificationHistoryRepository
{
    public NotificationHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<NotificationHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegistreModification(NotificationHistory notificationHistory)
    {
        Create(notificationHistory);
    }
}