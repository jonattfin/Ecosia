using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var projectToUpdate = await _projectRepository.GetByIdAsync(request.Id);
        _mapper.Map(request, projectToUpdate, typeof(UpdateProjectCommand), typeof(Project));

        await _projectRepository.UpdateAsync(projectToUpdate);

        return Unit.Value;
    }
}