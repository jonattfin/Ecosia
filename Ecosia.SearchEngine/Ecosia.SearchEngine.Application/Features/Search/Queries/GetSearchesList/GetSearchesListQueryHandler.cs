using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Search.Queries;

public class GetSearchesListQueryHandler : IRequestHandler<GetSearchesListQuery, PagedSearchesListVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSearchesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedSearchesListVm> Handle(GetSearchesListQuery query, CancellationToken cancellationToken)
    {
        var searches = await _unitOfWork.SearchRepository.ListAllAsync(query.Text, query.Page, query.Size);
        var count = await _unitOfWork.SearchRepository.CountAsync();
        
        return new PagedSearchesListVm()
        {
            Page = query.Page,
            Size = query.Size,
            Items = _mapper.Map<List<SearchesListVm>>(searches),
            Count = count
        };
    }
}
