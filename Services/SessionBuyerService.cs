using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Services;

public interface ISessionBuyerService
{
    Task<Buyer> ResolveSessionBuyerAsync();
}

public class SessionBuyerService : ISessionBuyerService
{
    private readonly ShopContext _ctx;

    private const string GuestEmail = "guest@musicshop.local";

    public SessionBuyerService(ShopContext context) => _ctx = context;

    public async Task<Buyer> ResolveSessionBuyerAsync()
    {
        var buyer = await _ctx.Buyers.FirstOrDefaultAsync(b => b.Email == GuestEmail);

        if (buyer == null)
        {
            buyer = new Buyer
            {
                FullName = "Гость",
                Email = GuestEmail,
                JoinedAt = DateTime.UtcNow
            };
            _ctx.Buyers.Add(buyer);
            await _ctx.SaveChangesAsync();
        }
        return buyer;
    }
}
