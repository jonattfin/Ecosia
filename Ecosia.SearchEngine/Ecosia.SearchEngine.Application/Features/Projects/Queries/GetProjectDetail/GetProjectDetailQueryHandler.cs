using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, ProjectDetailVm>
{
    private readonly IAsyncRepository<Project> _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectDetailQueryHandler(IAsyncRepository<Project> projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ProjectDetailVm> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ProjectDetailVm>(project);
    }
}