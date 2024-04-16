using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IDocumentTypeRepository> _documentTypeRepository;
    public IDocumentTypeRepository DocumentType => _documentTypeRepository.Value;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _documentTypeRepository = 
            new Lazy<IDocumentTypeRepository>(() => new DocumentTypeRepository(repositoryContext));
    }


    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
}