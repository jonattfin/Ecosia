using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public record GetReportsListQuery(int Page, int Size) : IRequest<PagedReportsListVm>
{
    public override string ToString()
    {
        return $"Reports_{Page}_{Size}";
    }
}