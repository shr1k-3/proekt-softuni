using Microsoft.EntityFrameworkCore;
using MovieCatalog.Models;

namespace MovieCatalog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Movie>().Property(m => m.Rating).HasPrecision(3, 1);

        b.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Drama" },
            new Genre { Id = 2, Name = "Sci-Fi" },
            new Genre { Id = 3, Name = "Comedy" });

        b.Entity<Director>().HasData(
            new Director { Id = 1, Name = "Christopher Nolan", Country = "UK" },
            new Director { Id = 2, Name = "Frank Darabont", Country = "USA" },
            new Director { Id = 3, Name = "Taika Waititi", Country = "New Zealand" });

        b.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", Year = 2010, Rating = 8.8m, Description = "Dream heist thriller.", GenreId = 2, DirectorId = 1 },
            new Movie { Id = 2, Title = "The Shawshank Redemption", Year = 1994, Rating = 9.3m, Description = "Hope inside prison walls.", GenreId = 1, DirectorId = 2 },
            new Movie { Id = 3, Title = "Jojo Rabbit", Year = 2019, Rating = 7.9m, Description = "Satire set in WWII.", GenreId = 3, DirectorId = 3 });
    }
}
