using Microsoft.EntityFrameworkCore;
using MovieRentalApi.Dtos;
using MovieRentalApi.Models;

namespace MovieRentalApi.Data
{
    public class MovieRentalDbContext(DbContextOptions<MovieRentalDbContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Genre)
                .HasConversion<int>();
            modelBuilder.Entity<Movie>()
                .Property(m => m.Genre)
                .HasDefaultValue(Genre.None);
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .HasMaxLength(256)
                .IsRequired();
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Rentals)
                .WithOne(r => r.Movie);

            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .HasMaxLength(128)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(128)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Rentals)
                .WithOne(r => r.Customer);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Rental>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.RentedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}