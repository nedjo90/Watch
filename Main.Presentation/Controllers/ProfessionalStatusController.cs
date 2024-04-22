using System.Collections;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.ProfessionalStatus;

namespace Main.Presentation.Controllers;

[Route("api/professionalstatus")]
public class ProfessionalStatusController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProfessionalStatusController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet("{id:guid}", Name = "GetProfessionalStatusById")]
    public async Task<IActionResult> GetProfessionalStatusById(Guid id)
    {
        ProfessionalStatusDto professionalStatusDto =
            await _serviceManager.ProfessionalStatus.GetProfessionalStatusByIdAsync(id, false);
        return Ok(professionalStatusDto);
    }

    [HttpGet(Name = "GetAllProfessionalStatus")]
    public async Task<IActionResult> GetAllProfessionalStatus()
    {
        IEnumerable<ProfessionalStatusDto> professionalStatus =
            await _serviceManager.ProfessionalStatus.GetAllProfessionalStatusAsync(false);
        return Ok(professionalStatus);
    }

    [HttpGet("collection/({ids})", Name = "GetProfessionalStatusCollection")]
    public async Task<IActionResult> GetProfessionalStatusCollection(string ids)
    {
        IEnumerable<ProfessionalStatusDto> professionalStatus =
            await _serviceManager.ProfessionalStatus.GetProfessionalStatusCollectionAsync(ids, false);
        return Ok(professionalStatus);
    }

    [HttpPost(Name = "CreateProfessionalStatus")]
    public async Task<IActionResult> CreateProfessionalStatus
        ([FromBody] ProfessionalStatusForCreation professionalStatusForCreation)
    {
        ProfessionalStatusDto professionalStatusDto =
            await _serviceManager.ProfessionalStatus.CreateProfessionalStatusAsync(professionalStatusForCreation);
        return CreatedAtRoute("GetProfessionalStatusById", new { Id = professionalStatusDto.Id },
            professionalStatusDto);
    }

    [HttpPost("collection", Name = "CreateProfessionalStatusCollectionAsync")]
    public async Task<IActionResult> CreateProfessionalStatusCollectionAsync
        ([FromBody] IEnumerable<ProfessionalStatusForCreation> professionalStatusForCreations)
    {
        IEnumerable<ProfessionalStatusDto> professionalStatusCollection =
            await _serviceManager.ProfessionalStatus.CreateProfessionalStatusCollectionAsync
                (professionalStatusForCreations, true);
        string ids = string.Join(',', professionalStatusCollection.Select(e => e.Id));
        return CreatedAtRoute("GetProfessionalStatusCollection", new { ids }, professionalStatusCollection);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteProfessionalStatus(Guid id)
    {
        await _serviceManager.ProfessionalStatus.DeleteProfessionalStatus(id, false);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProfessionalStatusCollection([FromBody]IEnumerable<ProfessionalStatusDto>? professionalStatusDtos)
    {
        if (professionalStatusDtos is null)
            throw new NotNullableException(professionalStatusDtos?.ToString() ?? $"body");
        await _serviceManager.ProfessionalStatus.DeleteProfessionalStatusCollection(professionalStatusDtos, false);
        return NoContent();
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateProfessionalStatus
        (Guid id, [FromBody] ProfessionalStatusForUpdateDto professionalStatusForUpdateDto)
    {
        await _serviceManager.ProfessionalStatus.UpdateProfessionalStatusAsync(id, professionalStatusForUpdateDto,
            true);
        return NoContent();
    }
}