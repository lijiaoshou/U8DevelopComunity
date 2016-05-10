
namespace UFIDA.Framework.Data
{
    /// <summary>
    /// 字段描述
    /// </summary>
    public class UFIDAFieldDescription
    {
        private string name = string.Empty;
        /// <summary>
        /// 字段名
        /// </summary>
        public string Name
        {
            get
            {
                name = name.ToLower().StartsWith("id") ? "ID" + name.Substring(2) : name;
                name = name.ToLower().EndsWith("id") ? name.Substring(0, name.Length - 2) + "ID" : name;
                return UFIDAConvert.ToTitleCase(name);
            }
            set { name = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 是否可为Null
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
