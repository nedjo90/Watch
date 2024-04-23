using Entities.Exceptions;
using Entities.Models;
using Main.Presentation.ActionFilter;
using Main.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.LateMissStatus;

namespace Main.Presentation.Controllers;

[Route("api/latemissstatus")]
[ApiController]
public class LateMissStatusController : ControllerBase
{
    private readonly IServiceManagerBasicGeneric
        <LateMissStatus, LateMissStatusDto, LateMissStatusForCreationDto, LateMissStatusForUpdateDto> _service;
    public LateMissStatusController
        (IServiceManagerBasicGeneric<LateMissStatus, LateMissStatusDto, LateMissStatusForCreationDto, LateMissStatusForUpdateDto> serviceManagerBasicGeneric)
    {
        _service = serviceManagerBasicGeneric;
    }
    
    [HttpGet(Name = "GetAllLateMissStatus")]
    public async Task<IActionResult> GetAllLateMissStatus()
    {
        IEnumerable<LateMissStatusDto> lateMissStatusDto =
            await _service.BasicService.GetAllAsync(false);
        return Ok(lateMissStatusDto);
    }

    [HttpGet("{id:guid}", Name = "GetLateMissStatusById")]
    public async Task<IActionResult> GetLateMissStatusById(Guid id)
    {
        LateMissStatusDto lateMissStatusDto =
            await _service.BasicService.GetByIdAsync(id, false);
        return Ok(lateMissStatusDto);
    }
    
    [HttpGet("collection/({ids})", Name = "GetLateMissStatusCollection")]
    public async Task<IActionResult> GetDocumentTypeCollection
        ([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            await _service.BasicService.GetCollectionAsync(ids, false);
        return Ok(lateMissStatusDtos);
    }

    [HttpPost(Name = "CreateLateMissStatus")]
    public async Task<IActionResult> CreateLateMissStatus(
        [FromBody] LateMissStatusForCreationDto lateMissStatusForCreationDto)
    {
        LateMissStatusDto lateMissStatusDto = await _service.BasicService.CreateAsync(lateMissStatusForCreationDto);
        return CreatedAtRoute
            ("GetLateMissStatusById", new { Id = lateMissStatusDto.Id }, lateMissStatusDto);
    }
    
    [HttpPost("collection", Name = "CreateCollectionOfLateMissStatus")]
    public async Task<IActionResult> CreateLateMissStatusCollection
        ([FromBody]IEnumerable<LateMissStatusForCreationDto> lateMissStatusForCreations)
    {
        (IEnumerable<LateMissStatusDto> LateMissStatusDtos, string ids) result =
            await _service.BasicService.CreateCollectionAsync(lateMissStatusForCreations);
        return CreatedAtRoute
            ("DocumentTypeCollection", new { result.ids }, result.LateMissStatusDtos);
    }
    
    [HttpDelete("{id:guid}", Name = "DeleteLateMissStatus")]
    public async Task<IActionResult> DeleteLateMissStatus
        (Guid id)
    {
        await _service.BasicService.DeleteAsync(id, false);
        return NoContent();
    }
    
    [HttpDelete("collection", Name = "DeleteCollectionOfLateMissStatus")]
    public async Task<IActionResult> DeleteLateMissStatusCollection
        ([FromBody]IEnumerable<LateMissStatusDto> lateMissStatusDtos)
    {
        await _service.BasicService.DeleteCollectionAsync(lateMissStatusDtos, false);
        return NoContent();
    }
    
    [HttpPut("{id:guid}", Name = "UpdateLateMissStatus")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateLateMissStatus
        (Guid id, [FromBody] LateMissStatusForUpdateDto lateMissStatusForUpdateDto)
    {
        await _service.BasicService.UpdateAsync(id, lateMissStatusForUpdateDto, true);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}", Name = "PartiallyUpdateLateMissStatus")]
    public async Task<IActionResult> PartiallyUpdateDocumentType
        (Guid id, [FromBody]JsonPatchDocument<LateMissStatusForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new NullObjectException($"patchDoc for {id}");
        (LateMissStatusForUpdateDto lateMissStatusForUpdateDto, LateMissStatus lateMissStatus) result =
            await _service.BasicService.PatchAsync(id, true);
        patchDoc.ApplyTo(result.lateMissStatusForUpdateDto, ModelState);
        TryValidateModel(result.lateMissStatusForUpdateDto);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.BasicService.SaveChangesForPatchAsync
            (result.lateMissStatusForUpdateDto, result.lateMissStatus);
        return NoContent();
    }
}