using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Repositories;

public interface IPurchaseRepository : IDataStore<Purchase>
{
    Task<IEnumerable<Purchase>> FetchAllWithEntriesAsync();
    Task<Purchase?> FetchByIdWithEntriesAsync(int id);
    Task<IEnumerable<Purchase>> FetchByBuyerAsync(int buyerId);
}

public class PurchaseRepository : DataStore<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(ShopContext context) : base(context) { }

    public async Task<IEnumerable<Purchase>> FetchAllWithEntriesAsync()
        => await _ctx.Purchases
            .Include(p => p.Buyer)
            .Include(p => p.Entries).ThenInclude(e => e.Instrument)
            .OrderByDescending(p => p.PlacedAt)
            .ToListAsync();

    public async Task<Purchase?> FetchByIdWithEntriesAsync(int id)
        => await _ctx.Purchases
            .Include(p => p.Buyer)
            .Include(p => p.Entries).ThenInclude(e => e.Instrument)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Purchase>> FetchByBuyerAsync(int buyerId)
        => await _ctx.Purchases
            .Include(p => p.Entries).ThenInclude(e => e.Instrument)
            .Where(p => p.BuyerId == buyerId)
            .OrderByDescending(p => p.PlacedAt)
            .ToListAsync();
}
