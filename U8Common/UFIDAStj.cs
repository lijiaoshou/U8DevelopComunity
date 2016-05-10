using UFIDA.Framework.Text;

namespace UFIDA.Framework
{
    /// <summary>
    /// 安全传输Json（Security Transport Json，专门用于数据在不同的系统之间传递，同时提供Java、JavaScript、PHP、C#语言版本）
    /// </summary>
    public static class UFIDAStj
    {
        /// <summary>
        /// 明文转换为密文（不区分大小写）
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string ToCryptograph(string input)
        {
            return UFIDABase64.ToBase64String(input);
        }

        /// <summary>
        /// 密文转换为明文（不区分大小写）
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string ToText(string input)
        {
            return UFIDABase64.FromBase64String(input);
        }
    }
}
