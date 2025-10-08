using Microsoft.EntityFrameworkCore;
using MovieRentalApi.Models;
namespace MovieRentalApi.Data
{
    public class MovieRentalDbContext : DbContext
    {
        public MovieRentalDbContext(DbContextOptions<MovieRentalDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
