using MusicShop.Models;
using MusicShop.Repositories;

namespace MusicShop.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> ListAllAsync();
    Task<Genre?> GetByIdAsync(int id);
    Task AddAsync(Genre genre);
    Task SaveAsync(Genre genre);
    Task RemoveAsync(int id);
}

public class GenreService : IGenreService
{
    private readonly IDataStore<Genre> _genreStore;

    public GenreService(IDataStore<Genre> store) => _genreStore = store;

    public Task<IEnumerable<Genre>> ListAllAsync() => _genreStore.ListAllAsync();
    public Task<Genre?> GetByIdAsync(int id) => _genreStore.FindByIdAsync(id);

    public async Task AddAsync(Genre genre)
    {
        await _genreStore.InsertAsync(genre);
        await _genreStore.CommitAsync();
    }

    public async Task SaveAsync(Genre genre)
    {
        _genreStore.Modify(genre);
        await _genreStore.CommitAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var genre = await _genreStore.FindByIdAsync(id);
        if (genre is null) return;
        _genreStore.Erase(genre);
        await _genreStore.CommitAsync();
    }
}
