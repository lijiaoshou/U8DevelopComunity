using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UFIDA.Framework.IO;
using System.IO;

namespace UFIDA.Framework.Drawing
{
    /// <summary>
    /// 图片相似度比较
    /// </summary>
    public static class UFIDAImageMatcher
    {
        #region AverageHash 平均哈希算法
        /// <summary>  
        /// 获取图片的Hashcode  
        /// </summary>  
        /// <param name="path">本地文件路径</param>  
        /// <returns>64位图片指纹</returns>  
        public static string GetImgHashCode(Image image, int width, int height)
        {
            //  第一步  
            //  将图片缩小到8x8的尺寸，总共64个像素。这一步的作用是去除图片的细节，  
            //  只保留结构、明暗等基本信息，摒弃不同尺寸、比例带来的图片差异。
            int[] pixels = { };
            using (Image thumbnailImage = GetThumbnailImage(image, width, height))
            {
                using (Bitmap bmp = new Bitmap(thumbnailImage))
                {
                    pixels = new int[width * height];
                    //  第二步  
                    //  将缩小后的图片，转为64级灰度。也就是说，所有像素点总共只有64种颜色。  
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            Color color = bmp.GetPixel(i, j);
                            pixels[i * height + j] = RGBToGray(color.ToArgb());
                        }
                    }
                }
            }
            //  第三步  
            //  计算所有64个像素的灰度平均值。  
            int avgPixel = Average(pixels);

            //  第四步  
            //  将每个像素的灰度，与平均值进行比较。大于或等于平均值，记为1；小于平均值，记为0。  
            int[] comps = new int[width * height];
            for (int i = 0; i < comps.Length; i++)
            {
                if (pixels[i] >= avgPixel)
                {
                    comps[i] = 1;
                }
                else
                {
                    comps[i] = 0;
                }
            }
            //  第五步  
            //  将上一步的比较结果，组合在一起，就构成了一个64位的整数，这就是这张图片的指纹。
            //  组合的次序并不重要，只要保证所有图片都采用同样次序就行了。  
            StringBuilder hashCode = new StringBuilder();
            for (int i = 0; i < comps.Length; i += 4)
            {
                int result = comps[i] * (int)Math.Pow(2, 3) + comps[i + 1] * (int)Math.Pow(2, 2) + comps[i + 2] * (int)Math.Pow(2, 1) + comps[i + 2];
                hashCode.Append(BinaryToHex(result));
            }

            return hashCode.ToString();
        }

        /// <summary>
        /// 图片压缩
        /// </summary>
        /// <param name="sourceImage">原图</param>
        /// <param name="smallWidth">压缩图宽度（px）</param>
        /// <param name="smallHeight">压缩图高度</param>
        /// <returns></returns>
        public static Image GetThumbnailImage(Image sourceImage, int smallWidth, int smallHeight)
        {
            //原图宽度和高度    
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            //新建一个图板,以指定宽高压缩大小绘制原图    
            System.Drawing.Image image = new System.Drawing.Bitmap(smallWidth, smallHeight);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.Black);
                g.DrawImage(
                sourceImage,
                new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                new System.Drawing.Rectangle(0, 0, width, height),
                System.Drawing.GraphicsUnit.Pixel
                );
            }
            return image;
        }

        /// <summary>
        /// 根据"汉明距离"（Hamming distance）计算相似度。  
        /// </summary>
        /// <param name="keyCode">字典中的哈希值</param>
        /// <param name="hashCode">待对比图片哈希值</param>
        /// <returns>相似度百分比</returns>
        public static double GetSimilarity(string keyCode, String hashCode)
        {
            double same = 0.0000;
            int len = keyCode.Length;

            for (int i = 0; i < len; i++)
            {
                if (keyCode[i] == hashCode[i])
                {
                    same++;
                }
            }
            return same * Math.Round((1 * 100 / (double)len));
        }

        /// <summary>  
        /// 转为64级灰度  
        /// </summary>  
        /// <param name="pixels"></param>  
        /// <returns></returns>  
        private static int RGBToGray(int pixels)
        {
            int _red = (pixels >> 16) & 0xFF;
            int _green = (pixels >> 8) & 0xFF;
            int _blue = (pixels) & 0xFF;
            return (int)(0.3 * _red + 0.59 * _green + 0.11 * _blue);
        }

        /// <summary>  
        /// 计算平均值  
        /// </summary>  
        /// <param name="pixels"></param>  
        /// <returns></returns>  
        private static int Average(int[] pixels)
        {
            float m = 0;
            for (int i = 0; i < pixels.Length; ++i)
            {
                m += pixels[i];
            }
            m = m / pixels.Length;
            return (int)m;
        }

        /// <summary>
        /// 转化为16进制
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        private static char BinaryToHex(int binary)
        {
            char ch = ' ';
            switch (binary)
            {
                case 0:
                    ch = '0';
                    break;
                case 1:
                    ch = '1';
                    break;
                case 2:
                    ch = '2';
                    break;
                case 3:
                    ch = '3';
                    break;
                case 4:
                    ch = '4';
                    break;
                case 5:
                    ch = '5';
                    break;
                case 6:
                    ch = '6';
                    break;
                case 7:
                    ch = '7';
                    break;
                case 8:
                    ch = '8';
                    break;
                case 9:
                    ch = '9';
                    break;
                case 10:
                    ch = 'a';
                    break;
                case 11:
                    ch = 'b';
                    break;
                case 12:
                    ch = 'c';
                    break;
                case 13:
                    ch = 'd';
                    break;
                case 14:
                    ch = 'e';
                    break;
                case 15:
                    ch = 'f';
                    break;
                default:
                    ch = ' ';
                    break;
            }
            return ch;
        }

        #endregion
    }
}
