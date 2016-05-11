using U8.Framework.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace U8.Framework.Svn
{
    /// <summary>
    /// SVN每日统计
    /// </summary>
    public class U8SvnManager
    {
        /// <summary>
        /// 本地路径,用于存放从svn取得的日志
        /// </summary>
        private string svnLogFullPath = U8AppContext.Directory + "log.xml";
        /// <summary>
        /// 是否释放资源
        /// </summary>
        private bool isDisposed;
        /// <summary>
        /// 进程定义
        /// </summary>
        private Process p = null;
        /// <summary>
        /// 文件列表List对象
        /// </summary>
        public static List<string> list = null;
        /// <summary>
        /// 当天变更
        /// </summary>
        public StringBuilder changes = new StringBuilder("----------昨日变更列表----------<br/>\r\n");
        /// <summary>
        /// 当天锁定
        /// </summary>
        public StringBuilder locks = new StringBuilder("----------昨日锁定列表----------<br/>\r\n");
        /// <summary>
        /// 递归获取文件列表
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="subPath"></param>
        public bool CallCmd(string path,string filePath, string userName, string passWord, string subPath)
        {
            bool flag = false;
            if (p==null)
            {
                p = new Process();
                //设定程序名
                p.StartInfo.FileName = "cmd.exe";
                //关闭Shell的使用
                p.StartInfo.UseShellExecute = false;
                //重定向标准输入
                p.StartInfo.RedirectStandardInput = true;
                //重定向标准输出
                p.StartInfo.RedirectStandardOutput = true;
                //重定向错误输出
                p.StartInfo.RedirectStandardError = true;
                //设置不显示窗口
                p.StartInfo.CreateNoWindow = true;
            }
            p.Start();
            if (File.Exists(svnLogFullPath))
            {
                File.Delete(svnLogFullPath);
            }
            //p.StandardInput.WriteLine("svn log " + path + subPath + " --username " + userName + " --password " + passWord + " -v -r{" + DateTime.Now.AddDays(-1).AddHours(-16).ToUniversalTime().ToString("yyyy-MM-dd") + "}:{" + DateTime.Now.AddHours(-16).ToUniversalTime().ToString("yyyy-MM-dd") + "} --xml >>" + Directory.GetCurrentDirectory() + "\\log.xml");//这里就可以输入你自己的命令
            p.StandardInput.WriteLine("svn log " + path + subPath + " --username " + userName + " --password " + passWord + " -v --xml >>" + svnLogFullPath);//这里就可以输入你自己的命令
            //p.StandardInput.WriteLine("exit");
            XmlDocument mydoc = new XmlDocument();
            System.Threading.Thread.Sleep(1000*60*5);
            mydoc.Load(svnLogFullPath);
            XDocument doc = XDocument.Parse(mydoc.InnerXml);
            mydoc = null;
            List<XElement> lstLog = doc.Element("log").Elements("logentry").ToList();
            List<dynamic> results = new List<dynamic>();

            foreach (XElement log in lstLog)
            {
                if (Convert.ToDateTime(log.Element("date").Value)>DateTime.Now.AddDays(-1))
                {
                    List<XElement> lstPath = log.Element("paths").Elements("path").Take(100).ToList();
                    foreach (XElement ph in lstPath)
                    {
                        try
                        {
                            results.Add(new { Name = log.Element("author").Value, Path = ph.Value, Date = Convert.ToDateTime(log.Element("date").Value) });
                        }
                        catch { 
                        }
                        //changes.Append("用户："+log.Element("author").Value+"^");
                        //changes.Append("文件：" + ph.Value+"^" );
                        //changes.Append("时间：" + log.Element("date").Value + "^");
                        //changes.Append(";<br/>\r\n");
                    }
                    
                }
            }
            results.OrderByDescending(h => h.Date).ToList().ForEach(h => changes.Append("用户：" + h.Name + "^文件：" + h.Path + "^时间：" + h.Date + ";<br/>\r\n"));
            p.StandardInput.WriteLine("svnadmin lslocks " + filePath);//这里就可以输入你自己的命令
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string line = "";
            string pathTemp = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if(line.Contains("Path")){
                    pathTemp = line.Replace("Path", "文件");
                }
                if (line.Contains("Owner"))
                {
                    locks.Append(line.Replace("Owner", "用户") + "^" + pathTemp+"^");
                }
                if (line.Contains("Created"))
                {
                    try
                    {
                        locks.Append("时间:" + Convert.ToDateTime(line.Replace("Created:", "").Trim()) + "<br/>\r\n");
                    }
                    catch {
                        locks.Append(line.Replace("Created:", "时间") + "<br/>\r\n");
                    }
                    
                }
            }

            flag = true;
            return flag;
        }
        


        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isDispose">是否释放</param>
        private void Dispose(bool isDispose)
        {
            if (isDisposed)
            {
                return;
            }
            if (isDispose)
            {
                Close();
            }
            isDisposed = true;
        }

        /// <summary>
        /// 关闭，关闭之后将无法再访问
        /// </summary>
        public void Close()
        {
            list = null;
            isDisposed = true;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~U8SvnManager()
        {
            Dispose(false);
        }
    }
}
