using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.BasicGeneric;

namespace Entities.Models;

public class DocumentStatus : BasicGenericEntity
{
    //navigation
    public ICollection<DocumentXDocumentStatus?>? DocumentXDocumentStatusCollection { get; set; }
}