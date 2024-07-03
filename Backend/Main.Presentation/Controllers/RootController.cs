using System.Reflection;
using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Main.Presentation.Controllers;

[Route("api")]
[ApiController]
public class RootController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;
    private const string Baseurl = $"https://localhost:7184/api";

    public RootController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
    {
        if (mediaType.Contains("application/vnd.watch.apiroot"))
        {
            List<Link> list = new List<Link>
            {
                new Link
                {
                    Href = _linkGenerator.GetUriByAction(HttpContext, "GetRoot", "Root", new { }),
                    Rel = "self",
                    Method = "GET"
                }
            };
            BasicGenericLinks().ForEach((e) => list.Add(e));
            Console.WriteLine("root sent");
            return Ok(list);
        }

        return NoContent();
    }

    private List<Link> BasicGenericLinks()
    {
        List<Link> list = new List<Link>();
        IEnumerable<Type> types = GetChildControllers(typeof(ControllerBase));

        foreach (Type type in types)
        {
            string url = type.Name.Replace("Controller", "").ToLower();
            list.Add(new Link
            {
                Href = $"{Baseurl}/{url}",
                Rel = $"{url}",
                Method = "GET"
            });
            list.Add(new Link
            {
                Href = $"{Baseurl}/{url}",
                Rel = $"create_{url}",
                Method = "POST"
            });
            list.Add(new Link
            {
                Href = $"{Baseurl}/{url}",
                Rel = $"remove_{url}",
                Method = "DELETE"
            });
            list.Add(new Link
            {
                Href = $"{Baseurl}/{url}",
                Rel = $"update_{url}",
                Method = "PUT"
            });
            
        }

        return list;
    }

    private IEnumerable<Type> GetChildControllers(Type parentControllerType)
    {
        //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        Assembly assembly = Assembly.GetExecutingAssembly();
        List<Type> children = new List<Type>();
        foreach (Type type in assembly.GetTypes())
        {
            if (type.BaseType != null && type.IsClass && type.BaseType == parentControllerType)
            {
                children.Add(type);
            }
        }
        return children;
    }

    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}