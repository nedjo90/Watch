using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Main.Presentation.ActionFilter;
using Main.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.BasicGeneric;
using Shared.RequestFeatures;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
    [HttpHead]
    [ResponseCache(Duration = 60)]
    public async Task<IActionResult> GetAllAsync()
    {
        IEnumerable<TMainDto> mainDtos =
            await _service.BasicService.GetAllAsync();
        return Ok(mainDtos);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        TMainDto mainDto =
            await _service.BasicService.GetByIdAsync(id);
        return Ok(mainDto);
    }
    
    [HttpGet("collection/({ids})")]
    public async Task<IActionResult> GetCollectionAsync
        ([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
    {
        IEnumerable<TMainDto> mainDtos =
            await _service.BasicService.GetCollectionAsync(ids);
        return Ok(mainDtos);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TCreationDto creationDto)
    {
        TMainDto mainDto = await _service.BasicService.CreateAsync(creationDto);
        return CreatedAtRoute(new { mainDto.Id }, mainDto);
    }
    
    [HttpPost("collection")]
    public async Task<IActionResult> CreateCollectionAsync
        ([FromBody]IEnumerable<TCreationDto> creationDtos)
    {
        (IEnumerable<TMainDto> mainDtos, string ids) result =
            await _service.BasicService.CreateCollectionAsync(creationDtos);
        string uri = $"https://localhost:7184/api/{ControllerContext.ActionDescriptor.ControllerName.ToLower()}/collection/({result.ids})";
        return Created(uri, result.mainDtos);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _service.BasicService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpDelete("collection")]
    public async Task<IActionResult> DeleteCollectionAsync
        ([FromBody]IEnumerable<TMainDto> mainDtos)
    {
        await _service.BasicService.DeleteCollectionAsync(mainDtos);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAsync
        (Guid id, [FromBody] TUpdateDto updateDto)
    {
        await _service.BasicService.UpdateAsync(id, updateDto);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateAsync
        (Guid id, [FromBody]JsonPatchDocument<TUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new NullObjectException($"patchDoc for {id}");
        (TUpdateDto updateDto, TEntity entity) result =
            await _service.BasicService.PatchAsync(id);
        patchDoc.ApplyTo(result.updateDto, ModelState);
        TryValidateModel(result.updateDto);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _service.BasicService.SaveChangesForPatchAsync
            (result.updateDto, result.entity);
        return NoContent();
    }
    
    [HttpGet("page")]
    [HttpHead("page")]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetDocumentTypesPaging([FromQuery]BasicGenericParameters basicGenericParameters)
    {
        LinkParameters linkParams =
            new LinkParameters(basicGenericParameters, HttpContext);

        (LinkResponse linkResponse, MetaData metadata) pagedResult =
            await _service.BasicService.GetAllPagingAsync(linkParams, $"https://localhost:7184/api/{ControllerContext.ActionDescriptor.ControllerName.ToLower()}");
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(pagedResult.metadata);
        return pagedResult.linkResponse.HasLinks ?
            Ok(pagedResult.linkResponse.LinkedEntities)
            : Ok(pagedResult.linkResponse.ShapedEntities);
    }
    
    [HttpOptions]
    public IActionResult GetCompaniesOptions()
    {
        Response.Headers["Allow"] = "GET, PUT, DELETE, POST, PATCH, OPTIONS";
        return Ok();
    }
}