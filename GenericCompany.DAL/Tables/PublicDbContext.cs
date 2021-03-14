using GenericCompany.DAL.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.DAL.Tables
{
    public class PublicDbContext : DbContext
    {
        private readonly string _connectionString;
        public PublicDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevelopmentConnectionString");
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .Property(p => p.DateCreated)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<UserEntity>()
                .Property(p => p.DateUpdated)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<UserEntity>()
                .HasIndex(p => new { p.UserName, p.Email })
                .IsUnique();
        }
    }
}
