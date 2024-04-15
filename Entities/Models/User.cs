using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class User
{
    [Column("UserId")]
    public Guid Id {get; set;}
    
    [Required(ErrorMessage = "First Name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the First Name is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the First Name is 2 characters")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Last Name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Last Name is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Last Name is 2 characters")]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "Email is a required field.")]
    [EmailAddress(ErrorMessage = "Invalid Email.")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Address is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Address is 2 characters")]
    public string? Address { get; set; }
    
    [Required(ErrorMessage = "Post Code is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Post Code is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Post Code is 2 characters")]
    public string? PostCode { get; set; }
    
    [Required(ErrorMessage = "City is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the City is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the City is 2 characters")]
    public string? City { get; set; }
    
    [Required(ErrorMessage = "Country is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Country is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Country is 2 characters")]
    public string? Country { get; set; }
    
    [Required(ErrorMessage = "Birth Date is a required field.")]
    public DateTime BirthDate { get; set; }
    
    [Required(ErrorMessage = "Native City is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Native City is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Native City is 2 characters")]
    public string? NativeCity { get; set; }
    
    [Required(ErrorMessage = "Native Country is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Native Country is 60 characters" )]
    [MinLength(2, ErrorMessage = "Minimum length for the Native Country is 2 characters")]
    public string? NativeCountry { get; set; }
    
    [Required(ErrorMessage = "Native City is a required field.")]
    [Phone]
    public string? PhoneNumber { get; set; }
    
    [ForeignKey(nameof(ProfessionalStatus))]
    [Required(ErrorMessage = "ProfessionalStatusId is a required field.")]
    public Guid ProfessionalStatusId { get; set; }
    public ProfessionalStatus? ProfessionalStatus { get; set; }
    
    //navigation
    public ICollection<UserXRole?>? UserXRoleCollection { get; set; }

    //navigation
    public ICollection<UserXNotification?>? UserXNotificationCollection { get; set; }
    
    //navigation
    public ICollection<UserXTraining?>? UserXTrainingCollection { get; set; }

}
    