using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportDetailQuery(Guid Id) : IRequest<ReportDetailVm>
{
    public override string ToString()
    {
        return $"Report_{Id}";
    }
}