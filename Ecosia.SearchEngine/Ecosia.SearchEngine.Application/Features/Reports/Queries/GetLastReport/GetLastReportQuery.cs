using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetLastReportQuery() : IRequest<ReportDetailVm>;