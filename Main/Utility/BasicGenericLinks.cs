using System.Collections.Specialized;
using Contracts;
using Entities.LinkModels;
using Entities.Models;
using Shared.BasicGeneric;
using Microsoft.Net.Http.Headers;


namespace Main.Utility;

public class BasicGenericLinks<TMainDto> : IBasicGenericLinks<TMainDto>
where TMainDto : BasicGenericDto
{
    
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<TMainDto> _dataShaper;

    public BasicGenericLinks(LinkGenerator linkGenerator, IDataShaper<TMainDto> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }
    
    public LinkResponse TryGenerateLinks(IEnumerable<TMainDto> mainDtos, string fields, HttpContext httpContext, string url = "")
    {
        List<Entity> shapedBasicGenerics = ShapeData(mainDtos, fields);
        
        return ShouldGenerateLinks(httpContext) ? 
            ReturnLinkedBasicGenerics(mainDtos, fields, httpContext, shapedBasicGenerics, url) 
            : ReturnShapedBasicGenerics(shapedBasicGenerics);
    }
    
        private List<Entity> ShapeData(IEnumerable<TMainDto> mainDtos, string fields)
    {
        return _dataShaper.ShapeData(mainDtos, fields)
            .Select(e => e.Entity)
            .ToList();
    }

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        MediaTypeHeaderValue? mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedBasicGenerics(List<Entity> shapedBasicGenerics)
    {
        return new LinkResponse { ShapedEntities = shapedBasicGenerics};
    }
    
    private LinkResponse ReturnLinkedBasicGenerics
        (IEnumerable<TMainDto> mainDtos, string fields, HttpContext httpContext, List<Entity> shapedBasicGenerics, string url)
    {
        List<TMainDto> basicGenericList = mainDtos.ToList();
        for (int index = 0; index < basicGenericList.Count; index++)
        {
            List<Link> employeeLinks = CreateLinksForBasicGeneric(httpContext, basicGenericList[index].Id, fields, url);
            shapedBasicGenerics[index].Add("Links", employeeLinks);
        }
        LinkCollectionWrapper<Entity> basicGenericsWrapper = new LinkCollectionWrapper<Entity>(shapedBasicGenerics);
        LinkCollectionWrapper<Entity> linkedBasicGenerics = 
            CreateLinksForBasicGenerics(httpContext, basicGenericsWrapper, url);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedBasicGenerics };
    }

    private List<Link> CreateLinksForBasicGeneric(HttpContext httpContext, Guid id, string fields = "", string url = "")
    {
        List<Link> links =
        [
            new Link(
            $"{url}/{id}",
                "self",
                "GET"),

            new Link($"{url}/{id}",
                "delete_document_type",
                "DELETE"),

            new Link($"{url}/{id}",
                "update_document_type",
                "PUT"),

            new Link($"{url}/{id}",
                "partially_update_document_type",
                "PATCH")
        ];
        return links;
    }
    
    private LinkCollectionWrapper<Entity> CreateLinksForBasicGenerics(HttpContext httpContext,
        LinkCollectionWrapper<Entity> basicGenericsWrapper, string url = "")
    {
        basicGenericsWrapper.Links.Add(
            new Link(
                $"{url}", 
                "self", 
                "GET"));
        return basicGenericsWrapper;
    }
}