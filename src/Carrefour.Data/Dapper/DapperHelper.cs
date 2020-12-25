using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Carrefour.Data;
namespace Carrefour.Data.Dapper
{
    public class DapperHelper : IDapperHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string _connectionString;

        public DapperHelper(string connectionString)
        {
            this._connectionString = connectionString;
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        public List<T> Query<T>(string sql, object param = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<T>(sql, param).ToList();
            }
        }
        public async Task<List<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return (List<T>) await con.QueryAsync<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询第一个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string sql, object param = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<T>(sql, param).ToList().First();
            }
        }
 

        /// <summary>
        /// 查询第一个数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<T>(sql, param).ToList().FirstOrDefault();
            }
        }

 

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T QuerySingle<T>(string sql, object param = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<T>(sql, param).ToList().Single();
            }
        }

        /// <summary>
        /// 查询单条数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T QuerySingleOrDefault<T>(string sql, object param = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<T>(sql, param).ToList().SingleOrDefault();
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns>Number of rows affected</returns>
        public int Execute(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Execute(sql, param);
            }
        }

        /// <summary>
        /// Reader获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.ExecuteReader(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.ExecuteScalar(sql, param);
            }
        }



        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T ExecuteScalarForT<T>(string sql, object param)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.ExecuteScalar<T>(sql, param);
            }
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T> ExecutePro<T>(string proc, object param)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                List<T> list = con.Query<T>(proc,
                    param,
                    null,
                    true,
                    null,
                    CommandType.StoredProcedure).ToList();
                return list;
            }
        }


        /// <summary>
        /// 事务1 - 全SQL
        /// </summary>
        /// <param name="sqlarr">多条SQL</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public int ExecuteTransaction(string[] sqlarr)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in sqlarr)
                        {
                            result += con.Execute(sql, null, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 事务2 - 声明参数
        ///demo:
        ///dic.Add("Insert into Users values (@UserName, @Email, @Address)",
        ///        new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
        /// </summary>
        /// <param name="Key">多条SQL</param>
        /// <param name="Value">param</param>
        /// <returns></returns>
        public int ExecuteTransaction(Dictionary<string, object> dic)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in dic)
                        {
                            result += con.Execute(sql.Key, sql.Value, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }


    }
}