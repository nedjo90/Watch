using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DocumentType;

namespace Main.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTypeController : BasicGenericController<DocumentType,DocumentTypeDto,DocumentTypeForCreationDto, DocumentTypeForUpdateDto>
{
    public DocumentTypeController
        (IServiceManagerBasicGeneric
            <DocumentType, DocumentTypeDto, DocumentTypeForCreationDto, DocumentTypeForUpdateDto> serviceManagerBasicGeneric) 
        : base(serviceManagerBasicGeneric)
    {
    }
}