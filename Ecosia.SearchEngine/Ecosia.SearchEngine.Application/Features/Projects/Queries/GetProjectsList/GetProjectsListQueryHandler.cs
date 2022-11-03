using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, List<ProjectListVm>>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectsListQueryHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectListVm>> Handle(GetProjectsListQuery query, CancellationToken cancellationToken)
    {
        var projects = (await _projectRepository.ListAllAsync()).OrderBy(p => p.Name);
        return _mapper.Map<List<ProjectListVm>>(projects);
    }
}