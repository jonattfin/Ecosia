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
        var (projects, count) = (await _projectRepository.ListAllAsync(query.Page, query.Size));

        return new PagedProjectsListVm()
        {
            Items = _mapper.Map<List<ProjectListVm>>(projects),
            Page = query.Page,
            Size = query.Size,
            Count = count
        };
    }
}