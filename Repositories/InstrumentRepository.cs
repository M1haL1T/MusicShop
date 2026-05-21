using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Repositories;

public interface IInstrumentRepository : IDataStore<Instrument>
{
    Task<IEnumerable<Instrument>> FetchAllWithGenreAsync();
    Task<Instrument?> FetchByIdWithSpecsAsync(int id);
    Task<IEnumerable<Instrument>> FetchByGenreAsync(int genreId);
}

public class InstrumentRepository : DataStore<Instrument>, IInstrumentRepository
{
    public InstrumentRepository(ShopContext context) : base(context) { }

    public async Task<IEnumerable<Instrument>> FetchAllWithGenreAsync()
        => await _ctx.Instruments.Include(i => i.Genre).AsNoTracking().ToListAsync();

    public async Task<Instrument?> FetchByIdWithSpecsAsync(int id)
        => await _ctx.Instruments
            .Include(i => i.Genre)
            .Include(i => i.Specs)
            .FirstOrDefaultAsync(i => i.Id == id);

    public async Task<IEnumerable<Instrument>> FetchByGenreAsync(int genreId)
        => await _ctx.Instruments
            .Include(i => i.Genre)
            .Where(i => i.GenreId == genreId)
            .AsNoTracking()
            .ToListAsync();
}
