using Shared.DataTransfertObject.Training;

namespace Service.Contracts;

public interface ITrainingService
{
    Task<TrainingDto> GetByIdAsync(Guid id, bool trackChange);
    Task<IEnumerable<TrainingDto>> GetAllAsync(bool trackChanges);
    Task<TrainingDto> CreateTrainingAsync(TrainingForCreationDto trainingForCreationDto);
}