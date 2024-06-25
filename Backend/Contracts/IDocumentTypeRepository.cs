using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDocumentTypeRepository
{
    Task<IEnumerable<DocumentType>> GetAllAsync(bool trackChanges);
    Task<DocumentType?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<DocumentType?> GetByLabelAsync(string label, bool trackChanges); 
    void CreateAsync(DocumentType documentType);
    Task<IEnumerable<DocumentType>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    
    void DeleteEntity(DocumentType entity);
    Task<PagedList<DocumentType>> GetAllPagingAsync(DocumentTypeParameters trainingTypeParameters, bool trackChanges);
}