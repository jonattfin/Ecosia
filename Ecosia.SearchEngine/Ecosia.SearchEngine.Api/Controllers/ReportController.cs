using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController :  ControllerBase
{
    private readonly IMediator _mediator;

    public ReportController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReportListVm>>> Get()
    {
        var query = new GetReportsListQuery();
        var reports = await _mediator.Send(query);
        
        return Ok(reports);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ReportListVm>>> GetById(Guid id)
    {
        var query = new GetReportDetailQuery(id);
        var report = await _mediator.Send(query);
        
        return Ok(report);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(CreateReportCommand command)
    {
        var id = await _mediator.Send(command);
        
        return Ok(id);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateReportCommand command)
    {
        await _mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteReportCommand(id);
        await _mediator.Send(command);
        
        return NoContent();
    }
}