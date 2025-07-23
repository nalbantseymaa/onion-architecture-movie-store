using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieApi.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
    base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<PurchasedMovie> PurchasedMovies { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}