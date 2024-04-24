using Entities.Models;

namespace Contracts;

public interface IRepositoryManagerGeneric<TEntity> : IRepositoryManager where TEntity : BasicGenericEntity
{
    public IBasicGenericRepository<TEntity> BasicGenericRepository { get; }
}