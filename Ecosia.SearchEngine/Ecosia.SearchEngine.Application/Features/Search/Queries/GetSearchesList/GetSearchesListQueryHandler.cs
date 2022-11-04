using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Search.Queries;

public class GetSearchesListQueryHandler : IRequestHandler<GetSearchesListQuery, List<SearchesListVm>>
{
    private readonly ISearchRepository _searchRepository;
    private readonly IMapper _mapper;

    public GetSearchesListQueryHandler(ISearchRepository searchRepository, IMapper mapper)
    {
        _searchRepository = searchRepository;
        _mapper = mapper;
    }

    public async Task<List<SearchesListVm>> Handle(GetSearchesListQuery query, CancellationToken cancellationToken)
    {
        var searches = await _searchRepository.ListAllAsync(query.Text);
        return _mapper.Map<List<SearchesListVm>>(searches);
    }
}
