using Ecosia.SearchEngine.Application.Contracts;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportDetailQuery(Guid Id) : IQueryWithCacheKey<ReportDetailVm>
{
    public string CacheKey { get; set; }
}