using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries.GetReportDetail;

public class GetReportDetailQuery : IRequest<ReportDetailVm>
{
    public Guid Id { get; set; }
}