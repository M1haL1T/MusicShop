namespace MusicShop.Models;

public class Buyer
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? DeliveryAddress { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public ICollection<BasketEntry> BasketEntries { get; set; } = new List<BasketEntry>();
}
