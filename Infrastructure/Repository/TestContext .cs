using Domain;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class TestContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public TestContext(DbContextOptions options) : base(options)
        {
        }

        public TestContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PublicationConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());

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
