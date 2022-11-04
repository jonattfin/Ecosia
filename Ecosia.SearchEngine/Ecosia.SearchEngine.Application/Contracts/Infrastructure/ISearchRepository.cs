using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Contracts.Infrastructure;

public interface ISearchRepository
{
    Task<IEnumerable<Search>> ListAllAsync(string text);
}