using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Models;

namespace MusicShop.Data.Configurations;

public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.FullName).IsRequired().HasMaxLength(150);
        builder.Property(b => b.Email).IsRequired().HasMaxLength(200);
        builder.Property(b => b.Phone).HasMaxLength(30);
        builder.Property(b => b.DeliveryAddress).HasMaxLength(500);

        builder.HasIndex(b => b.Email).IsUnique();

        builder.HasMany(b => b.Purchases)
               .WithOne(p => p.Buyer)
               .HasForeignKey(p => p.BuyerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.BasketEntries)
               .WithOne(be => be.Buyer)
               .HasForeignKey(be => be.BuyerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
