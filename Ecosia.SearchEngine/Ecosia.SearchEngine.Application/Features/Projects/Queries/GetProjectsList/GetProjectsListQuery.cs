using Ecosia.SearchEngine.Application.Contracts;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public record GetProjectsListQuery(int Page, int Size) : IQueryWithCacheKey<PagedProjectsListVm>
{
    public string CacheKey => $"Projects_{Page}_Size";
}

