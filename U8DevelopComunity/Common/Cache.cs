using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeIT.MemCached;
using U8.Framework.Configuration;

namespace U8DevelopComunity.Common
{
    public class Cache
    {

        private static string MemcachedServer = (U8Config.GetValue<string>("MemcachedServer") == null ? "" : U8Config.GetValue<string>("MemcachedServer"));
        private static string GlobalPrefix = (U8Config.GetValue<string>("MemcachedPrefix") == null ? "" : U8Config.GetValue<string>("MemcachedPrefix"));
        private static string ViaCache = (U8Config.GetValue<string>("ViaCache") == null ? "" : U8Config.GetValue<string>("ViaCache")).ToLower();
        private MemcachedClient memClient;
        private System.Web.Caching.Cache aspClient;
        public static uint FiveMinute = 300;
        public static uint OneHour = 3660;
        public static uint OneDay = 86400;
        private static object lockObj = new object();
        private static Cache _instance;
        public static Cache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new Cache();
                        }
                    }
                }
                return _instance;
            }
        }

        private Cache()
        {
            if (ViaCache == "memcached")
            {
                if (!MemcachedClient.Exists("Server"))
                {
                    string serverList = MemcachedServer;
                    if (!String.IsNullOrEmpty(serverList))
                    {
                        MemcachedClient.Setup("Server", serverList.Split(new char[] { ',' }));
                    }
                }
                this.memClient = MemcachedClient.GetInstance("Server");
            }
            else if (ViaCache == "aspnet")
            {
                this.aspClient = System.Web.HttpContext.Current.Cache;
            }
            else { throw new Exception("Config Error"); }
        }

        public void Add(string key, object value, uint seconds = 300)
        {
            key = GlobalPrefix + key;
            if (ViaCache == "memcached")
            {
                memClient.Set(key, value, DateTime.Now.AddSeconds(seconds));
            }
            else if (ViaCache == "aspnet")
            {
                //aspnet和memclient采取相同的过期策略，到达指定时间时必须释放
                aspClient.Insert(key, value, null, DateTime.Now.AddSeconds(seconds), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }

        public void Remove(string key)
        {
            key = GlobalPrefix + key;
            if (ViaCache == "memcached")
            {
                memClient.Delete(key);
            }
            else if (ViaCache == "aspnet")
            {
                aspClient.Remove(key);
            }
        }

        public object Get(string key)
        {
            key = GlobalPrefix + key;
            if (ViaCache == "memcached")
            {
                return memClient.Get(key);
            }
            else if (ViaCache == "aspnet")
            {
                return aspClient.Get(key);
            }
            return null;
        }

        public void Reset()
        {
            if (ViaCache == "memcached")
            {
                memClient.FlushAll();
            }
            else if (ViaCache == "aspnet")
            {
                var _enum = aspClient.GetEnumerator();
                while (_enum.MoveNext())
                {
                    aspClient.Remove(_enum.Key.ToString());
                }
            }
        }
    }
}
