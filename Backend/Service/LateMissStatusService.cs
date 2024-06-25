using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissStatus;

namespace Service;

internal class LateMissStatusService : ServiceBase, ILateMissStatusService
{
    public LateMissStatusService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<LateMissStatusDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissStatus> lateMissStatus =
            await RepositoryManager.LateMissStatusRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            Mapper.Map<IEnumerable<LateMissStatusDto>>(lateMissStatus);
        return lateMissStatusDtos;
    }

    public async Task<LateMissStatusDto?> GetByIdAsync(Guid? id, bool trackChanges)
    {
        LateMissStatus? lateMissStatus = await RepositoryManager.LateMissStatusRepository.GetById(id, trackChanges); 
        if (lateMissStatus == null)
            throw new IdNotFoundException(id, "Late Miss Status");
        LateMissStatusDto lateMissStatusDto = Mapper.Map<LateMissStatusDto>(lateMissStatus);
        return lateMissStatusDto;
    }

    public async Task<IEnumerable<LateMissStatusDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<LateMissStatus> lateMissStatus =
            await RepositoryManager.LateMissStatusRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            Mapper.Map<IEnumerable<LateMissStatusDto>>(lateMissStatus);
        return lateMissStatusDtos;
    }

    public async Task<LateMissStatusDto> CreateAsync(LateMissStatusForCreationDto lateMissStatusForCreationDto)
    {
        LateMissStatus? lateMissStatus = await CheckIfExistAndGetByLabel(lateMissStatusForCreationDto.Label);
        if (lateMissStatus != null)
            throw new LabelAlreadyExistBadRequest("Late Miss Status", lateMissStatusForCreationDto.Label!);
        lateMissStatus = Mapper.Map<LateMissStatus>(lateMissStatusForCreationDto);
        RepositoryManager.LateMissStatusRepository.CreateAsync(lateMissStatus);
        await ServiceManager.LateMissStatusHistoryService.RegisterModification(lateMissStatus,
            TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        LateMissStatusDto lateMissStatusDto = Mapper.Map<LateMissStatusDto>(lateMissStatus);
        return lateMissStatusDto;
    }

    public async Task<IEnumerable<LateMissStatusDto>> CreateCollectionAsync(IEnumerable<LateMissStatusForCreationDto> lateMissStatusForCreationDtos)
    {
        await ThrowIfListOfLateMissStatusForCreationIsNotValid(lateMissStatusForCreationDtos);
        IEnumerable<LateMissStatus?> lateMissStatus =
            Mapper.Map<IEnumerable<LateMissStatus>>(lateMissStatusForCreationDtos);
        foreach (LateMissStatus entity in lateMissStatus)
        {
            RepositoryManager.LateMissStatusRepository.CreateAsync(entity);
            await ServiceManager.LateMissStatusHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<LateMissStatusDto> lateMissStatusDtos =
            Mapper.Map<IEnumerable<LateMissStatusDto>>(lateMissStatus);
        return lateMissStatusDtos;
    }
    
    private async Task ThrowIfListOfLateMissStatusForCreationIsNotValid(
        IEnumerable<LateMissStatusForCreationDto> lateMissStatusForCreationDtos)
    {
        Dictionary<object, object> errors = new();
        foreach (LateMissStatusForCreationDto lateMissStatusForCreationDto in lateMissStatusForCreationDtos)
        {
            LateMissStatus? entity = await CheckIfExistAndGetByLabel(lateMissStatusForCreationDto.Label!);
            if (entity != null)
                errors.Add(lateMissStatusForCreationDto.Label!, "The label provided already exists.");
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Existing labels have been detected. Please adjust them to ensure the creation of a valid collection.", errors);
    }

    public async Task<LateMissStatus?> CheckIfExistAndGetById(Guid? id, bool trackChanges = false)
    {
        return await RepositoryManager.LateMissStatusRepository.GetById(id,trackChanges);
    }
    
    private async Task<LateMissStatus?> CheckIfExistAndGetByLabel(string? label, bool trackChanges = false)
    {
        return await RepositoryManager.LateMissStatusRepository.GetByLabelAsync(label, trackChanges);
    }
}