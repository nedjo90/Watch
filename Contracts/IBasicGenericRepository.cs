namespace Contracts;

public interface IBasicGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
    Task<T?> GetById(Guid id, bool trackChanges);
    void CreateAsync(T newLabel);
    Task<IEnumerable<T>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEntity(T entity);
}