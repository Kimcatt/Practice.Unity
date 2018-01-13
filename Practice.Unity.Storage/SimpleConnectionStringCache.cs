using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Storage
{
    public class SimpleConnectionStringCache : IConnectionStringCache
    {
        private ConcurrentDictionary<string, string> memoryCache = new ConcurrentDictionary<string, string>();

        public string GetConnectionString(string key)
        {
            string connectioString = null;
            if (memoryCache.TryGetValue(key, out connectioString))
            {
                return connectioString;
            }
            return null;
        }

        public bool IsInCache(string key)
        {
            return memoryCache.ContainsKey(key);
        }

        public void SaveConnectionString(string key, string val)
        {
            memoryCache[key] = val;
        }
    }
}
