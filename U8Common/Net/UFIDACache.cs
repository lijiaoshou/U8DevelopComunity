using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.Net
{
    /// <summary>
    /// .net缓存策略
    /// </summary>
    public class UFIDAHttpCache : ICache
    {
        private static object syncObject = new object();
        /// <summary>
        /// 构造方法
        /// </summary>
        protected UFIDAHttpCache() { }

        private static UFIDAHttpCache instance;
        /// <summary>
        /// 
        /// </summary>
        public static UFIDAHttpCache Current
        {
            get
            {
                if (instance == null)
                {

                    lock (syncObject)
                    {
                        if (instance == null)
                        {
                            instance = new UFIDAHttpCache();
                        }
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return System.Web.HttpContext.Current.Cache[key];
        }
        /// <summary>
        /// 获取缓存（泛型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)System.Web.HttpContext.Current.Cache[key];
        }
        /// <summary>
        /// 加入缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(string key, object obj)
        {
            System.Web.HttpContext.Current.Cache[key] = obj;
            return true;
        }
        /// <summary>
        /// 加入缓存并设置时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool Add(string key, object obj, DateTime timeOut)
        {
            System.Web.HttpContext.Current.Cache.Insert(key, obj, null, timeOut, System.Web.Caching.Cache.NoSlidingExpiration);
            return true;
        }
        /// <summary>
        /// 重新添加缓存（清除缓存）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool Set(string key, object obj, DateTime timeOut)
        {
            Delete(key);
            System.Web.HttpContext.Current.Cache.Insert(key, obj, null, timeOut, System.Web.Caching.Cache.NoSlidingExpiration);
            return true;
        }
        /// <summary>
        /// 重新添加缓存（清除缓存）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Set(string key, object obj)
        {
            Delete(key);
            System.Web.HttpContext.Current.Cache[key] = obj;
            return true;
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
            System.Web.HttpContext.Current.Cache.Remove(key);
            return true;
        }
    }

    /// <summary>
    /// MemCache缓存策略
    /// </summary>
    public class SlMemCached : ICache
    {
        /// <summary>
        /// 缓存客户端对象
        /// </summary>
        public UFIDAMemcachedClient memcachedClient;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="client"></param>
        public SlMemCached(UFIDAMemcachedClient client)
        {
            memcachedClient = client;
        }
        /// <summary>
        /// 判断主键是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return memcachedClient.CacheClient.KeyExists(key);
        }
        /// <summary>
        /// 获取memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return memcachedClient.CacheClient.Get(key);
        }
        /// <summary>
        /// 获取memcached缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)memcachedClient.CacheClient.Get(key);
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(string key, object obj)
        {
            Delete(key);
            return memcachedClient.CacheClient.Set(key, obj);
        }
        /// <summary>
        /// 添加memcached缓存并设置超时时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool Add(string key, object obj, DateTime timeOut)
        {
            Delete(key);
            return memcachedClient.CacheClient.Set(key, obj, timeOut);
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Set(string key, object obj)
        {
            return memcachedClient.CacheClient.Set(key, obj, DateTime.Now.AddHours(1));
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="validateTime"></param>
        /// <returns></returns>
        public bool Set(string key, object obj, DateTime validateTime)
        {
            return memcachedClient.CacheClient.Set(key, obj, validateTime);
        }
        /// <summary>
        /// 添加memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public bool Set(string key, object obj, int hours)
        {
            return memcachedClient.CacheClient.Set(key, obj, DateTime.Now.AddHours(hours));
        }
        /// <summary>
        /// 获取多个memcached缓存
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>Hashtable</returns>
        public Hashtable GetMultiple(string[] keys)
        {
            return memcachedClient.CacheClient.GetMultiple(keys);
        }
        /// <summary>
        /// 删除memcached缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
            return memcachedClient.CacheClient.Delete(key);
        }

        #region 状态查询
        /// <summary>
        /// memcached状态查询
        /// </summary>
        /// <returns></returns>
        public IDictionary GetStats()
        {
            return (IDictionary)memcachedClient.CacheClient.Stats();
        }
        #endregion
    }

    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        object Get(string key);

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key">键</param>
        ///<returns>值</returns>
        T Get<T>(string key);

        /// <summary>
        /// 添加指定Key的对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        bool Add(string key, object obj);

        /// <summary>
        /// 添加指定Key的对象
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="TimeOut">到期时间</param>
        bool Add(string key, object obj, DateTime TimeOut);

        /// <summary>
        /// 更新指定Key的对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Set(string key, object obj);

        /// <summary>
        /// 更新指定Key的对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="TimeOut">到期时间</param>
        /// <returns></returns>
        bool Set(string key, object obj, DateTime TimeOut);

        /// <summary>
        /// 移除指定key的对象
        /// </summary>
        /// <param name="key">键</param>
        bool Delete(string key);
    }
}
