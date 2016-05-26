using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace U8DevelopComunity.Common
{

    public static class Verify
    {
        /// <summary>
        /// Cookie加密
        /// </summary>
        /// <param name="username">用户或cid</param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public static string Cookie_Encrypt(string username, string userid)
        {
            int length = username.Length;
            string strEncrypt = username.Substring(0, length - 1) + "仝" + userid + username.Substring(length - 1);
            string strKey = "uensocty";
            return Encrypt(strEncrypt, strKey);
        }

        /// <summary>
        /// Cookie解密
        /// </summary>
        /// <param name="strDecrypt">需要解密的内容</param>
        /// <returns></returns>
        public static string Cookie_Decrypt(string strDecrypt)
        {
            string strKey = "uensocty";
            string strContent = Decrypt(strDecrypt, strKey);
            int position = strContent.IndexOf("仝");
            if (position == -1)
            {
                return "";
            }
            else
            {
                string username = strContent.Substring(0, position) + strContent.Substring(strContent.Length - 1);
                string userid = strContent.Substring(position + 1, strContent.Length - position - 2);
                return username + userid;
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">解密内容</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt">需加密内容</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            //原来使用的UTF8编码，我改成Unicode编码了，不行  
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }


    }
}