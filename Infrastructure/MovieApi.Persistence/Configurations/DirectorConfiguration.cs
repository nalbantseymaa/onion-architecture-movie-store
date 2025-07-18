using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieApi.Persistence.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CreatedAt).IsRequired(true);
        builder.Property(x => x.CreatedBy).IsRequired(false);
        builder.Property(x => x.UpdatedAt).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(250);
        builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(true);

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.MiddleName).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.DirectedMovies)
            .WithOne(x => x.Director)
            .HasForeignKey(x => x.DirectorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Directors");

    }
}
