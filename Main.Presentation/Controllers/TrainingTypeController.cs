using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.TrainingType;

namespace Main.Presentation.Controllers;

[Route("api/trainingtype")]
[ApiController]
public class TrainingTypeController : BasicGenericController<TrainingType, TrainingTypeDto, TrainingTypeForCreationDto, TrainingTypeForUpdateDto>
{
    public TrainingTypeController(IServiceManagerBasicGeneric<TrainingType, TrainingTypeDto, TrainingTypeForCreationDto, TrainingTypeForUpdateDto> serviceManagerBasicGeneric) 
        : base(serviceManagerBasicGeneric)
    {
    }
}