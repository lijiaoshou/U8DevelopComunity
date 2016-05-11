using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Framework.Business
{
    /// <summary>
    /// 搜索定义
    /// </summary>
    public class U8SearchDefine
    {
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static U8SearchDefine()
        {
            #region 初始化搜索定义
            Settings.Add("baidu.mobi", new U8SearchDefine() { Domain = "baidu.mobi", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(kw)" });
            Settings.Add("image.baidu.com", new U8SearchDefine() { Domain = "image.baidu.com", Encoding = Encoding.GetEncoding("gbk"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(q)" });
            Settings.Add("m.baidu.com", new U8SearchDefine() { Domain = "m.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m1.baidu.com", new U8SearchDefine() { Domain = "m1.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m2.baidu.com", new U8SearchDefine() { Domain = "m2.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m3.baidu.com", new U8SearchDefine() { Domain = "m3.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m4.baidu.com", new U8SearchDefine() { Domain = "m4.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m5.baidu.com", new U8SearchDefine() { Domain = "m5.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m6.baidu.com", new U8SearchDefine() { Domain = "m6.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m7.baidu.com", new U8SearchDefine() { Domain = "m7.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m8.baidu.com", new U8SearchDefine() { Domain = "m8.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m9.baidu.com", new U8SearchDefine() { Domain = "m9.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("3g.baidu.com", new U8SearchDefine() { Domain = "3g.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("wap.baidu.com", new U8SearchDefine() { Domain = "wap.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("news.baidu.com", new U8SearchDefine() { Domain = "news.baidu.com", Encoding = Encoding.GetEncoding("gbk"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(q)" });
            Settings.Add("www.baidu.com", new U8SearchDefine() { Domain = "www.baidu.com", Encoding = Encoding.GetEncoding("gbk"), GroupType = U8SearchGroupType.Baidu, KeyParameters = "(word),(wd),(q)" });
            
            Settings.Add("groups.google.com", new U8SearchDefine() { Domain = "groups.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com", new U8SearchDefine() { Domain = "images.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com.hk", new U8SearchDefine() { Domain = "images.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com.my", new U8SearchDefine() { Domain = "images.google.com.my", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com.tw", new U8SearchDefine() { Domain = "images.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("ipv6.google.com", new U8SearchDefine() { Domain = "ipv6.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("ipv6.google.com.hk", new U8SearchDefine() { Domain = "ipv6.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("mail.google.com", new U8SearchDefine() { Domain = "mail.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("maps.google.com", new U8SearchDefine() { Domain = "maps.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("maps.google.com.hk", new U8SearchDefine() { Domain = "maps.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("maps.google.com.tw", new U8SearchDefine() { Domain = "maps.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com", new U8SearchDefine() { Domain = "news.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.au", new U8SearchDefine() { Domain = "news.google.com.au", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.hk", new U8SearchDefine() { Domain = "news.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.my", new U8SearchDefine() { Domain = "news.google.com.my", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.sg", new U8SearchDefine() { Domain = "news.google.com.sg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.tw", new U8SearchDefine() { Domain = "news.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("plus.url.google.com", new U8SearchDefine() { Domain = "plus.url.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ae", new U8SearchDefine() { Domain = "www.google.ae", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.am", new U8SearchDefine() { Domain = "www.google.am", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.as", new U8SearchDefine() { Domain = "www.google.as", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.at", new U8SearchDefine() { Domain = "www.google.at", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.az", new U8SearchDefine() { Domain = "www.google.az", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ba", new U8SearchDefine() { Domain = "www.google.ba", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.be", new U8SearchDefine() { Domain = "www.google.be", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.bg", new U8SearchDefine() { Domain = "www.google.bg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.bs", new U8SearchDefine() { Domain = "www.google.bs", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ca", new U8SearchDefine() { Domain = "www.google.ca", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cat", new U8SearchDefine() { Domain = "www.google.cat", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ch", new U8SearchDefine() { Domain = "www.google.ch", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cl", new U8SearchDefine() { Domain = "www.google.cl", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cm", new U8SearchDefine() { Domain = "www.google.cm", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cn", new U8SearchDefine() { Domain = "www.google.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.bw", new U8SearchDefine() { Domain = "www.google.co.bw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.cr", new U8SearchDefine() { Domain = "www.google.co.cr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.id", new U8SearchDefine() { Domain = "www.google.co.id", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.il", new U8SearchDefine() { Domain = "www.google.co.il", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.in", new U8SearchDefine() { Domain = "www.google.co.in", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.jp", new U8SearchDefine() { Domain = "www.google.co.jp", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.ke", new U8SearchDefine() { Domain = "www.google.co.ke", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.kr", new U8SearchDefine() { Domain = "www.google.co.kr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.ma", new U8SearchDefine() { Domain = "www.google.co.ma", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.nz", new U8SearchDefine() { Domain = "www.google.co.nz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.th", new U8SearchDefine() { Domain = "www.google.co.th", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.tz", new U8SearchDefine() { Domain = "www.google.co.tz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.uk", new U8SearchDefine() { Domain = "www.google.co.uk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.uz", new U8SearchDefine() { Domain = "www.google.co.uz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.ve", new U8SearchDefine() { Domain = "www.google.co.ve", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.za", new U8SearchDefine() { Domain = "www.google.co.za", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.zw", new U8SearchDefine() { Domain = "www.google.co.zw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com", new U8SearchDefine() { Domain = "www.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ag", new U8SearchDefine() { Domain = "www.google.com.ag", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ai", new U8SearchDefine() { Domain = "www.google.com.ai", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ar", new U8SearchDefine() { Domain = "www.google.com.ar", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.au", new U8SearchDefine() { Domain = "www.google.com.au", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bd", new U8SearchDefine() { Domain = "www.google.com.bd", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bn", new U8SearchDefine() { Domain = "www.google.com.bn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bo", new U8SearchDefine() { Domain = "www.google.com.bo", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.br", new U8SearchDefine() { Domain = "www.google.com.br", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bz", new U8SearchDefine() { Domain = "www.google.com.bz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.co", new U8SearchDefine() { Domain = "www.google.com.co", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.cy", new U8SearchDefine() { Domain = "www.google.com.cy", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.do", new U8SearchDefine() { Domain = "www.google.com.do", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ec", new U8SearchDefine() { Domain = "www.google.com.ec", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.eg", new U8SearchDefine() { Domain = "www.google.com.eg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.et", new U8SearchDefine() { Domain = "www.google.com.et", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.fj", new U8SearchDefine() { Domain = "www.google.com.fj", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.gh", new U8SearchDefine() { Domain = "www.google.com.gh", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.gt", new U8SearchDefine() { Domain = "www.google.com.gt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.hk", new U8SearchDefine() { Domain = "www.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.hk.", new U8SearchDefine() { Domain = "www.google.com.hk.", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.jm", new U8SearchDefine() { Domain = "www.google.com.jm", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.kh", new U8SearchDefine() { Domain = "www.google.com.kh", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.kw", new U8SearchDefine() { Domain = "www.google.com.kw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.lb", new U8SearchDefine() { Domain = "www.google.com.lb", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.mt", new U8SearchDefine() { Domain = "www.google.com.mt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.mx", new U8SearchDefine() { Domain = "www.google.com.mx", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.my", new U8SearchDefine() { Domain = "www.google.com.my", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.na", new U8SearchDefine() { Domain = "www.google.com.na", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ng", new U8SearchDefine() { Domain = "www.google.com.ng", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.np", new U8SearchDefine() { Domain = "www.google.com.np", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.om", new U8SearchDefine() { Domain = "www.google.com.om", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pa", new U8SearchDefine() { Domain = "www.google.com.pa", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pe", new U8SearchDefine() { Domain = "www.google.com.pe", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ph", new U8SearchDefine() { Domain = "www.google.com.ph", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pk", new U8SearchDefine() { Domain = "www.google.com.pk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pr", new U8SearchDefine() { Domain = "www.google.com.pr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.qa", new U8SearchDefine() { Domain = "www.google.com.qa", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.sa", new U8SearchDefine() { Domain = "www.google.com.sa", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.sb", new U8SearchDefine() { Domain = "www.google.com.sb", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.sg", new U8SearchDefine() { Domain = "www.google.com.sg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.tn", new U8SearchDefine() { Domain = "www.google.com.tn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.tr", new U8SearchDefine() { Domain = "www.google.com.tr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.tw", new U8SearchDefine() { Domain = "www.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ua", new U8SearchDefine() { Domain = "www.google.com.ua", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.uy", new U8SearchDefine() { Domain = "www.google.com.uy", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.vc", new U8SearchDefine() { Domain = "www.google.com.vc", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.vn", new U8SearchDefine() { Domain = "www.google.com.vn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.combj-ibook.cn", new U8SearchDefine() { Domain = "www.google.combj-ibook.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cz", new U8SearchDefine() { Domain = "www.google.cz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.de", new U8SearchDefine() { Domain = "www.google.de", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.dk", new U8SearchDefine() { Domain = "www.google.dk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ee", new U8SearchDefine() { Domain = "www.google.ee", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.es", new U8SearchDefine() { Domain = "www.google.es", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.fi", new U8SearchDefine() { Domain = "www.google.fi", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.fm", new U8SearchDefine() { Domain = "www.google.fm", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.fr", new U8SearchDefine() { Domain = "www.google.fr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ge", new U8SearchDefine() { Domain = "www.google.ge", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.gr", new U8SearchDefine() { Domain = "www.google.gr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.hn", new U8SearchDefine() { Domain = "www.google.hn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ht", new U8SearchDefine() { Domain = "www.google.ht", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.hu", new U8SearchDefine() { Domain = "www.google.hu", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ie", new U8SearchDefine() { Domain = "www.google.ie", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.iq", new U8SearchDefine() { Domain = "www.google.iq", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.is", new U8SearchDefine() { Domain = "www.google.is", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.it", new U8SearchDefine() { Domain = "www.google.it", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.jo", new U8SearchDefine() { Domain = "www.google.jo", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.kg", new U8SearchDefine() { Domain = "www.google.kg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.kz", new U8SearchDefine() { Domain = "www.google.kz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.lt", new U8SearchDefine() { Domain = "www.google.lt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.lu", new U8SearchDefine() { Domain = "www.google.lu", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.lv", new U8SearchDefine() { Domain = "www.google.lv", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.md", new U8SearchDefine() { Domain = "www.google.md", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.mn", new U8SearchDefine() { Domain = "www.google.mn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.mu", new U8SearchDefine() { Domain = "www.google.mu", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.nl", new U8SearchDefine() { Domain = "www.google.nl", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.no", new U8SearchDefine() { Domain = "www.google.no", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.nr", new U8SearchDefine() { Domain = "www.google.nr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.pl", new U8SearchDefine() { Domain = "www.google.pl", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.pt", new U8SearchDefine() { Domain = "www.google.pt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ro", new U8SearchDefine() { Domain = "www.google.ro", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ru", new U8SearchDefine() { Domain = "www.google.ru", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.se", new U8SearchDefine() { Domain = "www.google.se", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.sk", new U8SearchDefine() { Domain = "www.google.sk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.tn", new U8SearchDefine() { Domain = "www.google.tn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ws", new U8SearchDefine() { Domain = "www.google.ws", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Google, KeyParameters = "(q)" });
            
            Settings.Add("news.sogou.com", new U8SearchDefine() { Domain = "news.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("pic.sogou.com", new U8SearchDefine() { Domain = "pic.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("quan.sogou.com", new U8SearchDefine() { Domain = "quan.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("www.sogou.com", new U8SearchDefine() { Domain = "www.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("wap.sogou.com", new U8SearchDefine() { Domain = "wap.sogou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Sogou, KeyParameters = "(keyword)" });
            Settings.Add("m.sogou.com", new U8SearchDefine() { Domain = "m.sogou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Sogou, KeyParameters = "(keyword)" });
            
            Settings.Add("image.soso.com", new U8SearchDefine() { Domain = "image.soso.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Soso, KeyParameters = "(w)" });
            Settings.Add("news.soso.com", new U8SearchDefine() { Domain = "news.soso.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Soso, KeyParameters = "(w)" });
            Settings.Add("www.soso.com", new U8SearchDefine() { Domain = "www.soso.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = U8SearchGroupType.Soso, KeyParameters = "(w)" });
            Settings.Add("wap.soso.com", new U8SearchDefine() { Domain = "wap.soso.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Soso, KeyParameters = "(key)" });
            
            Settings.Add("cn.bing.com", new U8SearchDefine() { Domain = "cn.bing.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Bing, KeyParameters = "(q)" });
            
            Settings.Add("image.youdao.com", new U8SearchDefine() { Domain = "image.youdao.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Youdao, KeyParameters = "(q)" });
            Settings.Add("news.youdao.com", new U8SearchDefine() { Domain = "news.youdao.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Youdao, KeyParameters = "(q)" });
            Settings.Add("www.youdao.com", new U8SearchDefine() { Domain = "www.youdao.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Youdao, KeyParameters = "(q)" });
            
            Settings.Add("au.search.yahoo.com", new U8SearchDefine() { Domain = "au.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("br.yhs.search.yahoo.com", new U8SearchDefine() { Domain = "br.yhs.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("ca.search.yahoo.com", new U8SearchDefine() { Domain = "ca.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("ca.yhs4.search.yahoo.com", new U8SearchDefine() { Domain = "ca.yhs4.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("cade.search.yahoo.com", new U8SearchDefine() { Domain = "cade.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("cn.search.yahoo.com", new U8SearchDefine() { Domain = "cn.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("de.search.yahoo.com", new U8SearchDefine() { Domain = "de.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("es.search.yahoo.com", new U8SearchDefine() { Domain = "es.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("fr.search.yahoo.com", new U8SearchDefine() { Domain = "fr.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("hk.image.search.yahoo.com", new U8SearchDefine() { Domain = "hk.image.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("hk.search.yahoo.com", new U8SearchDefine() { Domain = "hk.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("image.yahoo.cn", new U8SearchDefine() { Domain = "image.yahoo.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(q)" });
            Settings.Add("images.search.yahoo.com", new U8SearchDefine() { Domain = "images.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("in.search.yahoo.com", new U8SearchDefine() { Domain = "in.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("it.search.yahoo.com", new U8SearchDefine() { Domain = "it.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("kr.search.yahoo.com", new U8SearchDefine() { Domain = "kr.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("maktoob.search.yahoo.com", new U8SearchDefine() { Domain = "maktoob.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("malaysia.search.yahoo.com", new U8SearchDefine() { Domain = "malaysia.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("mx.search.yahoo.com", new U8SearchDefine() { Domain = "mx.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("news.yahoo.cn", new U8SearchDefine() { Domain = "news.yahoo.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(q)" });
            Settings.Add("nl.search.yahoo.com", new U8SearchDefine() { Domain = "nl.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("se.search.yahoo.com", new U8SearchDefine() { Domain = "se.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("search.yahoo.co.jp", new U8SearchDefine() { Domain = "search.yahoo.co.jp", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("search.yahoo.com", new U8SearchDefine() { Domain = "search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("sg.images.search.yahoo.com", new U8SearchDefine() { Domain = "sg.images.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("sg.search.yahoo.com", new U8SearchDefine() { Domain = "sg.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("tw.image.search.yahoo.com", new U8SearchDefine() { Domain = "tw.image.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("tw.search.yahoo.com", new U8SearchDefine() { Domain = "tw.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("tw.yhs4.search.yahoo.com", new U8SearchDefine() { Domain = "tw.yhs4.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("uk.images.search.yahoo.com", new U8SearchDefine() { Domain = "uk.images.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("uk.search.yahoo.com", new U8SearchDefine() { Domain = "uk.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("us.yhs.search.yahoo.com", new U8SearchDefine() { Domain = "us.yhs.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("us.yhs4.search.yahoo.com", new U8SearchDefine() { Domain = "us.yhs4.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("video.search.yahoo.co.jp", new U8SearchDefine() { Domain = "video.search.yahoo.co.jp", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("vn.search.yahoo.com", new U8SearchDefine() { Domain = "vn.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("www.yahoo.cn", new U8SearchDefine() { Domain = "www.yahoo.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yahoo, KeyParameters = "(q)" });
            
            Settings.Add("news.so.360.cn", new U8SearchDefine() { Domain = "news.so.360.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("news.so.com", new U8SearchDefine() { Domain = "news.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("so.360.cn", new U8SearchDefine() { Domain = "so.360.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("so.v.360.cn", new U8SearchDefine() { Domain = "so.v.360.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "kw" });
            Settings.Add("video.so.com", new U8SearchDefine() { Domain = "video.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("m.so.com", new U8SearchDefine() { Domain = "m.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("www.so.com", new U8SearchDefine() { Domain = "www.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.So360, KeyParameters = "(q)" });

            Settings.Add("www.easou.com", new U8SearchDefine() { Domain = "www.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("pad.easou.com", new U8SearchDefine() { Domain = "pad.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("i.easou.com", new U8SearchDefine() { Domain = "i.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("wap.easou.com", new U8SearchDefine() { Domain = "wap.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("n.easou.com", new U8SearchDefine() { Domain = "n.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Easou, KeyParameters = "(q)" });

            Settings.Add("page.yicha.cn", new U8SearchDefine() { Domain = "page.yicha.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yicha, KeyParameters = "(key)" });
            Settings.Add("tnews.yicha.cn", new U8SearchDefine() { Domain = "tnews.yicha.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Yicha, KeyParameters = "(key)" });

            Settings.Add("wap.roboo.com", new U8SearchDefine() { Domain = "wap.roboo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = U8SearchGroupType.Roboo, KeyParameters = "(q)" });
            #endregion
        }

        /// <summary>
        /// 搜索定义
        /// </summary>
        public static Dictionary<string, U8SearchDefine> Settings = new Dictionary<string, U8SearchDefine>();

        /// <summary>
        /// 搜索组类型
        /// </summary>
        public U8SearchGroupType GroupType;

        /// <summary>
        /// 域名
        /// </summary>
        public string Domain;

        /// <summary>
        /// 关键参数
        /// </summary>
        public string KeyParameters;

        /// <summary>
        /// 编码类型
        /// </summary>
        public Encoding Encoding;

        /// <summary>
        /// 重写Equals
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>结果</returns>
        public override bool Equals(object obj)
        {
            var other = obj as U8SearchDefine;
            if (other != null)
            {
                return this.Domain.Equals(other.Domain);
            }
            return false;
        }

        /// <summary>
        /// 重写GetHashCode
        /// </summary>
        /// <returns>结果</returns>
        public override int GetHashCode()
        {
            return this.Domain.GetHashCode();
        }
    }
}
