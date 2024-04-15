using Entities.Models;

namespace Service.Contracts;

public interface IDocumentTypeService
{
    IEnumerable<DocumentType> GetAllDocumentTypes(bool trackChanges);
}