using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Models;

namespace MusicShop.Data.Configurations;

public class InstrumentSpecsConfiguration : IEntityTypeConfiguration<InstrumentSpecs>
{
    public void Configure(EntityTypeBuilder<InstrumentSpecs> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Brand).HasMaxLength(150);
        builder.Property(s => s.Origin).HasMaxLength(100);
        builder.Property(s => s.SizeInfo).HasMaxLength(100);

        builder.HasIndex(s => s.InstrumentId).IsUnique();
    }
}
