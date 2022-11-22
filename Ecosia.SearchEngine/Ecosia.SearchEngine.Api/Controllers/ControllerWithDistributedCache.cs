using Ecosia.SearchEngine.Api.Extensions;
using Ecosia.SearchEngine.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Ecosia.SearchEngine.Api.Controllers;

public abstract class ControllerWithDistributedCache :  ControllerWithMediator
{
    private readonly IDistributedCache DistributedCache;

    protected ControllerWithDistributedCache(IMediator mediator, IDistributedCache distributedCache) : base(mediator)
    {
        DistributedCache = distributedCache;
    }

    protected async Task<T> GetDataAsync<T>(IQueryWithCacheKey<T> query)
    {
        var data = await DistributedCache.GetObjectAsync<T>(query.CacheKey);
        if (data is not null)
        {
            return data;
        }
        
        data = await Mediator.Send(query);
        DistributedCache.SetObjectAsync(query.CacheKey, data);

        return data;
    }
}