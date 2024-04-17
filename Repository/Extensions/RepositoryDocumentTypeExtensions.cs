using Entities.Models;

namespace Repository.Extensions;

public static class RepositoryDocumentTypeExtensions
{
    public static IQueryable<DocumentType> Search(this IQueryable<DocumentType> documentTypes, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return documentTypes;
        string lowerCaseSearchTerm = searchTerm.Trim().ToLower();
        return documentTypes.Where(e => e.Label != null && e.Label.ToLower().Contains(lowerCaseSearchTerm));
    }
}