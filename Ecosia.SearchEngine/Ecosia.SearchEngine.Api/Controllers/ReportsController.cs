using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/reports")]
public class ReportsController :  ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedReportsListVm>> Get(int page = 1, int size = 5)
    {
        var query = new GetReportsListQuery(page, size);
        var reports = await _mediator.Send(query);
        
        return Ok(reports);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ReportDetailVm>> GetById(Guid id)
    {
        var query = new GetReportDetailQuery(id);
        var report = await _mediator.Send(query);
        
        return Ok(report);
    }
    
    [HttpGet("last")]
    public async Task<ActionResult<ReportDetailVm>> GetLast()
    {
        var query = new GetLastReportQuery();
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