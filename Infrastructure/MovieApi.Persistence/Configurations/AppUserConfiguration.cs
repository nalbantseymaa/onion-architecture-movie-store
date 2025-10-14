using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.OpenDate).IsRequired();
        builder.Property(x => x.LastLoginDate).IsRequired(false);

        builder.HasMany(x => x.PurchasedMovies)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.FavoriteGenres)
            .WithMany(g => g.UsersInGenre)
            .UsingEntity(j => j.ToTable("UserGenres"));
    }
}