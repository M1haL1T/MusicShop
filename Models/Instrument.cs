namespace MusicShop.Models;

public class Instrument
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Overview { get; set; }
    public decimal RetailPrice { get; set; }
    public int StockCount { get; set; }
    public string? CoverUrl { get; set; }
    public DateTime ListedAt { get; set; } = DateTime.UtcNow;

    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;

    public InstrumentSpecs? Specs { get; set; }

    public ICollection<PurchaseEntry> PurchaseEntries { get; set; } = new List<PurchaseEntry>();
    public ICollection<BasketEntry> BasketEntries { get; set; } = new List<BasketEntry>();
}
