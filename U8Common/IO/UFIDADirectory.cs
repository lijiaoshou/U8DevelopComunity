using System.IO;

namespace UFIDA.Framework.IO
{
    /// <summary>
    /// 目录
    /// </summary>
    public static class UFIDADirectory
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="directory">目录</param>
        public static void DeleteFiles(string directory)
        {
            try
            {
                var files = Directory.GetFiles(directory);
                if (files != null && files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        try
                        {
                            File.Delete(files[i]);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
    }
}
