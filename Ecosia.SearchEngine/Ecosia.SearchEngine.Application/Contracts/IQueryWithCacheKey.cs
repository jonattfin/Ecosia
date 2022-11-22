using MediatR;

namespace Ecosia.SearchEngine.Application.Contracts;

public interface IQueryWithCacheKey<out T> : IRequest<T>
{
    public string CacheKey { get; }
}