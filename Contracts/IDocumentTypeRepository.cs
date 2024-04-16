using Entities.Models;

namespace Contracts;

public interface IDocumentTypeRepository
{
    IEnumerable<DocumentType> GetAllDocumentTypes(bool trackChanges);
    DocumentType GetDocumentType(Guid documentTypeId, bool trackChanges);
    void CreateDocumentType(DocumentType? documentType);
    IEnumerable<DocumentType> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteDocumentType(DocumentType documentType);
}