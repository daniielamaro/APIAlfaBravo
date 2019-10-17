using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infrastructure.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Aqui configuramos a validates no DB
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(1200);
        }
    }
}
