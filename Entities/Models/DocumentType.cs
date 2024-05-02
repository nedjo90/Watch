using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class DocumentType : BasicGenericEntity
{
    //navigation
    public ICollection<TrainingType> TrainingTypes { get; set; }
    public ICollection<Document> Documents { get; set; }
    public ICollection<DocumentTypeHistory> DocumentTypeHistories { get; set; }
}