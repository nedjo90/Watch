namespace Contracts;

public interface IBasicRepository<T> where T : class
{
    Task<T?> GetById(Guid id, bool trackChanges);
    void CreateAsync(T newLabel);
}