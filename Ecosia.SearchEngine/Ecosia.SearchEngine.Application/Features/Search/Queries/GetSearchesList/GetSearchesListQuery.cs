using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Search.Queries;

public class GetSearchesListQuery : IRequest<List<SearchesListVm>>
{
    public string Text { get; set; }
}