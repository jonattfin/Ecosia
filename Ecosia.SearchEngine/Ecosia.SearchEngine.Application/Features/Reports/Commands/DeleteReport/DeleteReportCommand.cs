using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public record DeleteReportCommand(Guid Id) : IRequest;
