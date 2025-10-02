using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(250);
        builder.Property(x => x.CreatedAt).IsRequired(true);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(250);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.IsDeleted).IsRequired(true).HasDefaultValue(false);

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.MiddleName).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);

        builder
        .HasMany(a => a.ActedMovies)
        .WithMany(m => m.Actors)
        .UsingEntity(j => j.ToTable("ActorMovies"));

        builder.ToTable("Actors");
    }
}