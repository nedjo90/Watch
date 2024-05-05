using Shared.Training;

namespace Service.Contracts;

public interface ITrainingService
{
    Task<TrainingDto> GetByIdAsync(Guid id, bool trackChange);
    Task<TrainingDto> CreateTrainingAsync(TrainingForCreationDto trainingForCreationDto);
}