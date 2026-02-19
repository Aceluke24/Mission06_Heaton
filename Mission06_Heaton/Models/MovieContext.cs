using Microsoft.EntityFrameworkCore;

namespace Mission06_Heaton.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        // Table for movies
        public DbSet<Movie> Movies { get; set; }

        // Table for categories
        public DbSet<Category> Categories { get; set; }
    }
}
