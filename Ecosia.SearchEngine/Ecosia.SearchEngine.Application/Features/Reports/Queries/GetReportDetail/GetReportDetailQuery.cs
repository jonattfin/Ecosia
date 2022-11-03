using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportDetailQuery(Guid Id) : IRequest<ReportDetailVm>;