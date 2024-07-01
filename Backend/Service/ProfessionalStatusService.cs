using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.ProfessionalStatus;
using Shared.RequestFeatures;

namespace Service;

internal class ProfessionalStatusService : ServiceBase, IProfessionalStatusService
{
    public ProfessionalStatusService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<ProfessionalStatusDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<ProfessionalStatus> professionalStatusEnumerable =
            await RepositoryManager.ProfessionalStatusRepository.GetAllAsync(trackChanges);
        IEnumerable<ProfessionalStatusDto> professionalStatusDtos =
            Mapper.Map<IEnumerable<ProfessionalStatusDto>>(professionalStatusEnumerable);
        return professionalStatusDtos;
    }

    public async Task<ProfessionalStatusDto> GetByIdAsync(Guid guid, bool trackChanges)
    {
        ProfessionalStatus? professionalStatus = 
            await RepositoryManager.ProfessionalStatusRepository.GetById(guid, trackChanges);
        if (professionalStatus is null)
            throw new IdNotFoundException(guid, "professional status");
        ProfessionalStatusDto professionalStatusDto = Mapper.Map<ProfessionalStatusDto>(professionalStatus);
        return professionalStatusDto;
    }
    public async Task<IEnumerable<ProfessionalStatusDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        IEnumerable<ProfessionalStatus> professionalStatus =
            await RepositoryManager.ProfessionalStatusRepository.GetCollectionAsync(ids, trackChanges);
        IEnumerable<ProfessionalStatusDto> professionalStatusDtos =
            Mapper.Map<IEnumerable<ProfessionalStatusDto>>(professionalStatus);
        return professionalStatusDtos;
    }
    public async Task<ProfessionalStatusDto> CreateAsync(ProfessionalStatusForCreationDto professionalStatusForCreation)
    {
        ProfessionalStatus? professionalStatus = await CheckIfExistAndGetByLabel(professionalStatusForCreation.Label!);
        if (professionalStatus != null)
            throw new LabelAlreadyExistBadRequest("Professional Status", professionalStatusForCreation.Label!);
        professionalStatus = Mapper.Map<ProfessionalStatus>(professionalStatusForCreation);
        RepositoryManager.ProfessionalStatusRepository.CreateAsync(professionalStatus);
        await ServiceManager.ProfessionalStatusHistoryService.RegisterModification(professionalStatus, TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        ProfessionalStatusDto professionalStatusDto = Mapper.Map<ProfessionalStatusDto>(professionalStatus);
        return professionalStatusDto;
    }
    public async Task<IEnumerable<ProfessionalStatusDto>> CreateCollectionAsync(IEnumerable<ProfessionalStatusForCreationDto> professionalStatusForCreationDtos)
    {
        await ThrowIfListOfProfessionalStatusForCreationIsNotValid(professionalStatusForCreationDtos);
        IEnumerable<ProfessionalStatus?> professionalStatus =
            Mapper.Map<IEnumerable<ProfessionalStatus>>(professionalStatusForCreationDtos);
        foreach (ProfessionalStatus entity in professionalStatus)
        {
            RepositoryManager.ProfessionalStatusRepository.CreateAsync(entity);
            await ServiceManager.ProfessionalStatusHistoryService.RegisterModification(entity, TypeOfModification.Created.ToString());
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<ProfessionalStatusDto> professionalStatusDtos =
            Mapper.Map<IEnumerable<ProfessionalStatusDto>>(professionalStatus);
        return professionalStatusDtos;
    }
    
    private async Task ThrowIfListOfProfessionalStatusForCreationIsNotValid(
        IEnumerable<ProfessionalStatusForCreationDto> professionalStatusForCreationDtos)
    {
        List<object> errors = new();
        foreach (ProfessionalStatusForCreationDto professionalStatusForCreationDto in professionalStatusForCreationDtos)
        {
            ProfessionalStatus? entity = await CheckIfExistAndGetByLabel(professionalStatusForCreationDto.Label!);
            if (entity != null)
                errors.Add(
                    new
                    {
                        professionalStatusForCreationDto.Label,
                        Detail = "The label provided already exists."
                    });
        }
        if (errors.Count > 0)
            throw new BadRequestMultipleException("Existing labels have been detected. Please adjust them to ensure the creation of a valid collection.", errors);
    }
    public async Task<ProfessionalStatus?> CheckIfExistAndGetById(Guid? id, bool trackChanges)
    {
        return await RepositoryManager.ProfessionalStatusRepository.GetById(id, trackChanges);
    }
    private async Task<ProfessionalStatus?> CheckIfExistAndGetByLabel(string label)
    {
        return await RepositoryManager.ProfessionalStatusRepository.GetByLabel(label, false);
    }
}