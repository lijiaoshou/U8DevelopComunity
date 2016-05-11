using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace U8.Framework.Net
{
    /// <summary>
    /// IP区域
    /// </summary>
    public class U8IPRegion
    {
        /// <summary>
        /// 所有
        /// </summary>
        public static readonly Dictionary<int, U8IPRegion> All = new Dictionary<int, U8IPRegion>();

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static U8IPRegion()
        {
            using (MemoryStream memoryStream = new MemoryStream(U8Resource.IP))
            {
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    using (StreamReader streamReader = new StreamReader(gzipStream))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var line = streamReader.ReadLine();
                            var fileds = line.Split('^');
                            var ipRegion = new U8IPRegion() 
                            {
                                ID = int.Parse(fileds[0]),
                                StartValue = long.Parse(fileds[1]),
                                EndValue = long.Parse(fileds[2]),
                                Country = fileds[3],
                                Province = fileds[4],
                                City = fileds[5],
                                StartIP = fileds[6],
                                EndIP = fileds[7]
                            };
                            All.Add(ipRegion.ID, ipRegion);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 开始值
        /// </summary>
        public long StartValue { get; set; }

        /// <summary>
        /// 结束值
        /// </summary>
        public long EndValue { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 开始IP
        /// </summary>
        public string StartIP { get; set; }

        /// <summary>
        /// 结束IP
        /// </summary>
        public string EndIP { get; set; }

        /// <summary>
        /// 同过IP的数字找到一个包含该IP数字的区间
        /// </summary>
        /// <param name="ipNumber">IP数字</param>
        /// <returns>结果</returns>
        private static int FindID(long ipNumber)
        {
            if (ipNumber <= 0)
            {
                return 0;
            }
            int firstID = 1;
            int lastID = All.Count;
            int resultID = -1;
            int middleID = 0;

            while (firstID <= lastID)
            {
                middleID = (firstID + lastID) / 2;

                var current = All[middleID];

                if (ipNumber > current.EndValue)
                {
                    firstID = middleID + 1;
                }
                else if (ipNumber < current.StartValue)
                {
                    lastID = middleID - 1;
                }
                else
                {
                    resultID = middleID;
                    break;
                }
            }
            if (resultID > 0)
            {
                return resultID;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 同过IP的数字找到一个包含该IP数字的区间
        /// </summary>
        /// <param name="ipNumber">IP数字</param>
        /// <returns>结果</returns>
        public static U8IPRegion Find(long ipNumber)
        {
            try
            {
                return All[FindID(ipNumber)];
            }
            catch { }
            return null;
        }
    }
}
