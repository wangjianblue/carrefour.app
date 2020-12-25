using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Carrefour.Data.Dapper
{
    public interface IDapperHelper
    {
        List<T> Query<T>(string sql, object param = null);

        Task<List<T>> QueryAsync<T>(string sql, object param = null);
        /// <summary>
        /// 查询第一个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T QueryFirst<T>(string sql, object param = null);
    

        /// <summary>
        /// 查询第一个数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T QueryFirstOrDefault<T>(string sql, object param = null);


    /// <summary>
    /// 查询单条数据
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
      T QuerySingle<T>(string sql, object param = null);
   

    /// <summary>
    /// 查询单条数据没有返回默认值
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
      T QuerySingleOrDefault<T>(string sql, object param = null);

    /// <summary>
    /// 增删改
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns>Number of rows affected</returns>
     int Execute(string sql, object param);
    /// <summary>
    /// Reader获取数据
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
      IDataReader ExecuteReader(string sql, object param);
 
    /// <summary>
    /// Scalar获取数据
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
      object ExecuteScalar(string sql, object param);
 

    /// <summary>
    /// Scalar获取数据
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
      T ExecuteScalarForT<T>(string sql, object param);
 

    /// <summary>
    /// 带参数的存储过程
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="param"></param>
    /// <returns></returns>
      List<T> ExecutePro<T>(string proc, object param);



    /// <summary>
    /// 事务1 - 全SQL
    /// </summary>
    /// <param name="sqlarr">多条SQL</param>
    /// <param name="param">param</param>
    /// <returns></returns>
      int ExecuteTransaction(string[] sqlarr);


    /// <summary>
    /// 事务2 - 声明参数
    ///demo:
    ///dic.Add("Insert into Users values (@UserName, @Email, @Address)",
    ///        new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
    /// </summary>
    /// <param name="Key">多条SQL</param>
    /// <param name="Value">param</param>
    /// <returns></returns>
     int ExecuteTransaction(Dictionary<string, object> dic);
    
     
    }
}