using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.ProfessionalStatus;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessionalStatusController : BasicGenericController<ProfessionalStatus,ProfessionalStatusDto,ProfessionalStatusForCreationDto, ProfessionalStatusForUpdateDto>
{
    public ProfessionalStatusController
        (IServiceManagerBasicGeneric
            <ProfessionalStatus, ProfessionalStatusDto, ProfessionalStatusForCreationDto, ProfessionalStatusForUpdateDto> serviceManagerBasicGeneric) 
        : base(serviceManagerBasicGeneric)
    {
    }
}