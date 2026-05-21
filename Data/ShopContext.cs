using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Instrument> Instruments => Set<Instrument>();
    public DbSet<InstrumentSpecs> InstrumentSpecs => Set<InstrumentSpecs>();
    public DbSet<Buyer> Buyers => Set<Buyer>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseEntry> PurchaseEntries => Set<PurchaseEntry>();
    public DbSet<BasketEntry> BasketEntries => Set<BasketEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);

        CatalogSeeder.Populate(modelBuilder);
    }
}
