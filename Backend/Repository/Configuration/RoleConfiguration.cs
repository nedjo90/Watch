using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
new Role
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Name = "Moderator",
                NormalizedName = "MODERATOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Name = "Professor",
                NormalizedName = "PROFESSOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Name = "Candidate",
                NormalizedName = "CANDIDATE",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        );
    }
    
}