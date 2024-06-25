using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.ProfessionalStatusHistory;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessionalStatusHistoryController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProfessionalStatusHistoryController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<ProfessionalStatusHistoryDto> professionalStatusHistoryDto =
            await _service.ProfessionalStatusHistoryService.GetAllAsync(false);
        return Ok(professionalStatusHistoryDto);
    }
    
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}