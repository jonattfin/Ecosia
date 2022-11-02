using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public DeleteProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        var projectToDelete = await _projectRepository.GetByIdAsync(command.Id);

        await _projectRepository.DeleteAsync(projectToDelete);

        return Unit.Value;
    }
}