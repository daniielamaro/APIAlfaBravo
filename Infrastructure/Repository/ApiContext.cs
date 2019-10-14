using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class ApiContext : DbContext
    {
        //public DbSet<Publication> Publications { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Topic> Topics { get; set; }
        //public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Database=WebApiBlog;Username=postgres;Password=password");
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }
    }
}
