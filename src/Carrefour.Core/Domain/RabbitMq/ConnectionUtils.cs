using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Carrefour.Core.Domain.RabbitMq
{
    public static class ConnectionUtils
    {
  
        public static string GetJsonByObject(this Object obj)
        {
            //实例化DataContractJsonSerializer对象，需要待序列化的对象类型
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            //实例化一个内存流，用于存放序列化后的数据
            MemoryStream stream = new MemoryStream();
            //使用WriteObject序列化对象
            serializer.WriteObject(stream, obj);
            //写入内存流中
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            //通过UTF8格式转换为字符串
            return Encoding.UTF8.GetString(dataBytes);
        }

        public static Object GetObjectByJson(this string jsonString, Type obj)
        {
            //实例化DataContractJsonSerializer对象，需要待序列化的对象类型
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj);
            //把Json传入内存流中保存
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            // 使用ReadObject方法反序列化成对象
            return serializer.ReadObject(stream);
        }

        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>JSON字符串</returns>
        public static string ToJSON(this object o)
        {
            if (o == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(o);
        }
        /// <summary>
        /// 把Json文本转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T FromJSON<T>(this string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
