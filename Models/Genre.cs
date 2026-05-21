namespace MusicShop.Models;

public class Genre
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Summary { get; set; }

    public ICollection<Instrument> Instruments { get; set; } = new List<Instrument>();
}
