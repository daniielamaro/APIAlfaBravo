using Domain;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Context
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
        {
            //Para a produção
            optionsBuilder.UseNpgsql("Host=db-postgres;Database=WebApiBlog;Username=postgres;Password=password", npgsqlOptionsAction: options =>
            {
                options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                options.MigrationsHistoryTable("_MigrationHistory", "WebApiBlog");
            }); 

            //Para os testes
            //optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PublicationConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());

            modelBuilder.Entity<User>().HasData(
                new User(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Anonimo", "", "")
            ); 

            modelBuilder.Entity<Topic>().HasData(
                new Topic("Cultura"),
                new Topic("Economia"),
                new Topic("Educação"),                
                new Topic("Entretenimento"),
                new Topic("Esporte"),
                new Topic("Política"),
                new Topic("Saúde"),
                new Topic("Tecnologia"),
                new Topic("Tempo")
            ) ;

            base.OnModelCreating(modelBuilder);            
        }    
    }
}






