using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportDetailQuery : IRequest<ReportDetailVm>
{
    public Guid Id { get; set; }
}