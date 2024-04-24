using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared.BasicGeneric;
namespace Contracts;

public interface IBasicGenericLinks<TMainDto>
    where TMainDto : BasicGenericDto
{
    public LinkResponse TryGenerateLinks
        (IEnumerable<TMainDto> mainDtos, string fields, HttpContext httpContext, string url = "");
}