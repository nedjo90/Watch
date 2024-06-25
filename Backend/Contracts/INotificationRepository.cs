using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models;

namespace Contracts;

public interface INotificationRepository
{
    Task<Notification?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<IEnumerable<Notification>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<Notification>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void CreateAsync(Notification notification);
}