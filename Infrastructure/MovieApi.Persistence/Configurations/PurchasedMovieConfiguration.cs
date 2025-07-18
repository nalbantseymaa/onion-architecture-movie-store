using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieApi.Persistence.Configurations;

public class PurchasedMovieConfiguration : IEntityTypeConfiguration<PurchasedMovie>
{
    public void Configure(EntityTypeBuilder<PurchasedMovie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.CustomerId).IsRequired(true);
        builder.Property(x => x.MovieId).IsRequired(true);
        builder.Property(x => x.PurchaseDate).IsRequired(true);
        builder.Property(x => x.Price).IsRequired(true).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Customer)
            .WithMany(c => c.PurchasedMovies)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Movie)
            .WithMany(m => m.PurchasedMovies)
            .HasForeignKey(x => x.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("PurchasedMovies");
    }
}
