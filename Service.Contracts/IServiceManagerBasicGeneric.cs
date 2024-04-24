using Entities.Models;
using Shared.BasicGeneric;

namespace Service.Contracts;

public interface IServiceManagerBasicGeneric<TEntity, TMainDto, TCreationDto,TUpdateDto>
    where TEntity : BasicGenericEntity
    where TMainDto : BasicGenericDto
    where TCreationDto : BasicGenericForCreationDto
    where TUpdateDto : BasicGenericForUpdateDto
{
    IBasicService<TEntity, TMainDto, TCreationDto, TUpdateDto> BasicService { get; }
}