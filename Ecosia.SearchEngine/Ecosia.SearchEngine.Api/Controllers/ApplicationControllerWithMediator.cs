using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecosia.SearchEngine.Api.Controllers;

[ApiController]
public abstract class ApplicationControllerWithMediator : ControllerBase
{
    protected readonly IMediator Mediator;

    protected ApplicationControllerWithMediator(IMediator mediator)
    {
        Mediator = mediator;
    }
}