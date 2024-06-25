using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class User : IdentityUser
{
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
    
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
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public Guid ProfessionalStatusId { get; set; }
    
    public ProfessionalStatus ProfessionalStatus { get; set; }
    
    public ICollection<Notification> Notifications { get; set; }
    
    public ICollection<Document> Documents { get; set; }

    public ICollection<LateMiss> LateMisses { get; set; }

    public ICollection<Training> Trainings { get; set; }

    //History
    
    //Modified in his user information
    public ICollection<UserHistory> UserHistories { get; set; }
    
    //What he modified in tables
    public ICollection<UserHistory> HistoryOfModification { get; set; }
    public ICollection<DocumentHistory> DocumentHistories { get; set; }
    public ICollection<DocumentStatusHistory> DocumentStatusHistories { get; set; }
    public ICollection<DocumentTypeHistory> DocumentTypeHistories { get; set; }
    public ICollection<LateMissHistory> LateMissHistories { get; set; }
    public ICollection<LateMissDocumentHistory> LateMissDocumentHistories { get; set; }
    public ICollection<LateMissStatusHistory> LateMissStatusHistories { get; set; }
    public ICollection<LateMissTypeHistory> LateMissTypeHistories { get; set; }
    public ICollection<NotificationHistory> NotificationHistories { get; set; }
    public ICollection<NotificationTypeHistory> NotificationTypeHistories { get; set; }
    public ICollection<ProfessionalStatusHistory> ProfessionalStatusHistories { get; set; }
    public ICollection<TrainingHistory> TrainingHistories { get; set; }
    public ICollection<TrainingTypeHistory> TrainingTypeHistories { get; set; }
}