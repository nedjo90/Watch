using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.TrainingType;
using Shared.RequestFeatures;

namespace Service;

internal class TrainingTypeService : ServiceBase, ITrainingTypeService
{
    public TrainingTypeService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<TrainingTypeDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<TrainingType> trainingTypes =
            await RepositoryManager.TrainingTypeRepository.GetAllAsync(trackChanges);
        IEnumerable<TrainingTypeDto> trainingTypeDtos =
            Mapper.Map<IEnumerable<TrainingTypeDto>>(trainingTypes);
        return trainingTypeDtos;
    }

    public async Task<TrainingTypeDto> GetByIdAsync(Guid guid, bool trackChanges)
    {
        TrainingType? trainingType = await RepositoryManager.TrainingTypeRepository.GetById(guid, trackChanges);
        if (trainingType is null)
            throw new NotFoundException($"{guid} doesn't exist.");
        TrainingTypeDto? trainingTypeDto = Mapper.Map<TrainingTypeDto>(trainingType);
        
        return trainingTypeDto;
    }

    public Task<IEnumerable<TrainingTypeDto>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<TrainingTypeDto> CreateAsync(TrainingTypeForCreationDto trainingTypeForCreation)
    {
        TrainingType? trainingType =
            await RepositoryManager.TrainingTypeRepository.GetByLabel(trainingTypeForCreation.Label, false);
        if (trainingType != null)
            throw new LabelAlreadyExistBadRequest("Training Type", trainingTypeForCreation.Label!);
        trainingType = Mapper.Map<TrainingType>(trainingTypeForCreation);
        RepositoryManager.TrainingTypeRepository.CreateAsync(trainingType);
        await ServiceManager.TrainingTypeHistoryService.RegisterModification(trainingType,
            TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        TrainingTypeDto? trainingTypeDto = Mapper.Map<TrainingTypeDto>(trainingType);
        return trainingTypeDto;
    }

    public Task<(IEnumerable<TrainingTypeDto> trainingTypeDtos, string ids)> CreateCollectionAsync(IEnumerable<TrainingTypeForCreationDto> collectionOfTrainingTypeForCreation)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCollectionAsync(IEnumerable<TrainingTypeDto> trainingTypeDtos, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid guid, TrainingTypeForCreationDto trainingTypeForCreationDto, bool trackChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task<(TrainingTypeForCreationDto updateDto, TrainingType trainingType)> PatchAsync(Guid id, bool trackChanges = true)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesForPatchAsync(TrainingTypeForCreationDto trainingTypeForUpdateDto, TrainingType trainingType)
    {
        throw new NotImplementedException();
    }

    public Task<(LinkResponse linkResponse, MetaData metadata)> GetAllPagingAsync(TrainingTypeLinkParameters trainingTypeLinkParameters, string url, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}