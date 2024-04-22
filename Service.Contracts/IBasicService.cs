namespace Service.Contracts;

public interface IBasicService<TEntity, TMainDto, TCreationDto> 
    where TEntity : class
    where TMainDto : class
    where TCreationDto : class
{
    Task<TMainDto> GetByIdAsync(Guid guid, bool trackChanges);
    Task<TMainDto> CreateAsync(TCreationDto creationDto);
}