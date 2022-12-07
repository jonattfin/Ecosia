using Ecosia.SearchEngine.Application.Contracts;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportDetailQuery(Guid Id) : IQueryWithCacheKey<ReportDetailVm>
{
    public string CacheKey => Id.ToString();
}