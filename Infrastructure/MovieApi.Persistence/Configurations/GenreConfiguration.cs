using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.CreatedAt).IsRequired(true);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(250);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(false);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.MoviesInGenre)
        .WithOne(x => x.Genre)
        .HasForeignKey(x => x.GenreId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.UsersInGenre)
            .WithMany(g => g.FavoriteGenres)
            .UsingEntity(j => j.ToTable("UsersGenres"));

        builder.ToTable("Genres");
    }
}
