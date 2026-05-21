namespace MusicShop.Models;

public class InstrumentSpecs
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Origin { get; set; }
    public double? MassKg { get; set; }
    public string? SizeInfo { get; set; }
    public int GuaranteeMonths { get; set; }

    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; } = null!;
}
