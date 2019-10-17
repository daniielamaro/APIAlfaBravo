using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infrastructure.Configuration
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            // Aqui configuramos a validates no DB
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(1200);

            builder
                .Property(p => p.DateCreated)
                .IsRequired();

            builder.HasMany(p => p.Comments);

        }
    }
}
