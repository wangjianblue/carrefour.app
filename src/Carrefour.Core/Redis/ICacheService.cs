using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carrefour.Core.Domain;
using StackExchange.Redis;

namespace Carrefour.Core.Redis
{
    public interface ICacheService
    {
        bool HashSet<T>(string key, string dataKey, T t);


        T HashGet<T>(string key, string dataKey); 

        /// <summary>
        /// 保存一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="list">数据集合</param>
        /// <param name="getModelId"></param>
        void HashSet<T>(string key, List<T> list, Func<T, string> getModelId);


        /// <summary>
        /// 获取hashkey所有的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        List<T> HashGetAll<T>(string key) where T : class;


        bool HashExists(string key, string field);


        long HashLength(string key);


        long HashRemove(string key, IEnumerable<string> fields);


        #region SortedSet

        bool SortedSetAdd(string key, string member, double score);


        bool SortedSetAdd<T>(string key, T value, double score);


        /// <summary>
        ///  获取全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        List<T> SortedSetRangeByRank<T>(string key);


        /// <summary>
        /// SortedSetRangeByRank
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string[] SortedSetRangeByRank(string key);



        string[] SortedSetRangeByScore(string key);


        string[] SortedSetRangeByValue(string key);


        bool SortedSetRemove(string key, string member);


        bool SortedSetRemove<T>(string key, T value);


        #endregion


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        bool Remove(string key);


        /// <summary>
        /// 匹配删除
        /// </summary>
        /// <param name="pattern"></param>
        void RemoveByPattern(string pattern);



        T Get<T>(string key, Func<T> acquire, int? cacheTime = 5);


        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="data">值</param>
        /// <param name="cacheTime">时间</param>
          void Set(string key, object data, int cacheTime);


        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
          T Get<T>(string key);
 


        /// <summary>
        /// 判断是否已经设置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
          bool IsSet(string key);

 


        #region string类型操作

        /// <summary>
        /// set or update the value for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetStringValue(string key, string value);

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        bool SetStringKey(string key, string value, TimeSpan? expiry = default(TimeSpan?));


        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SetStringKey<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?));

        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetStringKey<T>(string key) where T : class;


        /// <summary>
        /// get the value for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetStringValue(string key);

        /// <summary>
        /// Delete the value for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool DeleteStringKey(string key);

        #endregion

        #region 哈希类型操作

        /// <summary>
        /// set or update the HashValue for string key 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashkey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetHashValue(string key, string hashkey, string value);
        /// <summary>
        /// set or update the HashValue for string key 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="hashkey"></param>
        /// <param name="t">defined class</param>
        /// <returns></returns>
        bool SetHashValue<T>(String key, string hashkey, T t) where T : class;



        /// <summary>
        /// get the HashValue for string key  and hashkey
        /// </summary>
        /// <param name="key">Represents a key that can be stored in redis</param>
        /// <param name="hashkey"></param>
        /// <returns></returns>
        RedisValue GetHashValue(string key, string hashkey);


        /// <summary>
        /// get the HashValue for string key  and hashkey
        /// </summary>
        /// <param name="key">Represents a key that can be stored in redis</param>
        /// <param name="hashkey"></param>
        /// <returns></returns>
        T GetHashValue<T>(string key, string hashkey) where T : class;

        /// <summary>
        /// delete the HashValue for string key  and hashkey
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashkey"></param>
        /// <returns></returns>
        bool DeleteHashValue(string key, string hashkey);

        #endregion
    }
}
