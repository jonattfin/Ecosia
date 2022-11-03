using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public record DeleteProjectCommand(Guid Id) : IRequest;