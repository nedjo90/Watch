using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class NotificationRepository: RepositoryBase<Notification>, INotificationRepository
{
    public NotificationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Notification>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public async Task<Notification?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateAsync(Notification notification)
    {
        Create(notification);
    }
}