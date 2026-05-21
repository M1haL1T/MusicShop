namespace MusicShop.Models;

public class BasketEntry
{
    public int Id { get; set; }
    public int Qty { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    public int BuyerId { get; set; }
    public Buyer Buyer { get; set; } = null!;

    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; } = null!;
}
