using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Search.Queries;

public class GetSearchesListQueryHandler : IRequestHandler<GetSearchesListQuery, PagedSearchesListVm>
{
    private readonly ISearchRepository _searchRepository;
    private readonly IMapper _mapper;

    public GetSearchesListQueryHandler(ISearchRepository searchRepository, IMapper mapper)
    {
        _searchRepository = searchRepository;
        _mapper = mapper;
    }

    public async Task<PagedSearchesListVm> Handle(GetSearchesListQuery query, CancellationToken cancellationToken)
    {
        var searches = await _searchRepository.ListAllAsync(query.Text);

        return new PagedSearchesListVm()
        {
            Page = query.Page,
            Size = query.Size,
            Items = _mapper.Map<List<SearchesListVm>>(searches),
            Count = 10
        };
    }
}
