using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class DeleteProjectCommand : IRequest
{
    public Guid Id { get; set; }
}