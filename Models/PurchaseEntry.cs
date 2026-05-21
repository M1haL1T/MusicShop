namespace MusicShop.Models;

public class PurchaseEntry
{
    public int Id { get; set; }
    public int Qty { get; set; }
    public decimal PriceAtSale { get; set; }

    public int PurchaseId { get; set; }
    public Purchase Purchase { get; set; } = null!;

    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; } = null!;

    public decimal LineTotal => Qty * PriceAtSale;
}
