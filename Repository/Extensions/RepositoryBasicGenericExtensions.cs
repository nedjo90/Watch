using System.Linq.Dynamic.Core;
using Entities.Models;
using Repository.Extensions.Utility;

namespace Repository.Extensions;

public static class RepositoryBasicGenericExtensions
    
{
    public static IQueryable<T> Search<T>(this IQueryable<T> entities, string searchTerm) where T : BasicGenericEntity
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return entities;
        string lowerCaseSearchTerm = searchTerm.Trim().ToLower();
        return entities.Where(e => e.Label != null && e.Label.ToLower().Contains(lowerCaseSearchTerm));
    }
    
    public static IQueryable<T> Sort<T>(this IQueryable<T> entities, string orderByQueryString) where T : BasicGenericEntity
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return entities.OrderBy(e => e.Label);
        string orderQuery = OrderQueryBuilder.CreateOrderQuery<T>(orderByQueryString);
        return string.IsNullOrWhiteSpace(orderQuery) ? 
            entities.OrderBy(e => e.Label) 
            : entities.OrderBy(orderQuery);
    }
}