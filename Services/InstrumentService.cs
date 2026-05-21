using MusicShop.Models;
using MusicShop.Repositories;

namespace MusicShop.Services;

public interface IInstrumentService
{
    Task<IEnumerable<Instrument>> ListAllAsync();
    Task<Instrument?> GetByIdAsync(int id);
    Task<IEnumerable<Instrument>> ListByGenreAsync(int genreId);
    Task AddAsync(Instrument instrument);
    Task SaveAsync(Instrument instrument);
    Task RemoveAsync(int id);
}

public class InstrumentService : IInstrumentService
{
    private readonly IInstrumentRepository _instrumentsRepo;

    public InstrumentService(IInstrumentRepository repo) => _instrumentsRepo = repo;

    public Task<IEnumerable<Instrument>> ListAllAsync() => _instrumentsRepo.FetchAllWithGenreAsync();
    public Task<Instrument?> GetByIdAsync(int id) => _instrumentsRepo.FetchByIdWithSpecsAsync(id);
    public Task<IEnumerable<Instrument>> ListByGenreAsync(int genreId) => _instrumentsRepo.FetchByGenreAsync(genreId);

    public async Task AddAsync(Instrument instrument)
    {
        await _instrumentsRepo.InsertAsync(instrument);
        await _instrumentsRepo.CommitAsync();
    }

    public async Task SaveAsync(Instrument instrument)
    {
        _instrumentsRepo.Modify(instrument);
        await _instrumentsRepo.CommitAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var item = await _instrumentsRepo.FindByIdAsync(id);
        if (item is null) return;
        _instrumentsRepo.Erase(item);
        await _instrumentsRepo.CommitAsync();
    }
}
