namespace SharedSource.RedirectModule
{
    public class RedirectCache : Sitecore.Caching.CustomCache
    {
        public RedirectCache(string name, long maxSize) : base(name, maxSize)
        {

        }

        public object GetResponseFromCache(string ipAddress)
        {
            return GetObject(ipAddress);
        }

        public bool IsResponseInCache(string ipAddress)
        {
            object obj = GetObject(ipAddress);

            return obj != null;
        }

        public void AddResponseToCache(string ipAddress)
        {
            SetObject(ipAddress, true, sizeof(bool));
        }
    }
}
