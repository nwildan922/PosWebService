using System;
using System.Runtime.Caching;
namespace Pos.Helpers
{
    public static class MemoryChacer
    {
        public static string GetData(string cacheItemName)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = cache[cacheItemName];
            if (cachedObject != null)
            {
                return cachedObject.ToString();
            }
            else
            {
                return null;
            }

        }

        public static void SetData(string cacheItemName, string value)
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60);
            cache.Set(cacheItemName, value, policy);
        }

        public static void SetData<T>(string cacheItemName, T entity) where T : class
        {
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60);
            cache.Set(cacheItemName, entity, policy);
        }

        public static T GetData<T>(string cacheItemName)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = (T)cache[cacheItemName];
            return cachedObject;
        }

        public static void ClearData(string cacheItemName)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(cacheItemName);
        }
    }
}
