using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly EcosiaDbContext _context;

    protected BaseRepository(EcosiaDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<(IEnumerable<T>, int)> ListAllAsync(int page, int size)
    {
        var items = await _context.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        var count = await _context.Set<T>().AsNoTracking().CountAsync();

        return (items, count);
    }

    public async Task<IEnumerable<T>> ListAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}