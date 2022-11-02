using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public Guid Id { get; set; }
}