using Ecosia.SearchEngine.Api.Extensions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecosia.SearchEngine.Api.Controllers;

public abstract class ApplicationControllerWithDistributedCache :  ApplicationControllerWithMediator
{
    private readonly IDistributedCache DistributedCache;

    protected ApplicationControllerWithDistributedCache(IMediator mediator, IDistributedCache distributedCache) : base(mediator)
    {
        DistributedCache = distributedCache;
    }

    protected async Task<T> GetDataAsync<T>(IRequest<T> query)
    {
        var data = await DistributedCache.GetObjectAsync<T>(query.ToString());
        if (data is not null)
        {
            return data;
        }
        
        data = await Mediator.Send(query);
        DistributedCache.SetObjectAsync(query.ToString(), data);

        return data;
    }
}