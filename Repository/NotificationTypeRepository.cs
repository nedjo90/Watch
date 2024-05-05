using Contracts;
using Entities.Models;
using Shared.RequestFeatures;

namespace Repository;

public class NotificationTypeRepository : RepositoryBase<NotificationType>, INotificationTypeRepository
{
    public NotificationTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public Task<IEnumerable<NotificationType>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<NotificationType?> GetById(Guid? id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAsync(NotificationType newLabel)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<NotificationType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
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