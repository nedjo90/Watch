using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.ProfessionalStatusHistory;

namespace Service;

internal class ProfessionalStatusHistoryService : ServiceBase, IProfessionalStatusHistoryService
{
    public ProfessionalStatusHistoryService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<ProfessionalStatusHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<ProfessionalStatusHistory> professionalStatusHistory =
            await RepositoryManager.ProfessionalStatusHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<ProfessionalStatusHistoryDto> professionalStatusHistoryDto =
            Mapper.Map<IEnumerable<ProfessionalStatusHistoryDto>>(professionalStatusHistory);
        return professionalStatusHistoryDto;
    }
    

    public async Task RegisterModification(ProfessionalStatus professionalStatus,
        string typeOfModification)
    {
        ProfessionalStatusHistory professionalStatusHistory = new ProfessionalStatusHistory();
        professionalStatusHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        professionalStatusHistory.Label = professionalStatus.Label!;
        professionalStatusHistory.ProfessionalStatusId = professionalStatus.Id;
        professionalStatusHistory.TypeOfModification = typeOfModification;
        professionalStatusHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.ProfessionalStatusHistoryRepository.RegistreModification(professionalStatusHistory);
    }
}