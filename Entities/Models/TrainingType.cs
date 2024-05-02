using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class TrainingType : BasicGenericEntity
{
    public ICollection<DocumentType> DocumentTypes { get; set; }
    public ICollection<TrainingTypeHistory> TrainingTypeHistories { get; set; }
}