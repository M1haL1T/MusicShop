using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;
using MusicShop.Repositories;

namespace MusicShop.Services;

public interface IPurchaseService
{
    Task<IEnumerable<Purchase>> ListAllAsync();
    Task<Purchase?> GetByIdAsync(int id);
    Task<IEnumerable<Purchase>> ListByBuyerAsync(int buyerId);
    Task<Purchase> PlaceFromBasketAsync(int buyerId, string shipTo);
    Task ChangeStatusAsync(int purchaseId, PurchaseStatus status);
}

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchasesRepo;
    private readonly IBasketService _basketService;
    private readonly ShopContext _ctx;

    public PurchaseService(IPurchaseRepository repo, IBasketService basket, ShopContext context)
    {
        _purchasesRepo = repo;
        _basketService = basket;
        _ctx = context;
    }

    public Task<IEnumerable<Purchase>> ListAllAsync() => _purchasesRepo.FetchAllWithEntriesAsync();
    public Task<Purchase?> GetByIdAsync(int id) => _purchasesRepo.FetchByIdWithEntriesAsync(id);
    public Task<IEnumerable<Purchase>> ListByBuyerAsync(int buyerId) => _purchasesRepo.FetchByBuyerAsync(buyerId);

    public async Task<Purchase> PlaceFromBasketAsync(int buyerId, string shipTo)
    {
        var basketEntries = (await _basketService.GetBasketAsync(buyerId)).ToList();
        if (!basketEntries.Any())
            throw new InvalidOperationException("Корзина пуста");

        var purchase = new Purchase
        {
            BuyerId = buyerId,
            ShipTo = shipTo,
            Status = PurchaseStatus.Pending,
            PlacedAt = DateTime.UtcNow,
            Entries = basketEntries.Select(be => new PurchaseEntry
            {
                InstrumentId = be.InstrumentId,
                Qty = be.Qty,
                PriceAtSale = be.Instrument.RetailPrice
            }).ToList()
        };

        purchase.GrandTotal = purchase.Entries.Sum(e => e.Qty * e.PriceAtSale);

        foreach (var be in basketEntries)
        {
            var instrument = await _ctx.Instruments.FindAsync(be.InstrumentId);
            if (instrument != null)
            {
                if (instrument.StockCount < be.Qty)
                    throw new InvalidOperationException($"Недостаточно товара '{instrument.Title}' на складе");
                instrument.StockCount -= be.Qty;
            }
        }

        await _purchasesRepo.InsertAsync(purchase);
        await _purchasesRepo.CommitAsync();

        await _basketService.EmptyBasketAsync(buyerId);
        return purchase;
    }

    public async Task ChangeStatusAsync(int purchaseId, PurchaseStatus status)
    {
        var purchase = await _ctx.Purchases.FindAsync(purchaseId);
        if (purchase is null) return;
        purchase.Status = status;
        await _ctx.SaveChangesAsync();
    }
}
