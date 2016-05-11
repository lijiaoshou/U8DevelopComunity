using System.Xml;
using System.Xml.Linq;

namespace U8.Framework.Xml
{
    /// <summary>
    /// Xml文档
    /// </summary>
    public static class U8XmlDocument
    {
        /// <summary>
        /// 查找结点
        /// </summary>
        /// <param name="xml">文档</param>
        /// <param name="path">路径</param>
        /// <returns>结果</returns>
        public static XmlNode Select(string xml, string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            return xmlDocument.SelectSingleNode(path);
        }

        /// <summary>
        /// 查找结点的值
        /// </summary>
        /// <param name="doc">xml文档</param>
        /// <param name="node">节点名称</param>
        /// <returns>节点值</returns>
        public static string GetValue(XDocument doc, string node)
        {
            return doc.Element(node) == null ? string.Empty : doc.Element(node).Value;
        }

        /// <summary>
        /// 查找结点的值
        /// </summary>
        /// <param name="element">xml文档</param>
        /// <param name="node">节点名称</param>
        /// <returns>节点值</returns>
        public static string GetValue(XElement element, string node)
        {
            return element.Element(node) == null ? string.Empty : element.Element(node).Value;
        }
    }
}
