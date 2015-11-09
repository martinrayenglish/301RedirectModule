using Sitecore;

namespace SharedSource.RedirectModule.Caching
{
    public class CacheHelper
    {
        private const string RedirectCacheName = "SharedSource.RedirectModule.Caching";

        public static ObjectCache RedirectCache
        {
            get
            {
                if (!CacheManager.Exists(RedirectCacheName) || CacheManager.Get(RedirectCacheName) == null)
                {
                    return CacheManager.Create(RedirectCacheName, StringUtil.ParseSizeString("10MB"), 600, 500);
                }

                return CacheManager.Get(RedirectCacheName);
            }
        }
    }
}
