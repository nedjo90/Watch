using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DocumentStatus;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentStatusController : BasicGenericController<DocumentStatus,DocumentStatusDto,DocumentStatusForCreationDto, DocumentStatusForUpdateDto>
{
    public DocumentStatusController
        (IServiceManagerBasicGeneric
            <DocumentStatus, DocumentStatusDto, DocumentStatusForCreationDto, DocumentStatusForUpdateDto> serviceManagerBasicGeneric) 
        : base(serviceManagerBasicGeneric)
    {
    }
}