using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
    {
        var projectToUpdate = await _unitOfWork.ProjectRepository.GetByIdAsync(command.Id);
        _mapper.Map(command, projectToUpdate, typeof(UpdateProjectCommand), typeof(Project));

        await _unitOfWork.ProjectRepository.UpdateAsync(projectToUpdate);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}