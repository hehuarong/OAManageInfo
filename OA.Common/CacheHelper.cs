using System;
using System.Web;
using System.Collections;
using System.Web.Caching;

namespace Common2
{
    public class CacheHelper
    {
        /// <summary>  
        /// 获取数据缓存  
        /// </summary>  
        /// <param name="cacheKey">键</param>  
        public static object GetCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache.Get(cacheKey);
            return objCache;
        }
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string cacheKey, object objObject)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject);
        }
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string cacheKey, object objObject, int timeout = 1200)
        {
            try
            {
                if (objObject == null) return;
                var objCache = HttpRuntime.Cache;
                //相对过期  
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null);  
                //绝对过期时间  
                objCache.Insert(cacheKey, objObject, null, DateTime.Now.AddSeconds(timeout), TimeSpan.Zero, CacheItemPriority.High, null);
            }
            catch (Exception)
            {
                RemoveAllCache(cacheKey);
                //throw;  
            }
        }
        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public static void RemoveAllCache(string cacheKey)
        {
            try
            {
                var cache = HttpRuntime.Cache;
                cache.Remove(cacheKey);
            }
            catch
            {
            }

        }
        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        public static void RemoveAllCache()
        {
            var cache = HttpRuntime.Cache;
            var cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }
        protected static volatile System.Web.Caching.Cache webCache = System.Web.HttpRuntime.Cache;
        /// <summary>
        ///  获取当前应用程序的 System.Web.Caching.Cache
        /// </summary>
        public static System.Web.Caching.Cache GetWebCacheObj
        {
            get { return webCache; }
        }
        protected int _timeOut = 3600;


    }
}
