using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Ecosia.SearchEngine.Api.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task<T?> GetObjectAsync<T>(this IDistributedCache cache, string key)
    {
        var value = await cache.GetStringAsync(key);
        return value == null ? default : JsonConvert.DeserializeObject<T>(value);
    }

    public static async Task SetObjectAsync<T>(this IDistributedCache cache, string key, T value)
    {
        await cache.SetStringAsync(key, JsonConvert.SerializeObject(value),
            new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
    }
}