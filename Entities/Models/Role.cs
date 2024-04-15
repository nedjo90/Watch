using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Role
{
    [Column("RoleId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Role Label is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Role Label is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Role Label is 2 characters")]
    public string? Label { get; set; }
    
    //navigation
    public ICollection<UserXRole?>? UserXRoleCollection { get; set; }

}