using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace U8.Framework.Data
{
    /// <summary>
    /// 数据库操作（只支持32位的SQLite）
    /// </summary>
    public static class U8DatabaseSQLite
    {
        /// <summary>
        /// 执行INSERT、UPDATE、DELETE以及不返回数据集的存储过程
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sentence">SQL命令或存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, string sentence, DbParameter[] parameters = null)
        {
            DbProviderFactory factory = GetDbProviderFactory();
            using (DbConnection dbConnection = factory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbCommand.CommandText = sentence;
                    dbCommand.CommandTimeout = 0;
                    if (parameters != null)
                    {
                        dbCommand.Parameters.AddRange(parameters);
                    }
                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行SELECT以及返回数据集的存储过程，返回读取器。读取器关闭时，连接会自动关闭。不建议在BS项目中使用，因为传统的DataSet方式要更容易控制缓存。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sentence">SQL命令或存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>读取器</returns>
        public static DbDataReader ExecuteReader(string connectionString, string sentence, DbParameter[] parameters = null)
        {
            DbProviderFactory factory = GetDbProviderFactory();
            DbConnection dbConnection = factory.CreateConnection();
            dbConnection.ConnectionString = connectionString;
            try
            {
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbCommand.CommandText = sentence;
                    dbCommand.CommandTimeout = 0;
                    if (parameters != null)
                    {
                        dbCommand.Parameters.AddRange(parameters);
                    }
                    dbConnection.Open();
                    return dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception exception)
            {
                //如果发生异常才关闭连接，然后抛出异常信息。如果未发生异常，不能关闭连接，连接是由客户端程序员控制。
                dbConnection.Close();
                throw exception;
            }
        }

        /// <summary>
        /// 返回数据集的第一行第一列。数据库中为Null或空，都返回Null
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sentence">SQL命令或存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>数据集的第一行第一列</returns>
        public static object ExecuteScalar(string connectionString, string sentence, DbParameter[] parameters = null)
        {
            object result = null;
            DbProviderFactory factory = GetDbProviderFactory();
            using (DbConnection dbConnection = factory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionString;
                using (DbCommand dbCommand = dbConnection.CreateCommand())
                {
                    dbCommand.CommandText = sentence;
                    dbCommand.CommandTimeout = 0;
                    if (parameters != null)
                    {
                        dbCommand.Parameters.AddRange(parameters);
                    }
                    dbConnection.Open();
                    result = dbCommand.ExecuteScalar();
                }
            }
            //如果返回的是DBNull类型或者是空，则返回null
            if (result == DBNull.Value || result.ToString().Trim().Length == 0)
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// 填充数据集（数据集不是作为返回值，而是作为参数传入，这个决策主要是为了可以使用强类型的数据集。传入强类型的数据集也可以使用）
        /// </summary>
        /// <param name="dataSet">数据集（可以是强类型的数据集）</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sentence">SQL语句或存储过程名</param>
        /// <param name="parameters">参数数组</param>
        public static void Fill(string connectionString, string sentence, DataSet dataSet, DbParameter[] parameters = null)
        {
            DbProviderFactory factory = GetDbProviderFactory();
            DbConnection dbConnection = factory.CreateConnection();
            dbConnection.ConnectionString = connectionString;

            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = sentence;
                dbCommand.CommandTimeout = 0;
                if (parameters != null)
                {
                    dbCommand.Parameters.AddRange(parameters);
                }
                using (DbDataAdapter dbDataAdapter = factory.CreateDataAdapter())
                {
                    dbDataAdapter.SelectCommand = dbCommand;
                    dbDataAdapter.Fill(dataSet);
                }
            }
        }

        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="dataTable">数据表（可以是强类型的数据表）</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sentence">SQL语句或存储过程名</param>
        /// <param name="parameters">参数数组</param>
        public static void Fill(string connectionString, string sentence, DataTable dataTable, DbParameter[] parameters = null)
        {
            DbProviderFactory factory = GetDbProviderFactory();
            DbConnection dbConnection = factory.CreateConnection();
            dbConnection.ConnectionString = connectionString;

            using (DbCommand dbCommand = dbConnection.CreateCommand())
            {
                dbCommand.CommandText = sentence;
                dbCommand.CommandTimeout = 0;
                if (parameters != null)
                {
                    dbCommand.Parameters.AddRange(parameters);
                }
                using (DbDataAdapter dbDataAdapter = factory.CreateDataAdapter())
                {
                    dbDataAdapter.SelectCommand = dbCommand;
                    dbDataAdapter.Fill(dataTable);
                }
            }
        }

        /// <summary>
        /// 根据数据库类型获得某种数据库系列对象创建工厂
        /// </summary>
        /// <returns>创建工厂</returns>
        public static DbProviderFactory GetDbProviderFactory()
        {
            return SQLiteFactory.Instance;
        }
    }
}
