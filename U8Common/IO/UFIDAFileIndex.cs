using UFIDA.Framework.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.IO
{
    /// <summary>
    /// 文件索引
    /// </summary>
    public static class UFIDAFileIndex
    {
        private static string GenerateFilePath(string directory, string key, string fileName = "data.txt")
        {
            return directory.TrimEnd('\\') + "\\" + key.ToCharArray().Select(item => item.ToString()).Aggregate((result, item) => { return result + "\\" + item; }) + "\\" + fileName;
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="directory">目录</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="fileName">文件名</param>
        /// <param name="encoding">编码</param>
        public static void Write(string directory, string key, string value, string fileName = "data.txt", Encoding encoding = null)
        {
            string filePath = GenerateFilePath(directory, key, fileName);

            UFIDAFile.Write(filePath, value, false, encoding);
        }

        /// <summary>
        /// 读
        /// </summary>
        /// <param name="directory">目录</param>
        /// <param name="key">键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="encoding">编码</param>
        /// <returns>内容</returns>
        public static string Read(string directory, string key, string fileName = "data.txt", Encoding encoding = null)
        {
            string filePath = GenerateFilePath(directory, key, fileName);

            encoding = encoding ?? UFIDAEncoding.Default;

            return File.ReadAllText(filePath, encoding);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="directory">目录</param>
        /// <param name="key">键</param>
        /// <param name="fileName">文件名</param>
        /// <returns>结果</returns>
        public static bool Exists(string directory, string key, string fileName = "data.txt")
        {
            string filePath = GenerateFilePath(directory, key, fileName);

            return File.Exists(filePath);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="directory">目录</param>
        /// <param name="key">键</param>
        /// <param name="fileName">文件名</param>
        public static void Delete(string directory, string key, string fileName = "data.txt")
        {
            string filePath = GenerateFilePath(directory, key, fileName);

            File.Delete(filePath);
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="directory">目录</param>
        public static void Clear(string directory)
        {
            Directory.Delete(directory, true);
        }
    }
}
