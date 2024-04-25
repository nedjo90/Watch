using System.Reflection.Metadata;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Document = Entities.Models.Document;

namespace Repository;

public class RepositoryContext : DbContext
{
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentStatus> DocumentStatus { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<LateMiss> LateMisses { get; set; }
    public DbSet<LateMissDocument> LateMissDocuments { get; set; }
    public DbSet<LateMissStatus> LateMissStatus { get; set; }
    public DbSet<LateMissType> LateMissTypes { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<ProfessionalStatus> ProfessionalStatus { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<TrainingType> TrainingTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LateMissXLateMissStatus> LateMissXLateMissStatus { get; set; }
    // public DbSet<DocumentXDocumentStatus> DocumentXDocumentStatus { get; set; }
    // public DbSet<DocumentTypeXTrainingType> DocumentTypeXTrainingType { get; set; }
    // public DbSet<UserXNotification> UserXNotification { get; set; }
    // public DbSet<UserXRole> UserXRole { get; set; }
    // public DbSet<UserXTraining> UserXTrainings { get; set; }
    
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
    }
}