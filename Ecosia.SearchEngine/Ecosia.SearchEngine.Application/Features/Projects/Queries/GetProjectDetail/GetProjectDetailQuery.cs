using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries.GetProjectDetail;

public class GetProjectDetailQuery : IRequest<ProjectDetailVm>
{
    public Guid Id { get; set; }
}

