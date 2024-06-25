using Entities.LinkModels;
using Entities.Models;
using Shared.DataTransfertObject.TrainingType;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ITrainingTypeService
{
    Task<IEnumerable<TrainingTypeDto>> GetAllAsync(bool trackChanges);
    Task<TrainingTypeDto> GetByIdAsync(Guid guid, bool trackChanges);
    Task<IEnumerable<TrainingTypeDto>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<TrainingTypeDto> CreateAsync(TrainingTypeForCreationDto trainingTypeForCreation);
    Task<(IEnumerable<TrainingTypeDto> trainingTypeDtos, string ids)> CreateCollectionAsync
        (IEnumerable<TrainingTypeForCreationDto> collectionOfTrainingTypeForCreation);
    Task DeleteCollectionAsync(IEnumerable<TrainingTypeDto> trainingTypeDtos, bool trackChanges);
    Task DeleteAsync(Guid id, bool trackChanges);
    Task UpdateAsync(Guid guid, TrainingTypeForCreationDto trainingTypeForCreationDto, bool trackChanges);
    Task<(TrainingTypeForCreationDto updateDto, TrainingType trainingType)> PatchAsync(Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(TrainingTypeForCreationDto trainingTypeForUpdateDto, TrainingType trainingType);
    Task<(LinkResponse linkResponse, MetaData metadata)> GetAllPagingAsync
    (TrainingTypeLinkParameters trainingTypeLinkParameters, string url, bool trackChanges);
}