using System.Collections;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.ProfessionalStatus;

namespace Service;

internal sealed class ProfessionalStatusService : ServiceBase ,IProfessionalStatusService
{
    public ProfessionalStatusService
        (IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
        : base(repositoryManager, loggerManager, mapper, documentTypeLinks) {}
    
    public async Task<ProfessionalStatusDto> GetProfessionalStatusByIdAsync(Guid id, bool trackChanges)
    {
        ProfessionalStatus? entity = await RepositoryManager.ProfessionalStatus.GetProfessionalStatusByIdAsync(id, trackChanges);
        ProfessionalStatusDto professionalStatusDto = Mapper.Map<ProfessionalStatusDto>(entity);
        return professionalStatusDto;
    }

    public async Task<ProfessionalStatusDto> CreateProfessionalStatusAsync
        (ProfessionalStatusForCreation professionalStatusForCreation)
    {
        ProfessionalStatus entity = Mapper.Map<ProfessionalStatus>(professionalStatusForCreation);
        RepositoryManager.ProfessionalStatus.CreateProfessionalStatus(entity);
        await RepositoryManager.SaveAsync();
        ProfessionalStatusDto professionalStatusDto = Mapper.Map<ProfessionalStatusDto>(entity);
        return professionalStatusDto;
    }

    public async Task<IEnumerable<ProfessionalStatusDto>> CreateProfessionalStatusCollectionAsync
        (IEnumerable<ProfessionalStatusForCreation> professionalStatusCollection, bool trackChanges)
    {
        if (professionalStatusCollection is null)
            throw new CollectionBadRequest("Professional Status");
        IEnumerable<ProfessionalStatus> entities =
            Mapper.Map<IEnumerable<ProfessionalStatus>>(professionalStatusCollection);
        foreach (ProfessionalStatus entity in entities)
        {
            RepositoryManager.ProfessionalStatus.CreateProfessionalStatus(entity);
        }
        await RepositoryManager.SaveAsync();
        IEnumerable<ProfessionalStatusDto> professionalStatus = Mapper.Map<IEnumerable<ProfessionalStatusDto>>(entities);
        return professionalStatus;
    }

    public async Task<IEnumerable<ProfessionalStatusDto>> GetAllProfessionalStatusAsync(bool trackChanges)
    {
        IEnumerable<ProfessionalStatus> entities =
            await RepositoryManager.ProfessionalStatus.GetAllProfessionalStatusAsync(trackChanges);
        IEnumerable<ProfessionalStatusDto>
            professionalStatus = Mapper.Map<IEnumerable<ProfessionalStatusDto>>(entities);
        return professionalStatus;
    }

    public async Task<IEnumerable<ProfessionalStatusDto>> GetProfessionalStatusCollectionAsync(string ids, bool trackChanges)
    {
        IEnumerable<Guid> guids = ids.Split(',').Select(e => Guid.Parse(e.Trim()));
        IEnumerable<ProfessionalStatus> entities = 
            await RepositoryManager.ProfessionalStatus.GetProfessionalStatusCollectionAsync(guids, trackChanges);
        if (guids.Count() != entities.Count())
            throw new CollectionByIdsBadRequestException();
        IEnumerable<ProfessionalStatusDto> professionalStatus =
            Mapper.Map<IEnumerable<ProfessionalStatusDto>>(entities);
        return professionalStatus;
    }

    public async Task<IEnumerable<ProfessionalStatus>> GetProfessionalStatusCollectionAsync
        (IEnumerable<ProfessionalStatusDto> professionalStatus, bool trackChanges)
    {
        IEnumerable<ProfessionalStatus> entities = 
            await RepositoryManager.ProfessionalStatus
                .GetProfessionalStatusCollectionAsync(professionalStatus, trackChanges);
        return entities;
    }

    public async Task DeleteProfessionalStatus(Guid id, bool trackChanges)
    {
        ProfessionalStatus entity = await GetProfessionalStatusAndCheckIfExistAsync(id, trackChanges);
        RepositoryManager.ProfessionalStatus.DeleteProfessionalStatusAsync(entity);
        await RepositoryManager.SaveAsync();
    }

    public async Task DeleteProfessionalStatusCollection(IEnumerable<ProfessionalStatusDto> professionalStatusDto,
        bool trackChanges)
    {
        IEnumerable<ProfessionalStatus> entities = 
            await RepositoryManager.ProfessionalStatus
                .GetProfessionalStatusCollectionAsync(professionalStatusDto, trackChanges);
        if (professionalStatusDto.Count() != entities.Count())
            throw new CollectionByIdsBadRequestException();
        foreach (ProfessionalStatus entity in entities)
            RepositoryManager.ProfessionalStatus.DeleteProfessionalStatusAsync(entity);
        await RepositoryManager.SaveAsync();
    }

    public async Task UpdateProfessionalStatusAsync
        (Guid id, ProfessionalStatusForUpdateDto professionalStatusForUpdateDto, bool trackChanges)
    {
        ProfessionalStatus entity = await GetProfessionalStatusAndCheckIfExistAsync(id, trackChanges);
        entity.Label = professionalStatusForUpdateDto.Label;
        await RepositoryManager.SaveAsync();
    }
    
    private async Task<ProfessionalStatus> GetProfessionalStatusAndCheckIfExistAsync(Guid id, bool trackChanges)
    {
        ProfessionalStatus? entity = 
            await RepositoryManager.ProfessionalStatus.GetProfessionalStatusByIdAsync(id, trackChanges);
        if (entity is null)
            throw new ProfessionalStatusNotFound(id);
        return entity;
    }
}