using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/reports")]
public class ReportsController : ControllerWithDistributedCache
{
    public ReportsController(IMediator mediator, IDistributedCache distributedCache) : base(mediator, distributedCache)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedReportsListVm>> Get(int page = 1, int size = 5)
    {
        var query = new GetReportsListQuery(page, size);
        var reports = await GetDataAsync(query);

        return Ok(reports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReportDetailVm>> GetById(Guid id)
    {
        var query = new GetReportDetailQuery(id);
        var report = await GetDataAsync(query);

        return Ok(report);
    }

    [HttpGet("last")]
    public async Task<ActionResult<ReportDetailVm>> GetLast()
    {
        var query = new GetLastReportQuery();
        var report = await Mediator.Send(query);

        return Ok(report);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(CreateReportCommand command)
    {
        var id = await Mediator.Send(command);

        return Ok(id);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateReportCommand command)
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
        var command = new DeleteReportCommand(id);
        await Mediator.Send(command);

        return NoContent();
    }
}