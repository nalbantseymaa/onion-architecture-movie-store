using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Configurations;

public class PurchasedMovieConfiguration : IEntityTypeConfiguration<PurchasedMovie>
{
    public void Configure(EntityTypeBuilder<PurchasedMovie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .IsRequired()
        .ValueGeneratedOnAdd()
        .HasDefaultValueSql("NEWID()");

        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.MovieId).IsRequired(true);
        builder.Property(x => x.PurchaseDate).IsRequired(true);
        builder.Property(x => x.Price).IsRequired(true).HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.User)
            .WithMany(c => c.PurchasedMovies)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Movie)
            .WithMany(m => m.PurchasedMovies)
            .HasForeignKey(x => x.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("PurchasedMovies");
    }
}
