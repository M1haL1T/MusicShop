using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Models;

namespace MusicShop.Data.Configurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.GrandTotal).HasColumnType("decimal(18,2)");
        builder.Property(p => p.ShipTo).HasMaxLength(500);

        builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(30);

        builder.HasMany(p => p.Entries)
               .WithOne(e => e.Purchase)
               .HasForeignKey(e => e.PurchaseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class PurchaseEntryConfiguration : IEntityTypeConfiguration<PurchaseEntry>
{
    public void Configure(EntityTypeBuilder<PurchaseEntry> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.PriceAtSale).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Instrument)
               .WithMany(i => i.PurchaseEntries)
               .HasForeignKey(e => e.InstrumentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(e => e.LineTotal);
    }
}

public class BasketEntryConfiguration : IEntityTypeConfiguration<BasketEntry>
{
    public void Configure(EntityTypeBuilder<BasketEntry> builder)
    {
        builder.HasKey(be => be.Id);

        builder.HasOne(be => be.Instrument)
               .WithMany(i => i.BasketEntries)
               .HasForeignKey(be => be.InstrumentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
