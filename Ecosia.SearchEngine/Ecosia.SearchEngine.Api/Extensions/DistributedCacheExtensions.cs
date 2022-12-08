using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Ecosia.SearchEngine.Api.Extensions;

public static class DistributedCacheExtensions
{
    private static readonly bool _useCache = false;
    
    public static async Task<T?> GetObjectAsync<T>(this IDistributedCache cache, string key)
    {
        if (!_useCache)
        {
            return await Task.FromResult(default(T));
        }
        
        var value = await cache.GetStringAsync(key);
        return value == null ? default : JsonConvert.DeserializeObject<T>(value);
    }

    public static async Task SetObjectAsync<T>(this IDistributedCache cache, string key, T value)
    {
        if (!_useCache)
        {
            await Task.FromResult(default(T));
            return;
        }
        
        await cache.SetStringAsync(key, JsonConvert.SerializeObject(value),
            new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
    }
}