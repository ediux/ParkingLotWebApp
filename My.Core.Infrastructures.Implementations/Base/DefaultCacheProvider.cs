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
           
        }

        public void Invalidate(string key)
        {
            
        }

        public bool IsSet(string key)
        {
            
        }

        public void Set(string key, object data, int cacheTime)
        {
           
        }
    }
}