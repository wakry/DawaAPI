using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DawaAPI.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordId,
            T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId,jsonData);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetAsync(recordId);

            if(jsonData == null) {  return default(T); }

            return JsonSerializer.Deserialize<T>(jsonData);
        }

            
    }
}
