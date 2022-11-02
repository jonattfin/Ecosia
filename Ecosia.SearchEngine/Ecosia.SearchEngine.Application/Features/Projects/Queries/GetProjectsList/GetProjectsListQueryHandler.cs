using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries.GetProjectsList;

public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, List<ProjectListVm>>
{
    private readonly IAsyncRepository<Project> _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectsListQueryHandler(IAsyncRepository<Project> projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectListVm>> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
    {
        var projects = (await _projectRepository.ListAllAsync()).OrderBy(p => p.Name);
        return _mapper.Map<List<ProjectListVm>>(projects);
    }
}