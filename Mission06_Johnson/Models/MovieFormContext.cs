using Microsoft.EntityFrameworkCore;

namespace Mission06_Johnson.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)  // A Movie has one Category
                .WithMany()               // A Category can have many Movies
                .HasForeignKey(m => m.CategoryId) // Foreign Key
                .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletion of categories
        }

        // ✅ Ensure SQLite Uses Your Database and Enforces Foreign Keys
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=JoelHiltonMovieCollection.sqlite");
            }
        }
    }
}