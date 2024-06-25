using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransfertObject.Authentication;

public class UserForRegistrationDto
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string ProfilPicture { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }
    [Required(ErrorMessage = "Post Code is required")]
    public string Postcode { get; set; }
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; }
    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }
    [Required(ErrorMessage = "Birthday is required")]
    public string Birthday { get; set; }
    [Required(ErrorMessage = "Native City is required")]
    public string NativeCity { get; set; }
    [Required(ErrorMessage = "Native Country is required")]
    public string NativeCountry { get; set; }
    [Required]
    public Guid ProfessionalStatusId { get; set; }
    [Required(ErrorMessage = "Roles is required")]
    public ICollection<string>? Roles { get; init; }
}