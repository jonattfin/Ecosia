using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public record GetProjectDetailQuery(Guid Id) : IRequest<ProjectDetailVm>
{
    public override string ToString()
    {
        return $"Project_{Id}";
    }
}

