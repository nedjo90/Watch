using Microsoft.AspNetCore.Mvc;

namespace Main.Presentation.Controllers;

[Route("api/professionalstatus")]
public class ProfessionalStatusController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProfessionalStatus(System.Guid id)
    {
        
    }
}