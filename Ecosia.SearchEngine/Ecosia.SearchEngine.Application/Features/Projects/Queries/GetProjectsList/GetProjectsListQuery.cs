using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Queries;

public record GetProjectsListQuery(int Page, int Size) : IRequest<PagedProjectsListVm>;