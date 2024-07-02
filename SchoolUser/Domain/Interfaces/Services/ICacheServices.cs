namespace SchoolUser.Domain.Interfaces.Services
{
    public interface ICacheServices<T>
    {
        object? TryGetObjectFromCache(string cacheKey, Type returnType);
        void SetCacheObject(string cacheKey, object cachedObject);
        void RemoveCacheObject(string cacheKey);
    }
}