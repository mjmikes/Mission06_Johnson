using Microsoft.EntityFrameworkCore;

namespace Mission06_Johnson.Models;

public class MovieFormContext : DbContext
{
    public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
    {
        
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed Data
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Mystery" },
            new Category { CategoryId = 2, CategoryName = "Horror" },
            new Category { CategoryId = 3, CategoryName = "Adventure" },
            new Category { CategoryId = 4, CategoryName = "Drama" },
            new Category { CategoryId = 5, CategoryName = "Comedy" });
    }
}