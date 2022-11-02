using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
    {
        var projectToUpdate = await _projectRepository.GetByIdAsync(command.Id);
        _mapper.Map(command, projectToUpdate, typeof(UpdateProjectCommand), typeof(Project));

        await _projectRepository.UpdateAsync(projectToUpdate);

        return Unit.Value;
    }
}