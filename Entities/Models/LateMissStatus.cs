using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissStatus : BasicGenericEntity
{
    public ICollection<LateMissXLateMissStatus?>? LateMissXLateMissStatusCollection { get; set; }
}