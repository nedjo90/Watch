using Entities.Models;

namespace Contracts;

public interface IDocumentTypeRepository
{
    IEnumerable<DocumentType> GetAllDocumentTypes(bool trackChanges);
}