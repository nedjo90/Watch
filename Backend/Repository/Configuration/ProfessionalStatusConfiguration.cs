using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ProfessionalStatusConfiguration : IEntityTypeConfiguration<ProfessionalStatus>
{
    public void Configure(EntityTypeBuilder<ProfessionalStatus> builder)
    {
        builder.HasData(
            new ProfessionalStatus { 
                Id = new Guid(Guid.NewGuid().ToString()),
                Label = "Employé" 
            },
            new ProfessionalStatus { 
                Id = new Guid(Guid.NewGuid().ToString()),
                Label = "Chômage" 
            },
            new ProfessionalStatus { 
                Id = new Guid(Guid.NewGuid().ToString()),
                Label = "Étudiant" 
            },
            new ProfessionalStatus { 
                Id = new Guid(Guid.NewGuid().ToString()),
                Label = "RSA"
            }
        );
    }
}