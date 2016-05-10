using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace UFIDA.Framework.IO
{
    /// <summary>
    /// GZip
    /// </summary>
    public static class UFIDAGZip
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string Compress(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                byte[] source = Encoding.UTF8.GetBytes(input);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (GZipStream gzs = new GZipStream(memoryStream, CompressionMode.Compress, true))
                    {
                        gzs.Write(source, 0, source.Length);
                    }

                    memoryStream.Position = 0;

                    byte[] target = new byte[memoryStream.Length];
                    memoryStream.Read(target, 0, target.Length);

                    byte[] finalBuffer = new byte[target.Length + 4];
                    Buffer.BlockCopy(target, 0, finalBuffer, 4, target.Length);
                    Buffer.BlockCopy(BitConverter.GetBytes(source.Length), 0, finalBuffer, 0, 4);

                    result = System.Convert.ToBase64String(finalBuffer);
                }
            }

            return result;
        }

        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static string Decompress(string input)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                byte[] source = System.Convert.FromBase64String(input);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    int length = BitConverter.ToInt32(source, 0);
                    memoryStream.Write(source, 4, source.Length - 4);
                    memoryStream.Position = 0;
                    byte[] decmpBytes = new byte[length];
                    using (GZipStream gzs = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gzs.Read(decmpBytes, 0, length);
                    }

                    result = Encoding.UTF8.GetString(decmpBytes);
                }
            }

            return result;
        }

        /// <summary>
        /// byte数组GZip压缩
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                GZipStream Compress = new GZipStream(ms, CompressionMode.Compress);
                Compress.Write(bytes, 0, bytes.Length);
                Compress.Close();
                return ms.ToArray();

            }
        }

        /// <summary>
        /// byte数组GZip解压缩
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Decompress(Byte[] bytes)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress);
                    Decompress.CopyTo(tempMs);
                    Decompress.Close();
                    return tempMs.ToArray();
                }
            }
        }
    }
}
