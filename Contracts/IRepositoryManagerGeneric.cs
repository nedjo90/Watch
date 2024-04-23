namespace Contracts;

public interface IRepositoryManagerGeneric<T> : IRepositoryManager where T : class
{
    public IBasicGenericRepository<T> BasicGenericRepository { get; }
}