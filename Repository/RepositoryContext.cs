using System.Runtime.InteropServices.ComTypes;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Document = Entities.Models.Document;

namespace Repository;

public class RepositoryContext : IdentityDbContext<User>
{
    public DbSet<Document>? Documents { get; set; }
    public DbSet<DocumentStatus>? DocumentStatus { get; set; }
    public DbSet<DocumentType>? DocumentTypes { get; set; }
    public DbSet<LateMiss>? LateMisses { get; set; }
    public DbSet<LateMissDocument>? LateMissDocuments { get; set; }
    public DbSet<LateMissStatus>? LateMissStatus { get; set; }
    public DbSet<LateMissType>? LateMissTypes { get; set; }
    public DbSet<Notification>? Notifications { get; set; }
    public DbSet<NotificationType>? NotificationTypes { get; set; }
    public DbSet<ProfessionalStatus>? ProfessionalStatus { get; set; }
    public DbSet<Training>? Trainings { get; set; }
    public DbSet<TrainingType>? TrainingTypes { get; set; }
    public DbSet<DocumentHistory>? DocumentHistories { get; set; }
    public DbSet<DocumentStatusHistory>? DocumentStatusHistories { get; set; }
    public DbSet<DocumentTypeHistory>? DocumentTypeHistories { get; set; }
    public DbSet<LateMissHistory>? LateMissHistories { get; set; }
    public DbSet<LateMissDocumentHistory>? LateMissDocumentHistories { get; set; }
    public DbSet<LateMissTypeHistory>? LateMissTypeHistories { get; set; }
    public DbSet<LateMissStatusHistory>? LateMissStatusHistories { get; set; }
    public DbSet<NotificationHistory>? NotificationHistories { get; set; }
    public DbSet<NotificationTypeHistory>? NotificationTypeHistories { get; set; }
    public DbSet<ProfessionalStatusHistory>? ProfessionalStatusHistories { get; set; }
    public DbSet<TrainingHistory>? TrainingHistories { get; set; }
    public DbSet<TrainingTypeHistory>? TrainingTypeHistories { get; set; }
    
    public RepositoryContext(DbContextOptions options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.UserHistories)
            .WithOne(h => h.User)
            .HasForeignKey(h => h.UserId);
        modelBuilder.Entity<User>()
            .HasMany(u => u.HistoryOfModification)
            .WithOne(h => h.ModifierUser)
            .HasForeignKey(h => h.ModifierUserId);
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}