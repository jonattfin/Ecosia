using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, ProjectDetailVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProjectDetailVm> Handle(GetProjectDetailQuery query, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectRepository.GetByIdAsync(query.Id);
        return _mapper.Map<ProjectDetailVm>(project);
    }
}