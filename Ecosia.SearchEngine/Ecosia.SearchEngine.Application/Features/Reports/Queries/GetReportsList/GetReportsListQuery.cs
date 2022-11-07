using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportsListQuery(int Page, int Size) : IRequest<PagedReportsListVm>;