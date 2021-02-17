namespace MercadoLibre.OperacionQuasar.Core.DataAccess
{
    using MercadoLibre.OperacionQuasar.Core.Models;
    using System;
    using System.Runtime.Caching;

    internal class CacheDataAccess : ICacheDataAccess
    {
        private MemoryCache MemoryCache { get; }

        public CacheDataAccess()
        {
            MemoryCache = MemoryCache.Default;
        }

        public bool TryAdd(string pKeyName, object pCachedData)
        {
            return TryAdd(pKeyName, pCachedData, 12);
        }

        public bool TryAdd(string pKeyName, object pCachedData, double pCacheHours)
        {
            try
            {
                CachedDataModel cachedData = new CachedDataModel
                {
                    Data = pCachedData,
                    CacheHours = pCacheHours
                };
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
                {
                    SlidingExpiration = cachedData.CacheExpiration
                };

                MemoryCache.Add(pKeyName, cachedData, cacheItemPolicy);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryAddOrUpdate(string pKeyName, object pCachedData)
        {
            return TryAddOrUpdate(pKeyName, pCachedData, 12);
        }

        public bool TryAddOrUpdate(string pKeyName, object pCachedData, double pCacheHours)
        {
            try
            {
                CachedDataModel cachedData = new CachedDataModel
                {
                    Data = pCachedData,
                    CacheHours = pCacheHours
                };
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy
                {
                    SlidingExpiration = cachedData.CacheExpiration
                };
                MemoryCache.Set(pKeyName, cachedData, cacheItemPolicy);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryGet(string pKeyName, out object pCachedData)
        {
            try
            {
                if (MemoryCache.Contains(pKeyName))
                {
                    CachedDataModel cachedData = MemoryCache.Get(pKeyName) as CachedDataModel;
                    pCachedData = cachedData.Data;
                    return true;
                }
                pCachedData = null;
                return false;
            }
            catch (Exception)
            {
                pCachedData = null;
                return false;
            }
        }

        public bool TryGet<T>(string pKeyName, out T pCachedData)
        {
            bool canGetValue = TryGet(pKeyName, out object cachedData);
            pCachedData = (T)cachedData;
            return canGetValue;
        }
    }
}
