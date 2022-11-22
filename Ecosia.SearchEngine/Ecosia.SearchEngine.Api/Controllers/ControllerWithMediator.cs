using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiController]
public abstract class ControllerWithMediator : ControllerBase
{
    protected readonly IMediator Mediator;

    protected ControllerWithMediator(IMediator mediator)
    {
        Mediator = mediator;
    }
}