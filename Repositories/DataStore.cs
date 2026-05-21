using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicShop.Data;

namespace MusicShop.Repositories;

public class DataStore<T> : IDataStore<T> where T : class
{
    protected readonly ShopContext _ctx;
    protected readonly DbSet<T> _table;

    public DataStore(ShopContext context)
    {
        _ctx = context;
        _table = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> ListAllAsync() => await _table.ToListAsync();

    public virtual async Task<T?> FindByIdAsync(int id) => await _table.FindAsync(id);

    public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        => await _table.Where(predicate).ToListAsync();

    public async Task InsertAsync(T entity) => await _table.AddAsync(entity);
    public void Modify(T entity) => _table.Update(entity);
    public void Erase(T entity) => _table.Remove(entity);

    public async Task<int> CommitAsync() => await _ctx.SaveChangesAsync();
}
