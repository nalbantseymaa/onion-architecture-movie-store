using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.CreatedAt).IsRequired(true);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(250);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(false);

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Role).IsRequired().HasMaxLength(50);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.OpenDate).IsRequired();
        builder.Property(x => x.LastLoginDate).IsRequired(false);

        builder.HasMany(x => x.PurchasedMovies)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.FavoriteGenres)
            .WithMany(g => g.UsersByGenre)
            .UsingEntity(j => j.ToTable("UserGenres"));

        builder.ToTable(t => t.HasCheckConstraint("CK_User_RoleCheck",
         "Role IN ('Admin', 'Customer')"));

        builder.HasIndex(x => x.UserName).IsUnique(true);
    }
}