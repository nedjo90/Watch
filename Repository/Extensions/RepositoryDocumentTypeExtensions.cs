using Entities.Models;
using System.Linq.Dynamic.Core;
using Repository.Extensions.Utility;

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
    
    public static IQueryable<DocumentType> Sort(this IQueryable<DocumentType> documentTypes, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return documentTypes.OrderBy(e => e.Label);
        string orderQuery = OrderQueryBuilder.CreateOrderQuery<DocumentType>(orderByQueryString);
        return string.IsNullOrWhiteSpace(orderQuery) ? 
            documentTypes.OrderBy(e => e.Label) 
            : documentTypes.OrderBy(orderQuery);
    }
}