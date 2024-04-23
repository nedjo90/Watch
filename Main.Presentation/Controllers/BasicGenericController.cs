using System.Reflection;
using Entities.Exceptions;
using Entities.Models;
using Main.Presentation.ActionFilter;
using Main.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Basic;
using Shared.BasicGeneric;

namespace Main.Presentation.Controllers;


public abstract class BasicGenericController<TEntity, TMainDto, TCreationDto, TUpdateDto>  : ControllerBase
    where TEntity : BasicGenericEntity
    where TMainDto : BasicGenericDto
    where TCreationDto : BasicGenericForCreationDto
    where TUpdateDto : BasicGenericForUpdateDto
{
    private readonly IServiceManagerBasicGeneric
        <TEntity, TMainDto, TCreationDto, TUpdateDto> _service;

    protected BasicGenericController
        (IServiceManagerBasicGeneric<TEntity, TMainDto, TCreationDto, TUpdateDto> serviceManagerBasicGeneric)
    {
        _service = serviceManagerBasicGeneric;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<TMainDto> mainDtos =
            await _service.BasicService.GetAllAsync(false);
        return Ok(mainDtos);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        Console.WriteLine(ControllerContext.HttpContext.Request.Path);
        TMainDto mainDto =
            await _service.BasicService.GetByIdAsync(id, false);
        return Ok(mainDto);
    }
    
    [HttpGet("/collection/({ids})")]
    public async Task<IActionResult> GetCollectionAsync
        ([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        IEnumerable<TMainDto> mainDtos =
            await _service.BasicService.GetCollectionAsync(ids, false);
        return Ok(mainDtos);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TCreationDto creationDto)
    {
        TMainDto mainDto = await _service.BasicService.CreateAsync(creationDto);
        return CreatedAtRoute(new { Id = mainDto.Id }, mainDto);
    }
    
    [HttpPost("collection")]
    public async Task<IActionResult> CreateCollectionAsync
        ([FromBody]IEnumerable<TCreationDto> creationDtos)
    {
        (IEnumerable<TMainDto> mainDtos, string ids) result =
            await _service.BasicService.CreateCollectionAsync(creationDtos);
        return CreatedAtRoute(new { result.ids }, result.mainDtos);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _service.BasicService.DeleteAsync(id, false);
        return NoContent();
    }
    
    [HttpDelete("collection")]
    public async Task<IActionResult> DeleteCollectionAsync
        ([FromBody]IEnumerable<TMainDto> mainDtos)
    {
        await _service.BasicService.DeleteCollectionAsync(mainDtos, false);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAsync
        (Guid id, [FromBody] TUpdateDto updateDto)
    {
        await _service.BasicService.UpdateAsync(id, updateDto, true);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateAsync
        (Guid id, [FromBody]JsonPatchDocument<TUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new NullObjectException($"patchDoc for {id}");
        (TUpdateDto updateDto, TEntity entity) result =
            await _service.BasicService.PatchAsync(id, true);
        patchDoc.ApplyTo(result.updateDto, ModelState);
        TryValidateModel(result.updateDto);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.BasicService.SaveChangesForPatchAsync
            (result.updateDto, result.entity);
        return NoContent();
    }
}