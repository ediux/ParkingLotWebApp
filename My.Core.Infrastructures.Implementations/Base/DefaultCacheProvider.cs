using My.Core.Infrastructures.Implementations.Models;
using System;
using System.Runtime.Caching;

namespace My.Core.Infrastructures.Implementations.Base
{
    public class DefaultCacheProvider : ICacheProvider
    {
        //private  ObjectCache Cache { get { return MemoryCache.Default; } }

        public object Get(string key)
        {
            return MemoryCache.Default[key];
        }

        public void Invalidate(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public bool IsSet(string key)
        {
            return (MemoryCache.Default[key] != null);
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            MemoryCache.Default.Add(new CacheItem(key, data), policy);
        }
    }
}