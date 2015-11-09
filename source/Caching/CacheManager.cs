using System.Collections.Generic;

using Sitecore.Diagnostics;
using Sitecore.StringExtensions;

namespace SharedSource.RedirectModule.Caching
{
    public static class CacheManager
    {
        private static readonly Dictionary<string, ObjectCache> Caches = new Dictionary<string, ObjectCache>();

        static CacheManager()
        {
        }

        private static readonly object CacheLock = new object();

        public static bool Exists(string name)
        {
            return Caches.ContainsKey(name);
        }

        public static ObjectCache Get(string name)
        {
            return Caches[name];
        }

        public static List<ObjectCache> GetAll()
        {
            return new List<ObjectCache>(Caches.Values);
        }

        public static ObjectCache Create(string name, long maxSize, int lifespan,
            int itemSize)
        {
            lock (CacheLock)
            {
                var cache = new ObjectCache(name, maxSize, lifespan);
                Log.Info("Initializing Cache {0}".FormatWith(name), "SharedSource.RedirectModule.Caching");
                Caches.Add(name, cache);
                return cache;
            }
        }
    }
}
