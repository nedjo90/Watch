using Contracts;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared;
using Shared.DocumentType;

namespace Main.Utility;

public class DocumentTypeLinks : IDocumentTypeLinks
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IDataShaper<DocumentTypeDto> _dataShaper;

    public DocumentTypeLinks(LinkGenerator linkGenerator, IDataShaper<DocumentTypeDto> dataShaper)
    {
        _linkGenerator = linkGenerator;
        _dataShaper = dataShaper;
    }


    public LinkResponse TryGenerateLinks(IEnumerable<DocumentTypeDto> documentTypesDto, string fields, HttpContext httpContext)
    {
        List<Entity> shapedDocumentTypes = ShapeData(documentTypesDto, fields);
        
        return ShouldGenerateLinks(httpContext) ? 
            ReturnLinkedDocumentTypes(documentTypesDto, fields, httpContext, shapedDocumentTypes) 
            : ReturnShapedDocumentTypes(shapedDocumentTypes);
    }

    private List<Entity> ShapeData(IEnumerable<DocumentTypeDto> documentTypesDto, string fields)
    {
        return _dataShaper.ShapeData(documentTypesDto, fields)
            .Select(e => e.Entity)
            .ToList();
    }

    private bool ShouldGenerateLinks(HttpContext httpContext)
    {
        MediaTypeHeaderValue? mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
        return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
    }

    private LinkResponse ReturnShapedDocumentTypes(List<Entity> shapedDocumentTypes)
    {
        return new LinkResponse { ShapedEntities = shapedDocumentTypes};
    }
    
    private LinkResponse ReturnLinkedDocumentTypes(IEnumerable<DocumentTypeDto> documentTypesDto,
        string fields, HttpContext httpContext, List<Entity> shapedDocumentTypes)
    {
        List<DocumentTypeDto> documentTypesList = documentTypesDto.ToList();
        for (int index = 0; index < documentTypesList.Count; index++)
        {
            List<Link> employeeLinks = CreateLinksForDocumentType(httpContext, documentTypesList[index].Id, fields);
            shapedDocumentTypes[index].Add("Links", employeeLinks);
        }
        LinkCollectionWrapper<Entity> documentTypeCollection = new LinkCollectionWrapper<Entity>(shapedDocumentTypes);
        LinkCollectionWrapper<Entity> linkedDocumentTypes = 
            CreateLinksForDocumentTypes(httpContext, documentTypeCollection);
        return new LinkResponse { HasLinks = true, LinkedEntities = linkedDocumentTypes };
    }

    private List<Link> CreateLinksForDocumentType(HttpContext httpContext, Guid id, string fields = "")
    {
        List<Link> links =
        [
            new Link(_linkGenerator.GetUriByAction(
                    httpContext,
                    "GetDocumentType",
                    "DocumentType",
                    new { id, fields }),
                "self",
                "GET"),

            new Link(_linkGenerator.GetUriByAction(
                    httpContext,
                    "DeleteDocumentType",
                    "DocumentType",
                    new { id, fields }),
                "delete_document_type",
                "DELETE"),

            new Link(_linkGenerator.GetUriByAction(
                    httpContext,
                    "UpdateDocumentType",
                    "DocumentType",
                    new { id, fields }),
                "update_document_type",
                "PUT"),

            new Link(_linkGenerator.GetUriByAction(
                    httpContext,
                    "PartiallyUpdateDocumentType",
                    "DocumentType",
                    new { id, fields }),
                "partially_update_document_type",
                "PATCH")
        ];
        return links;
    }
    
    private LinkCollectionWrapper<Entity> CreateLinksForDocumentTypes(HttpContext httpContext,
        LinkCollectionWrapper<Entity> documentTypesWrapper)
    {
        documentTypesWrapper.Links.Add(
            new Link(
                _linkGenerator
                    .GetUriByAction(
                        httpContext,
                        "GetDocumentTypes", 
                        "DocumentType",
                        new {}), 
                "self", 
                "GET"));
        return documentTypesWrapper;
    }


}