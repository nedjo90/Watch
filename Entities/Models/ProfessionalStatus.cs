using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ProfessionalStatus : BasicGenericEntity
{
    public ICollection<User> Users { get; set; }
    public ICollection<ProfessionalStatusHistory> ProfessionalStatusHistories { get; set; }
}