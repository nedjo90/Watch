using Entities.Models;
using Shared;

namespace Service.Contracts;

public interface IDocumentTypeService
{
    IEnumerable<DocumentTypeDto> GetAllDocumentTypes(bool trackChanges);
    DocumentTypeDto GetDocumentType(Guid documentType, bool trackChanges);
    DocumentTypeDto CreateDocumentType(DocumentTypeForCreationDto documentTypeForCreationDto);
    IEnumerable<DocumentTypeDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<DocumentTypeDto> documentTypeDtos, string ids) CreateDocumentTypeCollection
        (IEnumerable<DocumentTypeForCreationDto> documentTypeCollection);
    void DeleteDocumentType(Guid documentTypeId, bool trackChanges);
    void DeleteDocumentTypeCollection(IEnumerable<DocumentTypeDto> ids, bool trackChanges);

    void UpdateDocumentType(Guid documentTypeId, DocumentTypeForUpdateDto documentTypeForUpdateDto, bool trackChanges);
}