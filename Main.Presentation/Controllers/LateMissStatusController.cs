using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.LateMissStatus;

namespace Main.Presentation.Controllers;

[Route("api/latemissstatus")]
[ApiController]
public class LateMissStatusController : ControllerBase
{
    private readonly IServiceManagerGeneric<LateMissStatus, LateMissStatusDto, LateMissStatusForCreationDto> _service;
    public LateMissStatusController
        (IServiceManagerGeneric<LateMissStatus, LateMissStatusDto, LateMissStatusForCreationDto> serviceManagerGeneric)
    {
        _service = serviceManagerGeneric;
    }

    [HttpGet("{id:guid}", Name = "GetLateMissStatusById")]
    public async Task<IActionResult> GetLateMissStatusById(Guid id)
    {
        LateMissStatusDto lateMissStatusDto =
            await _service.BasicService.GetByIdAsync(id, false);
        return Ok(lateMissStatusDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLateMissStatus(
        [FromBody] LateMissStatusForCreationDto lateMissStatusForCreationDto)
    {
        LateMissStatusDto lateMissStatusDto = await _service.BasicService.CreateAsync(lateMissStatusForCreationDto);
        Console.WriteLine($"iiiiicccciii {lateMissStatusDto.Id}");
        return CreatedAtRoute("GetLateMissStatusById", new { Id = lateMissStatusDto.Id }, lateMissStatusDto);
    }
}