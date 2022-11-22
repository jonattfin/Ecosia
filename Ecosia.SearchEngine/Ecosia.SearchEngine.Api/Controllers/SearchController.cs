using Ecosia.SearchEngine.Application.Features.Search.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/search")]
public class SearchController : ApplicationControllerWithMediator
{
    public SearchController(IMediator mediator, IDistributedCache cache) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedSearchesListVm>> Get(string text, int page = 1, int size = 5)
    {
        var query = new GetSearchesListQuery(text, page, size);
        var searches = await Mediator.Send(query);

        return Ok(searches);
    }
}