using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Search.Queries;

public record GetSearchesListQuery(string Text, int Page, int Size) : IRequest<PagedSearchesListVm>;