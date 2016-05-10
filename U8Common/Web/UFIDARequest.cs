using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace UFIDA.Framework.Web
{
    /// <summary>
    /// 请求
    /// </summary>
    public static class UFIDARequest
    {
        private static int DefaultTimeout = 12000;//毫秒为单位
        private static Encoding DefaultCoding = Encoding.GetEncoding("gb2312");

        /// <summary>
        /// 用户IP
        /// </summary>
        public static string UserHostAddress
        {
            get
            {
                HttpContext current = HttpContext.Current;
                string ip = "";
                if (current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    ip = current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Trim();
                }
                if (ip.Length == 0)
                {
                    ip = current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (ip.IndexOf(",") > -1)
                {
                    string[] array = ip.Split(new char[] { ',' });
                    ip = array[array.Length - 1].Trim();
                }
                try
                {
                    IPAddress.Parse(ip);
                }
                catch
                {
                    ip = "0.0.0.0";
                }
                return ip;
            }
        }

        /// <summary>
        /// 获取主机端口
        /// </summary>
        public static string UserHostPort
        {
            get
            {
                string port = HttpContext.Current.Request.ServerVariables["HTTP_REMOTE_PORT"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_PORT"];
                return string.IsNullOrEmpty(port) ? string.Empty : port;
            }
        }

        /// <summary>
        /// 获取url里面的html
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="timeout"></param>
        /// <param name="httpAction"></param>
        /// <param name="postParameter"></param>
        /// <returns></returns>
        public static string GetHtml(string url, Encoding encoding = null, int timeout = 10000, UFIDAHttpActionType httpActionType = UFIDAHttpActionType.Get, string postParameter = "", string UserAgent = "")
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            try
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Proxy = null;
                request.Timeout = timeout;
                if (!string.IsNullOrEmpty(UserAgent))
                {
                    request.UserAgent = UserAgent;
                }
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                if (httpActionType == UFIDAHttpActionType.Post)
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    if (!string.IsNullOrEmpty(postParameter))
                    {
                        var postData = encoding.GetBytes(postParameter);
                        request.ContentLength = postData.Length;
                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(postData, 0, postData.Length);
                        }
                    }
                }
                else
                {
                    request.Method = "GET";
                }
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                        {
                            using (var streamReader = new StreamReader(stream, encoding))
                            {
                                var html = streamReader.ReadToEnd();
                                return html;
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        using (DeflateStream stream = new DeflateStream(response.GetResponseStream(),CompressionMode.Decompress))
                        {
                            using (var streamReader = new StreamReader(stream, encoding))
                            {
                                var html = streamReader.ReadToEnd();
                                return html;
                            }
                        }
                    }
                    else
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            using (var streamReader = new StreamReader(responseStream, encoding))
                            {
                                var html = streamReader.ReadToEnd();
                                return html;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return string.Empty;
        }

        #region 函数

        private static string Read(HttpWebRequest request, Encoding code)
        {
            string str = string.Empty;
            string error = request.Address.ToString();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                error = response.ContentType + ";" + response.ResponseUri.AbsoluteUri + ";";
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(Gzip(response), code);
                    str = reader.ReadToEnd();
                    reader.Close();
                }
                response.Close();
            }
            catch (Exception ex)
            {
                //File.FileLog.WriteLog("Com.Net.UrlRequest.Read(HttpWebRequest request, Encoding code)", ex.ToString() + ";response:" + error);
            }
            return str;
        }

        private static XmlDocument ReadXmlDocument(HttpWebRequest request)
        {
            XmlDocument doc = new XmlDocument();
            string error = request.Address.ToString();
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                error = response.ContentType + ";" + response.ResponseUri.AbsoluteUri + ";";
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    doc.Load(Gzip(response));
                }
                response.Close();
            }
            catch (Exception ex)
            {
                // File.FileLog.WriteLog("Com.Net.UrlRequest.ReadXmlDocument(HttpWebRequest request)", ex.ToString() + ";response:" + error);
            }
            return doc;
        }

        private static Stream Gzip(HttpWebResponse response)
        {
            Stream stream1 = null;
            string encode = response.ContentEncoding;
            if (encode.Contains("gzip"))
            {
                stream1 = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
            }
            else if (encode.Contains("deflate"))
            {
                stream1 = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
            }
            if (stream1 == null)
            {
                return response.GetResponseStream();
            }
            MemoryStream stream2 = new MemoryStream();
            int per = 0x800;
            int count = 0;
            byte[] buffer = new byte[0x800];
            do
            {
                count = stream1.Read(buffer, 0, per);
                stream2.Write(buffer, 0, count);
            }
            while (count > 0);
            stream2.Seek((long)0, SeekOrigin.Begin);
            return stream2;
        }

        private static HttpWebRequest LoadRequest(string url, int timeout)
        {
            return LoadRequest(url, null, timeout);
        }

        private static HttpWebRequest LoadRequest(string url, string PostContent, int timeout)
        {
            return LoadRequest(url, PostContent, timeout, DefaultCoding);
        }

        private static HttpWebRequest LoadRequest(string url, string PostContent, Encoding encoding)
        {
            return LoadRequest(url, PostContent, DefaultTimeout, encoding);
        }

        private static HttpWebRequest LoadRequest(string url, string PostContent, int timeout, Encoding encoding)
        {
            HttpWebRequest request = null;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                if (string.IsNullOrEmpty(PostContent))
                {
                    request.Timeout = timeout;
                    request.AllowAutoRedirect = true;
                }
                else
                {
                    byte[] bt = encoding.GetBytes(PostContent);
                    int len = bt.Length;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = "POST";
                    request.ContentLength = len;
                    Stream stream = request.GetRequestStream();
                    stream.Write(bt, 0, len);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //File.FileLog.WriteLog("Com.Net.UrlRequest.LoadRequest(string url, string PostContent, int timeout,Encoding encoding)", ex.ToString() + ";URL=" + url);
            }
            return request;
        }

        public static XmlDocument LoadXmlDocument(string url, string PostContent, int timeout, Encoding encoding)
        {
            XmlDocument doc = new XmlDocument();
            HttpWebRequest request = LoadRequest(url, PostContent, timeout, encoding);
            doc = ReadXmlDocument(request);
            return doc;
        }

        #endregion 函数
        #region

        public static byte[] GetBytesbyGet(string url)
        {
            return GetBytesbyPost(url, "");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters">可以为空</param>
        /// <returns></returns>
        public static byte[] GetBytesbyPost(string url, string parameters = "")
        {
            List<byte> btlist = new List<byte>();
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            if (!string.IsNullOrEmpty(parameters))
            {
                request.Timeout = 120000;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                //-------------------------------
                byte[] arrB = Encoding.UTF8.GetBytes(parameters);
                request.ContentLength = arrB.Length;
                using (Stream outStream = request.GetRequestStream())
                {
                    outStream.Write(arrB, 0, arrB.Length);
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        byte[] bytContent = new byte[1024];
                        int iCount = 1;
                        while (iCount > 0)
                        {
                            iCount = stream.Read(bytContent, 0, 1024);
                            for (int i = 0; i < iCount; i++)
                            {
                                btlist.Add(bytContent[i]);
                            }
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        byte[] bytContent = new byte[1024];
                        int iCount = 1;
                        while (iCount > 0)
                        {
                            iCount = stream.Read(bytContent, 0, 1024);
                            for (int i = 0; i < iCount; i++)
                            {
                                btlist.Add(bytContent[i]);
                            }
                        }
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        byte[] bytContent = new byte[1024];
                        int iCount = 1;
                        while (iCount > 0)
                        {
                            iCount = stream.Read(bytContent, 0, 1024);
                            for (int i = 0; i < iCount; i++)
                            {
                                btlist.Add(bytContent[i]);
                            }
                        }
                    }
                }
            }
            return btlist.ToArray();
        }

        #endregion
        #region 读取DataSet

        public static DataSet LoadDataSet(string url)
        {
            return LoadDataSet(url, null);
        }

        public static DataSet LoadDataSet(string url, string PostContent)
        {
            return LoadDataSet(url, null, DefaultTimeout);
        }

        public static DataSet LoadDataSet(string url, string PostContent, int timeout)
        {
            return LoadDataSet(url, PostContent, timeout, DefaultCoding);
        }

        public static DataSet LoadDataSet(string url, string PostContent, Encoding encoding)
        {
            return LoadDataSet(url, PostContent, DefaultTimeout, encoding);
        }

        public static DataSet LoadDataSet(string url, string PostContent, int timeout, Encoding encoding)
        {
            DataSet ds = new DataSet();
            XmlNodeReader xnr = new XmlNodeReader(LoadXmlDocument(url, PostContent, timeout, encoding));
            ds.ReadXml(xnr);
            return ds;
        }

        #endregion
        #region 读取内容

        public static string GetResponse(string url, string PostContent)
        {
            return GetResponse(url, PostContent, DefaultTimeout);
        }

        public static string GetResponse(string url, string PostContent, int timeout)
        {
            return GetResponse(url, PostContent, timeout, DefaultCoding);
        }

        public static string GetResponse(string url, string PostContent, Encoding encoding)
        {
            return GetResponse(url, PostContent, DefaultTimeout, encoding);
        }

        public static string GetResponse(string url, string PostContent, int timeout, Encoding encoding)
        {
            return Read(LoadRequest(url, PostContent, timeout), encoding);
        }

        #endregion
        #region 读取DataTable

        public static DataTable LoadDataTable(string url)
        {
            return LoadDataTable(url, "");
        }

        public static DataTable LoadDataTable(string url, string tablename)
        {
            return LoadDataTable(url, tablename, null);
        }

        public static DataTable LoadDataTable(string url, string tablename, string PostContent)
        {
            return LoadDataTable(url, tablename, PostContent, DefaultTimeout);
        }

        public static DataTable LoadDataTable(string url, string tablename, string PostContent, Encoding encoding)
        {
            return LoadDataTable(url, tablename, PostContent, DefaultTimeout, encoding);
        }

        public static DataTable LoadDataTable(string url, string tablename, string PostContent, int timeout)
        {
            return LoadDataTable(url, tablename, PostContent, timeout, DefaultCoding);
        }

        public static DataTable LoadDataTable(string url, string tablename, string PostContent, int timeout, Encoding encoding)
        {
            DataSet ds = LoadDataSet(url, PostContent, timeout, encoding);
            DataTable dt = tablename == "" ? ds.Tables[0] : ds.Tables[tablename];
            if (dt != null)
            {
                DataTable result = dt.Copy();
                ds.Clear();
                return result;
            }
            else
            {
                return new DataTable();
            }
        }

        #endregion
    }
}