using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class DocumentType : BasicGenericEntity
{
    //navigation
    public ICollection<DocumentTypeXTrainingType?>? DocumentTypeXTrainingTypeCollection { get; set; }
}