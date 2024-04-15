namespace Contracts;

public interface IRepositoryManager
{
    public IDocumentTypeRepository? DocumentType { get; }
    void Save();
}