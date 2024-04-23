using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class TrainingType : BasicGenericEntity
{
    public ICollection<DocumentTypeXTrainingType?>? DocumentTypeXTrainingTypeCollection { get; set; }
}