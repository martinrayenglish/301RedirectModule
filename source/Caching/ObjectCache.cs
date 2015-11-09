using System;

using Sitecore.Diagnostics;

namespace SharedSource.RedirectModule.Caching
{
    public class ObjectCache : Sitecore.Caching.CustomCache
    {
        //private readonly string _name;
        //private readonly int _lifespan;
        //private readonly int _itemSize;

        public ObjectCache(string name, long maxSize, int lifespan)
            : base(name, maxSize)
        {
            Log.Info(string.Format("Creating new cache: {0} (size: {1}, lifespan: {2})", name, maxSize, lifespan),
                "SharedSource.RedirectModule.Caching");
        }

        public void SetObject(string key, object value)
        {
            SetObject(key, value);
        }

        public new void SetObject(string key, object value, long size)
        {
            SetObject(key, value, size);
        }

        public void SetObject(string key, object value, int lifespan)
        {
            SetObject(key, value, lifespan);
        }

        public void SetObject(string key, object value, long size, int lifespan)
        {
            if (value == null || InnerCache.MaxSize == 0)
            {
                return;
            }

            try
            {
                if (lifespan > 0)
                {
                    InnerCache.Add(key, value, size, TimeSpan.FromSeconds(lifespan));
                }
                else
                {
                    InnerCache.Add(key, value, size);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to set a cache object", ex, "SharedSource.RedirectModule.Caching");
            }
        }

        public new object GetObject(object key)
        {
            if (InnerCache.MaxSize == 0)
                return null;

            object result = base.GetObject(key);
           
            return result;
        }

        public void Evict(object key)
        {

            if (InnerCache.MaxSize == 0)
                return;

            if (InnerCache.ContainsKey(key))
            {
                base.Remove(key);
            }
        }

        public new void Clear()
        {
            if (InnerCache.MaxSize == 0)
                return;

            base.InnerCache.Clear();
        }
    }
}
