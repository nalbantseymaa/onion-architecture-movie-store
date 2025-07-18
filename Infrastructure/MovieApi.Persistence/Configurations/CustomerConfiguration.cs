using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieApi.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.MiddleName).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.PurchasedMovies)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.FavoriteGenres)
            .WithMany(g => g.CustomersByGenre)
            .UsingEntity(j => j.ToTable("CustomerGenres"));

        builder.ToTable("Customers");

    }
}
