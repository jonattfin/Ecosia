using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, PagedProjectsListVm>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectsListQueryHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<PagedProjectsListVm> Handle(GetProjectsListQuery query, CancellationToken cancellationToken)
    {
        var projects = (await _projectRepository.ListAllAsync(query.Page, query.Size));
        var count = (await _projectRepository.CountAsync());

        return new PagedProjectsListVm()
        {
            Projects = _mapper.Map<List<ProjectListVm>>(projects),
            Page = query.Page,
            Size = query.Size,
            Count = count
        };
    }
}