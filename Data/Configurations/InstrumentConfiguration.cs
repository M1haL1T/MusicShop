using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Models;

namespace MusicShop.Data.Configurations;

public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Title).IsRequired().HasMaxLength(200);
        builder.Property(i => i.Overview).HasMaxLength(2000);
        builder.Property(i => i.RetailPrice).HasColumnType("decimal(18,2)");
        builder.Property(i => i.CoverUrl).HasMaxLength(500);

        builder.HasOne(i => i.Specs)
               .WithOne(s => s.Instrument)
               .HasForeignKey<InstrumentSpecs>(s => s.InstrumentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
