using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Web;
using U8.Framework.Configuration;
using System.Reflection;

namespace U8.Framework.Data
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public static class U8Database
    {
        /// <summary>
        /// 执行INSERT、UPDATE、DELETE以及不返回数据集的存储过程
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sentence">SQL命令或存储过程名</param>
        /// <param name="parameters">参数数组</param>
        /// <param name="databaseType">数据库类型</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string connectionString, string sentence, DbParameter[] parameters = null, U8DatabaseType databaseType = U8DatabaseType.SqlServer)
        {
            sentence = SqlDebug(sentence, parameters);
            DbProviderFactory factory = GetDbProviderFactory(databaseType);
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
        /// <param name="databaseType">数据库类型</param>
        /// <returns>读取器</returns>
        public static DbDataReader ExecuteReader(string connectionString, string sentence, DbParameter[] parameters = null, U8DatabaseType databaseType = U8DatabaseType.SqlServer)
        {
            sentence = SqlDebug(sentence, parameters);
            DbProviderFactory factory = GetDbProviderFactory(databaseType);
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
        /// <param name="databaseType">数据库类型</param>
        /// <returns>数据集的第一行第一列</returns>
        public static object ExecuteScalar(string connectionString, string sentence, DbParameter[] parameters = null, U8DatabaseType databaseType = U8DatabaseType.SqlServer)
        {
            sentence = SqlDebug(sentence, parameters);
            object result = null;
            DbProviderFactory factory = GetDbProviderFactory(databaseType);
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
            if (result == null || result == DBNull.Value || result.ToString().Trim().Length == 0)
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
        /// <param name="databaseType">数据库类型</param>
        public static void Fill(string connectionString, string sentence, DataSet dataSet, DbParameter[] parameters = null, U8DatabaseType databaseType = U8DatabaseType.SqlServer)
        {
            sentence = SqlDebug(sentence, parameters);
            DbProviderFactory factory = GetDbProviderFactory(databaseType);
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
        /// <param name="databaseType">数据库类型</param>
        public static void Fill(string connectionString, string sentence, DataTable dataTable, DbParameter[] parameters = null, U8DatabaseType databaseType = U8DatabaseType.SqlServer)
        {
            sentence = SqlDebug(sentence, parameters);
            DbProviderFactory factory = GetDbProviderFactory(databaseType);
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
        /// <param name="databaseType">数据库类型</param>
        /// <returns>创建工厂</returns>
        public static DbProviderFactory GetDbProviderFactory(U8DatabaseType databaseType = U8DatabaseType.SqlServer)
        {
            DbProviderFactory instance = null;
            switch (databaseType)
            {
                case U8DatabaseType.SqlServer:
                    instance = SqlClientFactory.Instance;
                    break;
                case U8DatabaseType.OleDb:
                    instance = OleDbFactory.Instance;
                    break;
            }
            return instance;
        }

        /// <summary>
        /// 批量拷贝
        /// </summary>
        /// <param name="connectionString">数据库链接串</param>
        /// <param name="dataTable">数据源</param>
        /// <param name="destinationTableName">目标表名</param>
        /// <param name="batchSize">每批大小</param>
        /// <param name="notifyAfter">多少行发送通知</param>
        public static void BulkCopy(string connectionString, DataTable dataTable, string destinationTableName, int batchSize = 10000, int notifyAfter = 10000)
        {
            //批量拷贝
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connectionString))
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }
                sqlBulkCopy.BulkCopyTimeout = 0;
                sqlBulkCopy.BatchSize = batchSize;
                sqlBulkCopy.NotifyAfter = notifyAfter;
                sqlBulkCopy.DestinationTableName = destinationTableName;
                sqlBulkCopy.WriteToServer(dataTable);
            }
        }

        private const string sqlCommandKeywords = "and|exec|execute|insert|select|delete|update|count|chr|mid|master|" +
             "char|declare|sitename|net user|xp_cmdshell|or|create|drop|table|from|grant|use|group_concat|column_name|" +
               "information_schema.columns|table_schema|union|where|select|delete|update|orderhaving|having|by|count|*|truncate|like";

        private const string sqlSeparatKeywords = "'|;|--|\'|\"|/*|%|#";

        private static readonly List<string> sqlKeywordsArray = new List<string>();

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static U8Database()
        {
            sqlKeywordsArray.AddRange(sqlSeparatKeywords.Split('|'));
            sqlKeywordsArray.AddRange(Array.ConvertAll<string, string>(sqlCommandKeywords.Split('|'), h => h = h + " "));
            sqlKeywordsArray.AddRange(Array.ConvertAll<string, string>(sqlCommandKeywords.Split('|'), h => h = " " + h));
        }

        /// <summary>
        /// 是否安全
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回</returns>
        public static bool IsSafetySql(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            input = (HttpUtility.UrlDecode(input)).ToLower();

            foreach (var sqlKeyword in sqlKeywordsArray)
            {
                if (input.IndexOf(sqlKeyword) >= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 返回安全字符串
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>返回</returns>
        public static string GetSafetySql(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (IsSafetySql(input)) { return input; }
            input = (HttpUtility.UrlDecode(input)).ToLower();

            foreach (var sqlKeyword in sqlKeywordsArray)
            {
                if (input.IndexOf(sqlKeyword) >= 0)
                {
                    input = input.Replace(sqlKeyword, string.Empty);
                }
            }
            return input;
        }

        private static string SqlDebug(string sql, IList<DbParameter> parameters)
        {
            //!request get 都会出问题
            string _url = "";
            try { _url = System.Web.HttpContext.Current.Request.Url.ToString(); }
            catch (Exception ex) { }

            //SlConfig.GetValue一个不存在的配置节就会报异常，按最小改动原则，不去更改GetValue<T>的逻辑
            bool sqlDebug = false;
            try { sqlDebug = U8Config.GetValue<bool>("SqlDebug"); }
            catch (Exception ex) { }

            if (sqlDebug)
            {
                StringBuilder sb = new StringBuilder("\r\n /** SqlDebug File:");
                sb.Append(SqlInvoker.SourceName);
                sb.AppendFormat(" Namespace:{0}", SqlInvoker.NameSpace);
                sb.AppendFormat(" Function:{0}", SqlInvoker.FunctionName);
                sb.AppendFormat(" Line:{0}", SqlInvoker.LineNum);
                sb.AppendFormat(" Request:{0}", _url.Contains("?") ? _url.Substring(0, _url.IndexOf("?")) : _url);
                if (parameters != null && parameters.Count > 0)
                {
                    sb.Append(" Parameters:");
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        string _value=parameters[i].Value==null?"":parameters[i].Value.ToString();
                        _value=_value.Length>=128?(_value.Substring(0,128)+"..."):_value;
                        if (i == parameters.Count - 1)
                        {
                            sb.AppendFormat("{0}:{1}", parameters[i].ParameterName, _value);
                        }
                        else
                        {
                            sb.AppendFormat("{0}:{1},", parameters[i].ParameterName, _value);
                        }
                    }
                }
                sb.Append("  **/ \r\n");
                sb.Append(sql);
                return sb.ToString();
            }
            return sql;
        }
    }
    /// <summary>
    /// 定位主调对象
    /// </summary>
    public static class SqlInvoker
    {
        /// <summary> 
        /// 取得当前源码的哪一行 
        /// </summary> 
        /// <returns></returns> 
        public static int LineNum
        {
            get
            {
                StackTrace st = new StackTrace(0, true);
                return st.GetFrame(3).GetFileLineNumber();
            }
        }

        /// <summary> 
        /// 取当前源码的源文件名 
        /// </summary> 
        /// <returns></returns> 
        public static string SourceName
        {
            get
            {
                StackTrace st = new StackTrace(0, true);
                return st.GetFrame(3).GetFileName();
            }
        }
        /// <summary>
        /// namespace
        /// </summary>
        public static string NameSpace
        {
            get
            {
                StackTrace st = new StackTrace(0, true);
                return st.GetFrame(3).GetMethod().DeclaringType.FullName;
            }
        }
        /// <summary>
        /// 函数名
        /// </summary>
        public static string FunctionName
        {
            get
            {
                StackTrace st = new StackTrace(0, true);
                return st.GetFrame(3).GetMethod().Name;
            }
        }
    }
}
