using System.ComponentModel.DataAnnotations;
using Shared.AttributeFilter;

namespace Shared.DataTransfertObject.Authentication;

public record UserForRegistrationDto
{
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "First name must be less than 50 characters")]
    public string? FirstName { get; init; }

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Last name must be less than 50 characters")]
    public string? LastName { get; init; }

    [Required(ErrorMessage = "Username is required")]
    [MinLength(2, ErrorMessage = "Username must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Username must be less than 50 characters")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; }

    [Required(ErrorMessage = "Password is required")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [Compare(nameof(Email), ErrorMessage = "The email and confirmation Email do not match.")]
    public string? ConfirmEmail { get; init; }
    
    public string? PhoneNumber { get; init; } = "+33000000000";

    public string ProfilPicture { get; init; } = "none.png";

    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; init; }

    [Required(ErrorMessage = "Post Code is required")]
    public string? Postcode { get; init; }

    [Required(ErrorMessage = "City is required")]
    public string? City { get; init; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; init; } = "France";

    [Required(ErrorMessage = "Birthday is required")]
    [DateValidation(ErrorMessage = "Please enter a valid date")]
    public string? Birthday { get; init; }

    [Required(ErrorMessage = "Native City is required")]
    public string NativeCity { get; init; } = "undefined";

    [Required(ErrorMessage = "Native Country is required")]
    public string NativeCountry { get; init; } = "undefined";

    [Required] public Guid ProfessionalStatusId { get; init; }

    [Required(ErrorMessage = "Roles is required")]
    public ICollection<string>? Roles { get; init; } = new List<string> { "Candidateprofile" };
}