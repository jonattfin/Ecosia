using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class GetProjectDetailQuery : IRequest<ProjectDetailVm>
{
    public Guid Id { get; set; }
}

