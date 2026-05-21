namespace MusicShop.Models;

public enum PurchaseStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public class Purchase
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    public PurchaseStatus Status { get; set; } = PurchaseStatus.Pending;
    public decimal GrandTotal { get; set; }
    public string? ShipTo { get; set; }

    public int BuyerId { get; set; }
    public Buyer Buyer { get; set; } = null!;

    public ICollection<PurchaseEntry> Entries { get; set; } = new List<PurchaseEntry>();
}
