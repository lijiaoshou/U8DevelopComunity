
namespace U8.Framework
{
    /// <summary>
    /// 字符串
    /// </summary>
    public static class U8String
    {
        /// <summary>
        /// 截取左半部分
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="length">长度</param>
        /// <param name="ex">扩展字符</param>
        /// <returns>结果</returns>
        public static string Left(string input, int length, string ex = "...")
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            if (input.Length > length)
            {
                return input.Substring(0, length) + ex;
            }
            else
            {
                return input;
            }
        }

        ///// <summary>
        ///// 获取哈希值（32位）
        ///// </summary>
        ///// <param name="input">输入项</param>
        ///// <returns>结果</returns>
        //public static unsafe int GetHashCodeFor32(string input)
        //{
        //    fixed (char* str = input.ToCharArray())
        //    {
        //        char* chPtr = str;
        //        int num = 0x15051505;
        //        int num2 = num;
        //        int* numPtr = (int*)chPtr;
        //        int length = input.Length;
        //        while (length > 2)
        //        {
        //            num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
        //            num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ numPtr[1];
        //            numPtr += 2;
        //            length -= 4;
        //        }
        //        if (length > 0)
        //        {
        //            num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
        //        }
        //        return (num + (num2 * 0x5d588b65));
        //    }
        //}

        ///// <summary>
        ///// 获取哈希值（64位）
        ///// </summary>
        ///// <param name="input">输入项</param>
        ///// <returns>结果</returns>
        //public static unsafe int GetHashCodeFor64(string input)
        //{
        //    fixed (char* str = input.ToCharArray())
        //    {
        //        int num3;
        //        char* chPtr = str;
        //        int num = 0x1505;
        //        int num2 = num;
        //        for (char* chPtr2 = chPtr; (num3 = chPtr2[0]) != '\0'; chPtr2 += 2)
        //        {
        //            num = ((num << 5) + num) ^ num3;
        //            num3 = chPtr2[1];
        //            if (num3 == 0)
        //            {
        //                break;
        //            }
        //            num2 = ((num2 << 5) + num2) ^ num3;
        //        }
        //        return (num + (num2 * 0x5d588b65));
        //    }

        //}

        /// <summary>
        /// 是否全为空（只要有一个不为空，则返回false）
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static bool IsNullOrEmptyAll(params string[] input)
        {
            foreach (var one in input)
            {
                if (!string.IsNullOrEmpty(one))
                {
                    return false; 
                }
            }

            return true;
        }

        /// <summary>
        /// 是否有一个为空（只要有一个为空，则返回true）
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static bool IsNullOrEmptyAny(params string[] input)
        {
            foreach (var one in input)
            {
                if (string.IsNullOrEmpty(one))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否全为空（只要有一个不为空，则返回false）
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static bool IsNullOrWhiteSpaceAll(params string[] input)
        {
            foreach (var one in input)
            {
                if (!string.IsNullOrWhiteSpace(one))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否有一个为空（只要有一个为空，则返回true）
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns>结果</returns>
        public static bool IsNullOrWhiteSpaceAny(params string[] input)
        {
            foreach (var one in input)
            {
                if (string.IsNullOrWhiteSpace(one))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
