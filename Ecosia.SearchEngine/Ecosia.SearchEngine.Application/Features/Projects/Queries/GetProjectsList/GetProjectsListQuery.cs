using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public record GetProjectsListQuery(int Page, int Size) : IRequest<PagedProjectsListVm>
{
    public override string ToString()
    {
        return $"Projects_{Page}_{Size}";
    }
}
