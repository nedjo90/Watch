using System.Runtime.InteropServices;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.LateMiss;

namespace Service;

internal class LateMissService: ServiceBase, ILateMissService
{
    public LateMissService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<LateMissDto> GetByIdAsync(Guid id, bool trackChanges)
    {
        LateMiss? lateMiss =
            await RepositoryManager.LateMissRepository.GetByIdAsync(id, trackChanges);
        if (lateMiss == null)
            throw new IdNotFoundException(id, "Late Miss");
        LateMissDto lateMissDto = Mapper.Map<LateMissDto>(lateMiss);
        return lateMissDto;
    }

    public async Task<IEnumerable<LateMissDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMiss> lateMisses =
            await RepositoryManager.LateMissRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissDto> lateMissDtos =
            Mapper.Map<IEnumerable<LateMissDto>>(lateMisses);
        return lateMissDtos;
    }
    
    public async Task<IEnumerable<LateMissDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<LateMiss> lateMiss =
            await RepositoryManager.LateMissRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<LateMissDto> lateMissDtos =
            Mapper.Map<IEnumerable<LateMissDto>>(lateMiss);
        return lateMissDtos;
    }

    public async Task<LateMissDto> CreateAsync(LateMissForCreationDto lateMissForCreationDto)
    {
        await ThrowIfLateMissForCreationIsNotValid(lateMissForCreationDto);
        LateMiss lateMiss = Mapper.Map<LateMiss>(lateMissForCreationDto);
        lateMiss.DeclarationDate = DateTime.UtcNow;
        RepositoryManager.LateMissRepository.CreateAsync(lateMiss);
        await ServiceManager.LateMissHistoryService
            .RegisterModification(
                lateMiss,
                TypeOfModification.Created.ToString()
                );
        await RepositoryManager.SaveAsync();
        LateMissDto lateMissDto = Mapper.Map<LateMissDto>(lateMiss);
        return lateMissDto;
    }

    public async Task<IEnumerable<LateMissDto>> CreateCollectionAsync(IEnumerable<LateMissForCreationDto> lateMissForCreationDtos)
    {
        await ThrowIfListOfLateMissForCreationIsNotValid(lateMissForCreationDtos);
        IEnumerable<LateMiss?> lateMiss =
            Mapper.Map<IEnumerable<LateMiss>>(lateMissForCreationDtos);
        foreach (LateMiss entity in lateMiss)
        {
            RepositoryManager.LateMissRepository.CreateAsync(entity);
            await ServiceManager.LateMissHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<LateMissDto> lateMissDtos =
            Mapper.Map<IEnumerable<LateMissDto>>(lateMiss);
        return lateMissDtos;
    }
    
    private async Task ThrowIfListOfLateMissForCreationIsNotValid(IEnumerable<LateMissForCreationDto> lateMissForCreationDtos)
    {
        List<object> errors = new ();
        foreach (LateMissForCreationDto lateMissForCreationDto in lateMissForCreationDtos)
        {
            List<object> specificError = await ReturnListOfErrors(lateMissForCreationDto);
            if (specificError.Count > 0)
                errors.Add(specificError);
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException(
                "Invalid late Miss information detected. Please provide valid informations.", errors);
    }

    private async Task ThrowIfLateMissForCreationIsNotValid(LateMissForCreationDto lateMissForCreationDto)
    {
        List<object> errors = await ReturnListOfErrors(lateMissForCreationDto);
        if (errors.Count > 0)
            throw new BadRequestMultipleException(
                "Invalid late miss information detected. Please provide valid informations.", errors);
    }

    public async Task<LateMiss?> CheckIfExistAndGetByIdAsync(Guid? lateMiss)
    {
        return await RepositoryManager.LateMissRepository.GetByIdAsync(lateMiss, false);
    }

    private async Task<List<object>> ReturnListOfErrors(LateMissForCreationDto lateMissForCreationDto)
    {
        List<object> errors = new();
        if (await ServiceManager.LateMissStatusService.CheckIfExistAndGetById(lateMissForCreationDto.LateMissStatusId, false) == null)
            errors.Add(
            new {
                lateMissForCreationDto.LateMissStatusId,
                detail = "Late Miss Status Id doesn't exist."
            });
        if (await ServiceManager.LateMissTypeService.CheckIfExistAndGetById(lateMissForCreationDto.LateMissTypeId, false) == null)
            errors.Add(
            new {
                lateMissForCreationDto.LateMissTypeId,
                detail = "Late Miss Type Id doesn't exist."
            });
        if(await ServiceManager.UserService.CheckIfUserIdIsExisting(lateMissForCreationDto.UserId) == false)
            errors.Add(
            new {
                lateMissForCreationDto.UserId,
                detail = "User Id doesn't exist."
            });
        return errors;
    }
}