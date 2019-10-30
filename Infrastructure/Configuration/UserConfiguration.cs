using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;


namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Aqui configuramos a validates no DB
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
