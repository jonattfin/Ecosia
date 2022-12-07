using Ecosia.SearchEngine.Application.Contracts;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportsListQuery(int Page, int Size) : IQueryWithCacheKey<PagedReportsListVm>
{
   public string CacheKey => $"Reports_{Page}_{Size}";
}