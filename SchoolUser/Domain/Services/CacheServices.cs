using SchoolUser.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;

namespace SchoolUser.Domain.Services
{
    public class CacheServices<T> : ICacheServices<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly int _cacheDataValidity;
        private readonly int _cacheEntrySize;


        public CacheServices(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _cacheDataValidity = _configuration.GetValue<int>("CacheSettings:cacheValidity");
            _cacheEntrySize = _configuration.GetValue<int>("CacheSettings:cacheSize");
        }

        public object? TryGetObjectFromCache(string cacheKey, Type returnType)
        {
            if (_memoryCache.TryGetValue(cacheKey, out var cachedObject))
            {
                Console.WriteLine($"FROM CACHED : {cacheKey}");
                return cachedObject;
            }

            Console.WriteLine($"NOT FROM CACHED : {cacheKey}");
            return null;
        }

        public void SetCacheObject(string cacheKey, object cachedObject)
        {
            try
            {
                var cacheEnrty = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(_cacheDataValidity))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(_cacheDataValidity))
                .SetPriority(CacheItemPriority.Normal)
                .SetSize(_cacheEntrySize);

                _memoryCache.Set(cacheKey, cachedObject, cacheEnrty);
            }
            catch (Exception e)
            {
                throw new Exception("Caching Error", e);
            }
        }

        public void RemoveCacheObject(string cacheKey)
        {
            try
            {
                _memoryCache.Remove(cacheKey);
            }
            catch (Exception e)
            {
                throw new Exception("Caching Error", e);
            }
        }

    }
}