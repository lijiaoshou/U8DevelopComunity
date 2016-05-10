
namespace UFIDA.Framework.Data
{
    /// <summary>
    /// 数据库类型映射
    /// </summary>
    public static class UFIDADbTypeMap
    {
        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>.NET类型</returns>
        public static string Map(string dbType)
        {
            switch (dbType)
            {
                case "bigint":
                    return "long";
                case "int":
                case "tinyint":
                    return "int";
                case "bit":
                    return "byte";
                case "smalldatetime":
                case "date":
                case "datetime":
                    return "DateTime";
                case "decimal":
                case "float":
                    return "decimal";
                default:
                    return "string";
            }
        }
    }
}
