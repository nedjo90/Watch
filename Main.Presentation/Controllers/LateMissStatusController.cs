using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.LateMissStatus;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LateMissStatusController : BasicGenericController<LateMissStatus,LateMissStatusDto,LateMissStatusForCreationDto, LateMissStatusForUpdateDto>
{
    public LateMissStatusController
        (IServiceManagerBasicGeneric
            <LateMissStatus, LateMissStatusDto, LateMissStatusForCreationDto, LateMissStatusForUpdateDto> serviceManagerBasicGeneric) 
        : base(serviceManagerBasicGeneric)
    {
    }
}