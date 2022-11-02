using Ecosia.SearchEngine.Application.Features.Projects.Commands;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProjectListVm>>> Get()
    {
        var query = new GetProjectsListQuery();
        var projects = await _mediator.Send(query);
        
        return Ok(projects);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ProjectListVm>>> GetById(Guid id)
    {
        var query = new GetProjectDetailQuery(){Id = id};
        var project = await _mediator.Send(query);
        
        return Ok(project);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(CreateProjectCommand request)
    {
        var id = await _mediator.Send(request);
        
        return Ok(id);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateProjectCommand request)
    {
        await _mediator.Send(request);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProjectCommand();
        await _mediator.Send(command);
        
        return NoContent();
    }
}