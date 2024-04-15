using System.Reflection.Emit;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.HasData(
            new DocumentType
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Label = "Carte d'identité"
            },
            new DocumentType
            {
                Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Label = "Carte vitale"
            },
            new DocumentType
            {
                Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                Label = "Carte bleu"
            }
        );
    }
}