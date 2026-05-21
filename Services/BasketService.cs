using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Services;

public interface IBasketService
{
    Task<IEnumerable<BasketEntry>> GetBasketAsync(int buyerId);
    Task AddToBasketAsync(int buyerId, int instrumentId, int qty = 1);
    Task ChangeEntryAmountAsync(int entryId, int qty);
    Task RemoveFromBasketAsync(int entryId);
    Task EmptyBasketAsync(int buyerId);
    Task<decimal> ComputeTotalAsync(int buyerId);
}

public class BasketService : IBasketService
{
    private readonly ShopContext _ctx;

    public BasketService(ShopContext context) => _ctx = context;

    public async Task<IEnumerable<BasketEntry>> GetBasketAsync(int buyerId)
        => await _ctx.BasketEntries
            .Include(be => be.Instrument)
            .Where(be => be.BuyerId == buyerId)
            .ToListAsync();

    public async Task AddToBasketAsync(int buyerId, int instrumentId, int qty = 1)
    {
        var existing = await _ctx.BasketEntries
            .FirstOrDefaultAsync(be => be.BuyerId == buyerId && be.InstrumentId == instrumentId);

        if (existing != null)
        {
            existing.Qty += qty;
        }
        else
        {
            await _ctx.BasketEntries.AddAsync(new BasketEntry
            {
                BuyerId = buyerId,
                InstrumentId = instrumentId,
                Qty = qty
            });
        }
        await _ctx.SaveChangesAsync();
    }

    public async Task ChangeEntryAmountAsync(int entryId, int qty)
    {
        var entry = await _ctx.BasketEntries.FindAsync(entryId);
        if (entry is null) return;

        if (qty <= 0)
            _ctx.BasketEntries.Remove(entry);
        else
            entry.Qty = qty;

        await _ctx.SaveChangesAsync();
    }

    public async Task RemoveFromBasketAsync(int entryId)
    {
        var entry = await _ctx.BasketEntries.FindAsync(entryId);
        if (entry is null) return;
        _ctx.BasketEntries.Remove(entry);
        await _ctx.SaveChangesAsync();
    }

    public async Task EmptyBasketAsync(int buyerId)
    {
        var entries = _ctx.BasketEntries.Where(be => be.BuyerId == buyerId);
        _ctx.BasketEntries.RemoveRange(entries);
        await _ctx.SaveChangesAsync();
    }

    public async Task<decimal> ComputeTotalAsync(int buyerId)
        => await _ctx.BasketEntries
            .Where(be => be.BuyerId == buyerId)
            .SumAsync(be => be.Qty * be.Instrument.RetailPrice);
}
