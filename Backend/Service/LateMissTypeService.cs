using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissType;

namespace Service;

internal class LateMissTypeService : ServiceBase, ILateMissTypeService
{
    public LateMissTypeService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }
    
    
    public async Task<IEnumerable<LateMissTypeDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissType> lateMissType =
            await RepositoryManager.LateMissTypeRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissTypeDto> lateMissTypeDtos =
            Mapper.Map<IEnumerable<LateMissTypeDto>>(lateMissType);
        return lateMissTypeDtos;
    }

    public async Task<LateMissTypeDto?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        LateMissType? lateMissType =
            await RepositoryManager.LateMissTypeRepository.GetById(id, trackChanges);
        if (lateMissType == null)
            throw new IdNotFoundException(id, "Late Miss Type");
        LateMissTypeDto lateMissTypeDto = Mapper.Map<LateMissTypeDto>(lateMissType);
        return lateMissTypeDto;
    }

    public async Task<IEnumerable<LateMissTypeDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<LateMissType> lateMissType =
            await RepositoryManager.LateMissTypeRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<LateMissTypeDto> lateMissTypeDtos =
            Mapper.Map<IEnumerable<LateMissTypeDto>>(lateMissType);
        return lateMissTypeDtos;
    }

    public async Task<LateMissTypeDto> CreateAsync(LateMissTypeForCreationDto lateMissTypeForCreationDto)
    {
        LateMissType? lateMissType = await CheckIfExistAndGetByLabel(lateMissTypeForCreationDto.Label);
        if (lateMissType != null)
            throw new LabelAlreadyExistBadRequest("Late Miss Type", lateMissTypeForCreationDto.Label!);
        lateMissType = Mapper.Map<LateMissType>(lateMissTypeForCreationDto);
        RepositoryManager.LateMissTypeRepository.CreateAsync(lateMissType);
        await ServiceManager.LateMissTypeHistoryService.RegisterModification(lateMissType,
            TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        LateMissTypeDto lateMissTypeDto = Mapper.Map<LateMissTypeDto>(lateMissType);
        return lateMissTypeDto;
    }

    public async Task<IEnumerable<LateMissTypeDto>> CreateCollectionAsync(IEnumerable<LateMissTypeForCreationDto> lateMissTypeForCreationDtos)
    {
        await ThrowIfListOfLateMissTypeForCreationIsNotValid(lateMissTypeForCreationDtos);
        IEnumerable<LateMissType?> lateMissType =
            Mapper.Map<IEnumerable<LateMissType>>(lateMissTypeForCreationDtos);
        foreach (LateMissType entity in lateMissType)
        {
            RepositoryManager.LateMissTypeRepository.CreateAsync(entity);
            await ServiceManager.LateMissTypeHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<LateMissTypeDto> lateMissTypeDtos =
            Mapper.Map<IEnumerable<LateMissTypeDto>>(lateMissType);
        return lateMissTypeDtos;
    }
    private async Task ThrowIfListOfLateMissTypeForCreationIsNotValid(
        IEnumerable<LateMissTypeForCreationDto> lateMissTypeForCreationDtos)
    {
        Dictionary<object, object> errors = new();
        foreach (LateMissTypeForCreationDto lateMissTypeForCreationDto in lateMissTypeForCreationDtos)
        {
            LateMissType? entity = await CheckIfExistAndGetByLabel(lateMissTypeForCreationDto.Label!);
            if (entity != null)
                errors.Add(lateMissTypeForCreationDto.Label!, "The label provided already exists.");
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Existing labels have been detected. Please adjust them to ensure the creation of a valid collection.", errors);
    }
    
    
    public async Task<LateMissType?> CheckIfExistAndGetById(Guid? id, bool trackChanges = false)
    {
        return await RepositoryManager.LateMissTypeRepository.GetById(id,trackChanges);
    }
    private async Task<LateMissType?> CheckIfExistAndGetByLabel(string? label)
    {
        return await RepositoryManager.LateMissTypeRepository.GetByLabelAsync(label, false);
    }
}