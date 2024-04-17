using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDocumentTypeRepository
{
    Task<IEnumerable<DocumentType>> GetAllDocumentTypesAsync(bool trackChanges);
    Task<PagedList<DocumentType>> GetAllDocumentTypesPagingAsync(DocumentTypeParameters documentTypeParameters,
        bool trackChanges);
    Task<DocumentType?> GetDocumentTypeAsync(Guid documentTypeId, bool trackChanges);
    void CreateDocumentType(DocumentType? documentType);
    Task<IEnumerable<DocumentType>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteDocumentType(DocumentType documentType);
}