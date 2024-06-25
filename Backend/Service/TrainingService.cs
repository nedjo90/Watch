using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.Training;

namespace Service;

internal class TrainingService : ServiceBase, ITrainingService
{
    public TrainingService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }
    


    public async Task<TrainingDto> GetByIdAsync(Guid id, bool trackChange)
    {
        Training? training = await RepositoryManager.TrainingRepository.GetByIdAsync(id, false);
        if (training is null)
            throw new NotFoundException($"{id} training does not exist.");
        TrainingDto trainingDto = Mapper.Map<TrainingDto>(training);
        return trainingDto;
    }

    public async Task<IEnumerable<TrainingDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<Training> trainingTypes =
            await RepositoryManager.TrainingRepository.GetAllAsync(trackChanges);
        IEnumerable<TrainingDto> trainingTypeDtos =
            Mapper.Map<IEnumerable<TrainingDto>>(trainingTypes);
        return trainingTypeDtos;
    }

    public async Task<TrainingDto> CreateTrainingAsync(TrainingForCreationDto trainingForCreationDto)
    {
        await CheckTrainingTypeIsExisting(trainingForCreationDto.TrainingTypeId, false);
        Training training = Mapper.Map<Training>(trainingForCreationDto);
        RepositoryManager.TrainingRepository.CreateTraining(training);
        await ServiceManager.TrainingHistoryService.RegisterModification(training,
            TypeOfModification.Created.ToString());
        await RepositoryManager.SaveAsync();
        TrainingDto trainingDto = Mapper.Map<TrainingDto>(training);
        return trainingDto;
    }

    private async Task CheckTrainingTypeIsExisting(Guid? trainingTypeId, bool trackChanges)
    {
        TrainingType? trainingType = await RepositoryManager.TrainingTypeRepository.GetById(trainingTypeId, trackChanges);
        if (trainingType is null)
            throw new NotFoundException($"{trainingTypeId} does not exist");
        
    }
}