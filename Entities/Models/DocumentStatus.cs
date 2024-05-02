using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.BasicGeneric;

namespace Entities.Models;

public class DocumentStatus : BasicGenericEntity
{
    //navigation
    public ICollection<Document> Documents { get; set; }
    public ICollection<DocumentStatusHistory> DocumentStatusHistories { get; set; }
}