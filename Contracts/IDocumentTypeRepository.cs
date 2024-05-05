using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDocumentTypeRepository
{
    Task<IEnumerable<DocumentType>> GetAllAsync(bool trackChanges);
    Task<DocumentType?> GetById(Guid? id, bool trackChanges);
    void CreateAsync(DocumentType newLabel);
    Task<IEnumerable<DocumentType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEntity(DocumentType entity);
    Task<PagedList<DocumentType>> GetAllPagingAsync(DocumentTypeParameters trainingTypeParameters, bool trackChanges);
}