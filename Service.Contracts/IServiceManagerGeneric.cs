namespace Service.Contracts;

public interface IServiceManagerGeneric<TEntity, TMainDto, TCreationDto>
    where TEntity : class
    where TMainDto : class
    where TCreationDto : class
{
    IBasicService<TEntity, TMainDto, TCreationDto> BasicService { get; }
}