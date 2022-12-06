using Ecosia.SearchEngine.Application.Features.Projects.Commands;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/projects")]
public class ProjectsController : ControllerWithDistributedCache
{
    public ProjectsController(IMediator mediator, IDistributedCache distributedCache) : base(mediator, distributedCache)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedProjectsListVm>> Get(int page = 1, int size = 5)
    {
        var query = new GetProjectsListQuery(page, size);
        var projects = await GetDataAsync(query);
        
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDetailVm>> GetById(Guid id)
    {
        var query = new GetProjectDetailQuery(id);
        var project = await GetDataAsync(query);

        return Ok(project);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(CreateProjectCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(id);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateProjectCommand command)
    {
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProjectCommand(id);
        await Mediator.Send(command);

        return NoContent();
    }
}