using Contracts;
using Entities.Models;

namespace Repository;

public class RepositoryManagerGeneric<T> : RepositoryManager, IRepositoryManagerGeneric<T> where T : BasicEntity
{
    private readonly Lazy<IBasicRepository<T>> _basicRepository;
    public IBasicRepository<T> BasicRepository => _basicRepository.Value;
    
    public RepositoryManagerGeneric(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        _basicRepository = new Lazy<IBasicRepository<T>>(new BasicRepository<T>(repositoryContext));
    }
    
}