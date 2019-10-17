using Domain;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class ApiContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        public ApiContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Database=WebApiBlog;Username=postgres;Password=global2019");
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PublicationConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());

            modelBuilder.Entity<Topic>().HasData(
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cultura"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Economia"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Educação"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Entretenimento"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Esporte"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Política"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Saúde"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tecnologia"
                },
                new Topic()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tempo"
                }
            );

            base.OnModelCreating(modelBuilder);            
        }    
    }
}
