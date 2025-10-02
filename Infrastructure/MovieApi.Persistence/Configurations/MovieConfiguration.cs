using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.CreatedAt).IsRequired(true);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(250);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(false);

        builder.Property(x => x.Title).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.DirectorId).IsRequired(true);
        builder.Property(x => x.ReleaseYear).IsRequired(true);
        builder.Property(x => x.GenreId).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);
        builder.Property(x => x.Price).IsRequired(true).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Duration).IsRequired(true);

        builder.HasMany(x => x.Actors)
            .WithMany(x => x.ActedMovies).UsingEntity(j => j.ToTable("MovieActors"));

        builder.HasOne(x => x.Director)
            .WithMany(x => x.DirectedMovies)
            .HasForeignKey(x => x.DirectorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Genre)
            .WithMany(x => x.MoviesInGenre)
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.PurchasedMovies)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Movies");
    }
}
