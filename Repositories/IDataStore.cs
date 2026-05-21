using System.Linq.Expressions;

namespace MusicShop.Repositories;

public interface IDataStore<T> where T : class
{
    Task<IEnumerable<T>> ListAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate);
    Task InsertAsync(T entity);
    void Modify(T entity);
    void Erase(T entity);
    Task<int> CommitAsync();
}
