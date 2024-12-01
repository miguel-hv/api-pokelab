using api_pokelab.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace api_pokelab.Data
{
    public class PokeDbContext: DbContext
    {
        public PokeDbContext(DbContextOptions<PokeDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var passwordHash = BCrypt.Net.BCrypt.HashPassword("pass123");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "testuser@example.com",
                    Username = "testuser",
                    PasswordHash = passwordHash
                }
            );
        }
    }
}
