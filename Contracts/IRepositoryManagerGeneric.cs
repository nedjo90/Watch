namespace Contracts;

public interface IRepositoryManagerGeneric<T> : IRepositoryManager where T : class
{
    public IBasicRepository<T> BasicRepository { get; }
}