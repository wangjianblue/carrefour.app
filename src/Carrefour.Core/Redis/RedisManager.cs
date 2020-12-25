using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
namespace Carrefour.Core.Redis
{
    public class RedisManager : ICacheService
    {
        #region 字段
        protected IDatabase Cache;
        private readonly ConnectionMultiplexer _connection;
        private readonly string _instance;
        private readonly int _database = 0;
        #endregion
        public RedisManager(Action<RedisCacheOptions> redisCacheOption, int database = 0)
        {
            var options = new RedisCacheOptions();
            redisCacheOption(options);
            _connection = ConnectionMultiplexer.Connect(options.Configuration);
            Cache = _connection.GetDatabase(database);
            _instance = options.InstanceName;
            _database = database;
        }
        public bool HashSet<T>(string key, string dataKey, T t)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            var json = t is string ? t.ToString() : JsonConvert.SerializeObject(t);
            return Cache.HashSet(RealKey(key), dataKey, json);
        }

        public T HashGet<T>(string key, string dataKey)
        {
            if (string.IsNullOrEmpty(key)) return default(T);
            var value = Cache.HashGet(RealKey(key), dataKey);
            return value.IsNullOrEmpty ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        //public IDictionary<string, T> HashGetAll<T>(string key)
        //{
        //    var realKey = RealKey(key);
        //    var dic = new Dictionary<string, T>();
        //    foreach (var kv in Cache.HashGetAll(realKey))
        //    {
        //        dic.Add(kv.Name, JsonConvert.DeserializeObject<T>(kv.Value));
        //    }

        //    return dic;
        //}
        /// <summary>
        /// 保存一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="list">数据集合</param>
        /// <param name="getModelId"></param>
        public void HashSet<T>(string key, List<T> list, Func<T, string> getModelId)
        {
            if (string.IsNullOrEmpty(key))
                return;
            List<HashEntry> listHashEntry = new List<HashEntry>();
            foreach (var item in list)
            {
                string json = JsonConvert.SerializeObject(item);
                listHashEntry.Add(new HashEntry(getModelId(item), json));
            }

            Cache.HashSet(RealKey(key), listHashEntry.ToArray());
        }

        /// <summary>
        /// 获取hashkey所有的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> HashGetAll<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
                return null;
            List<T> result = new List<T>();
            HashEntry[] arr = Cache.HashGetAll(RealKey(key));
            foreach (var item in arr)
            {
                if (!item.Value.IsNullOrEmpty)
                {
                    result.Add(JsonConvert.DeserializeObject<T>(item.Value));
                }
            }
            return result;
        }

        public bool HashExists(string key, string field)
        {
            if (string.IsNullOrEmpty(key))
                return false;

            return Cache.HashExists(RealKey(key), field);
        }

        public long HashLength(string key)
        {
            if (string.IsNullOrEmpty(key))
                return -1; 
            return Cache.HashLength(RealKey(key));
        }
        public long HashRemove(string key, IEnumerable<string> fields)
        {
            if (string.IsNullOrEmpty(key))
                return -1;
    
            var redisFields = fields.Select(p => (RedisValue)p).ToArray();
            return Cache.HashDelete(RealKey(key), redisFields);
        }

        #region SortedSet

        public bool SortedSetAdd(string key, string member, double score)
        {

            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            return Cache.SortedSetAdd(RealKey(key), member, score);
        }
        public bool SortedSetAdd<T>(string key, T value, double score)
        {
      
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }
            return Cache.SortedSetAdd(RealKey(key), JsonConvert.SerializeObject(value), score);
        }

        /// <summary>
        ///  获取全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> SortedSetRangeByRank<T>(string key)
        {
          
            if (string.IsNullOrEmpty(key))
                return default;
            var values = Cache.SortedSetRangeByRank(RealKey(key));

            return values?.Select(item => JsonConvert.DeserializeObject<T>(item)).ToList();
        }

        /// <summary>
        /// SortedSetRangeByRank
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string[] SortedSetRangeByRank(string key)
        {
         
            if (string.IsNullOrEmpty(key))
                return default;
            var values = Cache.SortedSetRangeByRank(RealKey(key));
            return values.Select(u => (string)u).ToArray();
        }


        public string[] SortedSetRangeByScore(string key)
        {
    
            if (string.IsNullOrEmpty(key))
                return default;
            var values = Cache.SortedSetRangeByScore(RealKey(key));
            return values.Select(u => (string)u).ToArray();
        }

        public string[] SortedSetRangeByValue(string key)
        {
         
            if (string.IsNullOrEmpty(key))
                return default;
            var values = Cache.SortedSetRangeByValue(RealKey(key));
            return values.Select(u => (string)u).ToArray();
        }

        public bool SortedSetRemove(string key, string member)
        {
          
            return !string.IsNullOrEmpty(key) && Cache.SortedSetRemove(RealKey(key), member);
        }
        public bool SortedSetRemove<T>(string key, T value)
        {
    
            return !string.IsNullOrEmpty(key) && Cache.SortedSetRemove(RealKey(key), JsonConvert.SerializeObject(value));
        }

        #endregion


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
          
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Cache.KeyDelete(RealKey(key));
        }

        /// <summary>
        /// 匹配删除
        /// </summary>
        /// <param name="pattern"></param>
        public void RemoveByPattern(string pattern)
        {

            if (string.IsNullOrEmpty(pattern))
                return;

            foreach (var ep in _connection.GetEndPoints())
            {
                var server = _connection.GetServer(ep);
                var keys = server.Keys(pattern: _instance + ":" + pattern + "*", database: _database);
                foreach (var key in keys)
                {
                    Cache.KeyDelete(RealKey(key));
                }
            }
        }
        /// <summary>
        /// 生成key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual string RealKey(string key)
        {
            return $"{_instance}{key}";
        }



        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="data">值</param>
        /// <param name="cacheTime">时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (string.IsNullOrEmpty(key))
                return;
            if (data == null)
            {
                return;
            }
            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            Cache.StringSet(RealKey(key), entryBytes, expiresIn);
        }
        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
                return default(T);
            var rValue = Cache.StringGet(RealKey(key));
            if (!rValue.HasValue)
            {
                return default(T);
            }

            var result = Deserialize<T>(rValue);

            return result;
        }

        public virtual T Get<T>(string key, Func<T> acquire, int? cacheTime = 5)
        {
            if (string.IsNullOrEmpty(key))
                return default(T);
            //item already is in cache, so return it
            if (this.IsSet(key))
                return this.Get<T>(key);

            //or create it using passed function
            var result = acquire();

            //and set in cache (if cache time is defined)
            if ((cacheTime) > 0)
                this.Set(key, result, cacheTime ?? 60);

            return result;
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObject"></param>
        /// <returns></returns>
        protected virtual T Deserialize<T>(byte[] serializedObject)
        {
            if (serializedObject == null)
            {
                return default(T);
            }
            var json = Encoding.UTF8.GetString(serializedObject);
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// 判断是否已经设置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual bool IsSet(string key)
        {
            return Cache.KeyExists(RealKey(key));
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns>byte[]</returns>
        private byte[] Serialize(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
        }

        #region string类型操作
        /// <summary>
        /// set or update the value for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetStringValue(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            return Cache.StringSet(RealKey(key), value);
        }
        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool SetStringKey(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            if (string.IsNullOrEmpty(key))
                return false;
            return Cache.StringSet(RealKey(key), value, expiry);
        }
        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SetStringKey<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            if (string.IsNullOrEmpty(key))
                return false;
            string json = JsonConvert.SerializeObject(obj);
            return Cache.StringSet(RealKey(key), json, expiry);
        }
        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetStringKey<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
                return default(T);
            var result = Cache.StringGet(RealKey(key));
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
        /// <summary>
        /// get the value for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetStringValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;
            return Cache.StringGet(RealKey(key));
        }

        /// <summary>
        /// Delete the value for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteStringKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            return Cache.KeyDelete(RealKey(key));
        }
        #endregion

        #region 哈希类型操作
        /// <summary>
        /// set or update the HashValue for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashkey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHashValue(string key, string hashkey, string value)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            return Cache.HashSet(RealKey(key), hashkey, value);
        }
        /// <summary>
        /// set or update the HashValue for string key 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashkey"></param>
        /// <param name="t">defined class</param>
        /// <returns></returns>
        public bool SetHashValue<T>(String key, string hashkey, T t) where T : class
        {
            if (string.IsNullOrEmpty(key))
                return false;
            var json = JsonConvert.SerializeObject(t);
            return Cache.HashSet(RealKey(key), hashkey, json);
        }


        /// <summary>
        /// get the HashValue for string key  and hashkey
        /// </summary>
        /// <param name="key">Represents a key that can be stored in redis</param>
        /// <param name="hashkey"></param>
        /// <returns></returns>
        public RedisValue GetHashValue(string key, string hashkey)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            RedisValue result = Cache.HashGet(RealKey(key), hashkey);
            return result;
        }
        /// <summary>
        /// get the HashValue for string key  and hashkey
        /// </summary>
        /// <param name="key">Represents a key that can be stored in redis</param>
        /// <param name="hashkey"></param>
        /// <returns></returns>
        public T GetHashValue<T>(string key, string hashkey) where T : class
        {
            if (string.IsNullOrEmpty(key))
                return default(T);
            RedisValue result = Cache.HashGet(RealKey(key), hashkey);
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
        /// <summary>
        /// delete the HashValue for string key  and hashkey
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashkey"></param>
        /// <returns></returns>
        public bool DeleteHashValue(string key, string hashkey)
        {
            if (string.IsNullOrEmpty(key))
                return false;
            return Cache.HashDelete(RealKey(key), hashkey);
        }
        #endregion

    }

}