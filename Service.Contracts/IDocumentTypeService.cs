using Entities.Models;
using Shared;

namespace Service.Contracts;

public interface IDocumentTypeService
{
    IEnumerable<DocumentTypeDto> GetAllDocumentTypes(bool trackChanges);
    DocumentTypeDto GetDocumentType(Guid documentType, bool trackChanges);
    DocumentTypeDto CreateDocumentType(DocumentTypeForCreationDto documentTypeForCreationDto);
}