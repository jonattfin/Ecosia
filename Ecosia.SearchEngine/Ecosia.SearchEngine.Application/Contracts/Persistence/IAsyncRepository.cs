namespace Ecosia.SearchEngine.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);

    Task<(IEnumerable<T>, int)> ListAllAsync(int Page, int Size);
    
    Task<IEnumerable<T>> ListAllAsync();

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}