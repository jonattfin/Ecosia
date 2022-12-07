using Ecosia.SearchEngine.Application.Contracts;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public record GetProjectDetailQuery(Guid Id) : IQueryWithCacheKey<ProjectDetailVm>
{
    public string CacheKey => Id.ToString();
}

