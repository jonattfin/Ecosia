using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        var projectToDelete = await _unitOfWork.ProjectRepository.GetByIdAsync(command.Id);

        await _unitOfWork.ProjectRepository.DeleteAsync(projectToDelete);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}