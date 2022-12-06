using Ecosia.SearchEngine.Application.Contracts;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public record GetProjectDetailQuery(Guid Id) : IQueryWithCacheKey<ProjectDetailVm>
{
    public string CacheKey => Id.ToString();
}

