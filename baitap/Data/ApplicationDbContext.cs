using baitap.Models;
using Microsoft.EntityFrameworkCore;

namespace baitap.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>()
            .HasOne(movie => movie.Genre)
            .WithMany(genre => genre.Movies)
            .HasForeignKey(movie => movie.GenreId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Hành động" },
            new Genre { Id = 2, Name = "Hoạt hình" },
            new Genre { Id = 3, Name = "Kinh dị" },
            new Genre { Id = 4, Name = "Tình cảm" });

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "John Wick", ReleaseDate = new DateTime(2014, 1, 1), Duration = 101, GenreId = 1 },
            new Movie { Id = 2, Title = "Doraemon", ReleaseDate = new DateTime(2000, 1, 1), Duration = 90, GenreId = 2 },
            new Movie { Id = 3, Title = "The Conjuring", ReleaseDate = new DateTime(2013, 1, 1), Duration = 112, GenreId = 3 });
    }
}
