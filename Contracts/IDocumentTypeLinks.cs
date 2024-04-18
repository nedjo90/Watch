using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared;
using Shared.DocumentType;

namespace Contracts;

public interface IDocumentTypeLinks
{
    public LinkResponse TryGenerateLinks
        (IEnumerable<DocumentTypeDto> documentTypesDto, string fields, HttpContext httpContext);
}