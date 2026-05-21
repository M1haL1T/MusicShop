using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Models;

namespace MusicShop.Data.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Title).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Summary).HasMaxLength(500);

        builder.HasIndex(g => g.Title).IsUnique();

        builder.HasMany(g => g.Instruments)
               .WithOne(i => i.Genre)
               .HasForeignKey(i => i.GenreId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
