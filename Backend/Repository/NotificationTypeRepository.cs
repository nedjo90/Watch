using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class NotificationTypeRepository : RepositoryBase<NotificationType>, INotificationTypeRepository
{
    public NotificationTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<NotificationType>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(false).ToListAsync();
    }

    public async Task<NotificationType?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }

    public async Task<NotificationType?> GetByLabelAsync(string label, bool trackChanges)
    {
        return await FindByCondition(e => e.Label!.Equals(label), trackChanges)
            .FirstOrDefaultAsync();
    }

    public void CreateAsync(NotificationType notificationType)
    {
        Create(notificationType);
    }

    public async Task<IEnumerable<NotificationType>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void DeleteEntity(NotificationType entity)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<NotificationType>> GetAllPagingAsync(NotificationTypeParameters trainingTypeParameters, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}