using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// 搜索定义
    /// </summary>
    public class UFIDASearchDefine
    {
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static UFIDASearchDefine()
        {
            #region 初始化搜索定义
            Settings.Add("baidu.mobi", new UFIDASearchDefine() { Domain = "baidu.mobi", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(kw)" });
            Settings.Add("image.baidu.com", new UFIDASearchDefine() { Domain = "image.baidu.com", Encoding = Encoding.GetEncoding("gbk"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(q)" });
            Settings.Add("m.baidu.com", new UFIDASearchDefine() { Domain = "m.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m1.baidu.com", new UFIDASearchDefine() { Domain = "m1.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m2.baidu.com", new UFIDASearchDefine() { Domain = "m2.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m3.baidu.com", new UFIDASearchDefine() { Domain = "m3.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m4.baidu.com", new UFIDASearchDefine() { Domain = "m4.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m5.baidu.com", new UFIDASearchDefine() { Domain = "m5.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m6.baidu.com", new UFIDASearchDefine() { Domain = "m6.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m7.baidu.com", new UFIDASearchDefine() { Domain = "m7.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m8.baidu.com", new UFIDASearchDefine() { Domain = "m8.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("m9.baidu.com", new UFIDASearchDefine() { Domain = "m9.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("3g.baidu.com", new UFIDASearchDefine() { Domain = "3g.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("wap.baidu.com", new UFIDASearchDefine() { Domain = "wap.baidu.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(kw)" });
            Settings.Add("news.baidu.com", new UFIDASearchDefine() { Domain = "news.baidu.com", Encoding = Encoding.GetEncoding("gbk"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(q)" });
            Settings.Add("www.baidu.com", new UFIDASearchDefine() { Domain = "www.baidu.com", Encoding = Encoding.GetEncoding("gbk"), GroupType = UFIDASearchGroupType.Baidu, KeyParameters = "(word),(wd),(q)" });
            
            Settings.Add("groups.google.com", new UFIDASearchDefine() { Domain = "groups.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com", new UFIDASearchDefine() { Domain = "images.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com.hk", new UFIDASearchDefine() { Domain = "images.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com.my", new UFIDASearchDefine() { Domain = "images.google.com.my", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("images.google.com.tw", new UFIDASearchDefine() { Domain = "images.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("ipv6.google.com", new UFIDASearchDefine() { Domain = "ipv6.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("ipv6.google.com.hk", new UFIDASearchDefine() { Domain = "ipv6.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("mail.google.com", new UFIDASearchDefine() { Domain = "mail.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("maps.google.com", new UFIDASearchDefine() { Domain = "maps.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("maps.google.com.hk", new UFIDASearchDefine() { Domain = "maps.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("maps.google.com.tw", new UFIDASearchDefine() { Domain = "maps.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com", new UFIDASearchDefine() { Domain = "news.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.au", new UFIDASearchDefine() { Domain = "news.google.com.au", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.hk", new UFIDASearchDefine() { Domain = "news.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.my", new UFIDASearchDefine() { Domain = "news.google.com.my", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.sg", new UFIDASearchDefine() { Domain = "news.google.com.sg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("news.google.com.tw", new UFIDASearchDefine() { Domain = "news.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("plus.url.google.com", new UFIDASearchDefine() { Domain = "plus.url.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ae", new UFIDASearchDefine() { Domain = "www.google.ae", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.am", new UFIDASearchDefine() { Domain = "www.google.am", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.as", new UFIDASearchDefine() { Domain = "www.google.as", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.at", new UFIDASearchDefine() { Domain = "www.google.at", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.az", new UFIDASearchDefine() { Domain = "www.google.az", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ba", new UFIDASearchDefine() { Domain = "www.google.ba", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.be", new UFIDASearchDefine() { Domain = "www.google.be", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.bg", new UFIDASearchDefine() { Domain = "www.google.bg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.bs", new UFIDASearchDefine() { Domain = "www.google.bs", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ca", new UFIDASearchDefine() { Domain = "www.google.ca", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cat", new UFIDASearchDefine() { Domain = "www.google.cat", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ch", new UFIDASearchDefine() { Domain = "www.google.ch", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cl", new UFIDASearchDefine() { Domain = "www.google.cl", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cm", new UFIDASearchDefine() { Domain = "www.google.cm", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cn", new UFIDASearchDefine() { Domain = "www.google.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.bw", new UFIDASearchDefine() { Domain = "www.google.co.bw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.cr", new UFIDASearchDefine() { Domain = "www.google.co.cr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.id", new UFIDASearchDefine() { Domain = "www.google.co.id", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.il", new UFIDASearchDefine() { Domain = "www.google.co.il", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.in", new UFIDASearchDefine() { Domain = "www.google.co.in", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.jp", new UFIDASearchDefine() { Domain = "www.google.co.jp", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.ke", new UFIDASearchDefine() { Domain = "www.google.co.ke", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.kr", new UFIDASearchDefine() { Domain = "www.google.co.kr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.ma", new UFIDASearchDefine() { Domain = "www.google.co.ma", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.nz", new UFIDASearchDefine() { Domain = "www.google.co.nz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.th", new UFIDASearchDefine() { Domain = "www.google.co.th", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.tz", new UFIDASearchDefine() { Domain = "www.google.co.tz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.uk", new UFIDASearchDefine() { Domain = "www.google.co.uk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.uz", new UFIDASearchDefine() { Domain = "www.google.co.uz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.ve", new UFIDASearchDefine() { Domain = "www.google.co.ve", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.za", new UFIDASearchDefine() { Domain = "www.google.co.za", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.co.zw", new UFIDASearchDefine() { Domain = "www.google.co.zw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com", new UFIDASearchDefine() { Domain = "www.google.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ag", new UFIDASearchDefine() { Domain = "www.google.com.ag", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ai", new UFIDASearchDefine() { Domain = "www.google.com.ai", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ar", new UFIDASearchDefine() { Domain = "www.google.com.ar", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.au", new UFIDASearchDefine() { Domain = "www.google.com.au", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bd", new UFIDASearchDefine() { Domain = "www.google.com.bd", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bn", new UFIDASearchDefine() { Domain = "www.google.com.bn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bo", new UFIDASearchDefine() { Domain = "www.google.com.bo", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.br", new UFIDASearchDefine() { Domain = "www.google.com.br", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.bz", new UFIDASearchDefine() { Domain = "www.google.com.bz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.co", new UFIDASearchDefine() { Domain = "www.google.com.co", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.cy", new UFIDASearchDefine() { Domain = "www.google.com.cy", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.do", new UFIDASearchDefine() { Domain = "www.google.com.do", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ec", new UFIDASearchDefine() { Domain = "www.google.com.ec", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.eg", new UFIDASearchDefine() { Domain = "www.google.com.eg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.et", new UFIDASearchDefine() { Domain = "www.google.com.et", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.fj", new UFIDASearchDefine() { Domain = "www.google.com.fj", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.gh", new UFIDASearchDefine() { Domain = "www.google.com.gh", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.gt", new UFIDASearchDefine() { Domain = "www.google.com.gt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.hk", new UFIDASearchDefine() { Domain = "www.google.com.hk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.hk.", new UFIDASearchDefine() { Domain = "www.google.com.hk.", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.jm", new UFIDASearchDefine() { Domain = "www.google.com.jm", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.kh", new UFIDASearchDefine() { Domain = "www.google.com.kh", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.kw", new UFIDASearchDefine() { Domain = "www.google.com.kw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.lb", new UFIDASearchDefine() { Domain = "www.google.com.lb", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.mt", new UFIDASearchDefine() { Domain = "www.google.com.mt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.mx", new UFIDASearchDefine() { Domain = "www.google.com.mx", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.my", new UFIDASearchDefine() { Domain = "www.google.com.my", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.na", new UFIDASearchDefine() { Domain = "www.google.com.na", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ng", new UFIDASearchDefine() { Domain = "www.google.com.ng", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.np", new UFIDASearchDefine() { Domain = "www.google.com.np", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.om", new UFIDASearchDefine() { Domain = "www.google.com.om", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pa", new UFIDASearchDefine() { Domain = "www.google.com.pa", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pe", new UFIDASearchDefine() { Domain = "www.google.com.pe", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ph", new UFIDASearchDefine() { Domain = "www.google.com.ph", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pk", new UFIDASearchDefine() { Domain = "www.google.com.pk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.pr", new UFIDASearchDefine() { Domain = "www.google.com.pr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.qa", new UFIDASearchDefine() { Domain = "www.google.com.qa", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.sa", new UFIDASearchDefine() { Domain = "www.google.com.sa", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.sb", new UFIDASearchDefine() { Domain = "www.google.com.sb", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.sg", new UFIDASearchDefine() { Domain = "www.google.com.sg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.tn", new UFIDASearchDefine() { Domain = "www.google.com.tn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.tr", new UFIDASearchDefine() { Domain = "www.google.com.tr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.tw", new UFIDASearchDefine() { Domain = "www.google.com.tw", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.ua", new UFIDASearchDefine() { Domain = "www.google.com.ua", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.uy", new UFIDASearchDefine() { Domain = "www.google.com.uy", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.vc", new UFIDASearchDefine() { Domain = "www.google.com.vc", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.com.vn", new UFIDASearchDefine() { Domain = "www.google.com.vn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.combj-ibook.cn", new UFIDASearchDefine() { Domain = "www.google.combj-ibook.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.cz", new UFIDASearchDefine() { Domain = "www.google.cz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.de", new UFIDASearchDefine() { Domain = "www.google.de", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.dk", new UFIDASearchDefine() { Domain = "www.google.dk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ee", new UFIDASearchDefine() { Domain = "www.google.ee", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.es", new UFIDASearchDefine() { Domain = "www.google.es", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.fi", new UFIDASearchDefine() { Domain = "www.google.fi", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.fm", new UFIDASearchDefine() { Domain = "www.google.fm", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.fr", new UFIDASearchDefine() { Domain = "www.google.fr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ge", new UFIDASearchDefine() { Domain = "www.google.ge", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.gr", new UFIDASearchDefine() { Domain = "www.google.gr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.hn", new UFIDASearchDefine() { Domain = "www.google.hn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ht", new UFIDASearchDefine() { Domain = "www.google.ht", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.hu", new UFIDASearchDefine() { Domain = "www.google.hu", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ie", new UFIDASearchDefine() { Domain = "www.google.ie", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.iq", new UFIDASearchDefine() { Domain = "www.google.iq", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.is", new UFIDASearchDefine() { Domain = "www.google.is", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.it", new UFIDASearchDefine() { Domain = "www.google.it", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.jo", new UFIDASearchDefine() { Domain = "www.google.jo", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.kg", new UFIDASearchDefine() { Domain = "www.google.kg", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.kz", new UFIDASearchDefine() { Domain = "www.google.kz", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.lt", new UFIDASearchDefine() { Domain = "www.google.lt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.lu", new UFIDASearchDefine() { Domain = "www.google.lu", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.lv", new UFIDASearchDefine() { Domain = "www.google.lv", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.md", new UFIDASearchDefine() { Domain = "www.google.md", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.mn", new UFIDASearchDefine() { Domain = "www.google.mn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.mu", new UFIDASearchDefine() { Domain = "www.google.mu", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.nl", new UFIDASearchDefine() { Domain = "www.google.nl", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.no", new UFIDASearchDefine() { Domain = "www.google.no", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.nr", new UFIDASearchDefine() { Domain = "www.google.nr", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.pl", new UFIDASearchDefine() { Domain = "www.google.pl", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.pt", new UFIDASearchDefine() { Domain = "www.google.pt", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ro", new UFIDASearchDefine() { Domain = "www.google.ro", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ru", new UFIDASearchDefine() { Domain = "www.google.ru", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.se", new UFIDASearchDefine() { Domain = "www.google.se", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.sk", new UFIDASearchDefine() { Domain = "www.google.sk", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.tn", new UFIDASearchDefine() { Domain = "www.google.tn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            Settings.Add("www.google.ws", new UFIDASearchDefine() { Domain = "www.google.ws", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Google, KeyParameters = "(q)" });
            
            Settings.Add("news.sogou.com", new UFIDASearchDefine() { Domain = "news.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("pic.sogou.com", new UFIDASearchDefine() { Domain = "pic.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("quan.sogou.com", new UFIDASearchDefine() { Domain = "quan.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("www.sogou.com", new UFIDASearchDefine() { Domain = "www.sogou.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Sogou, KeyParameters = "(query)" });
            Settings.Add("wap.sogou.com", new UFIDASearchDefine() { Domain = "wap.sogou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Sogou, KeyParameters = "(keyword)" });
            Settings.Add("m.sogou.com", new UFIDASearchDefine() { Domain = "m.sogou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Sogou, KeyParameters = "(keyword)" });
            
            Settings.Add("image.soso.com", new UFIDASearchDefine() { Domain = "image.soso.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Soso, KeyParameters = "(w)" });
            Settings.Add("news.soso.com", new UFIDASearchDefine() { Domain = "news.soso.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Soso, KeyParameters = "(w)" });
            Settings.Add("www.soso.com", new UFIDASearchDefine() { Domain = "www.soso.com", Encoding = Encoding.GetEncoding("gb2312"), GroupType = UFIDASearchGroupType.Soso, KeyParameters = "(w)" });
            Settings.Add("wap.soso.com", new UFIDASearchDefine() { Domain = "wap.soso.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Soso, KeyParameters = "(key)" });
            
            Settings.Add("cn.bing.com", new UFIDASearchDefine() { Domain = "cn.bing.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Bing, KeyParameters = "(q)" });
            
            Settings.Add("image.youdao.com", new UFIDASearchDefine() { Domain = "image.youdao.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Youdao, KeyParameters = "(q)" });
            Settings.Add("news.youdao.com", new UFIDASearchDefine() { Domain = "news.youdao.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Youdao, KeyParameters = "(q)" });
            Settings.Add("www.youdao.com", new UFIDASearchDefine() { Domain = "www.youdao.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Youdao, KeyParameters = "(q)" });
            
            Settings.Add("au.search.yahoo.com", new UFIDASearchDefine() { Domain = "au.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("br.yhs.search.yahoo.com", new UFIDASearchDefine() { Domain = "br.yhs.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("ca.search.yahoo.com", new UFIDASearchDefine() { Domain = "ca.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("ca.yhs4.search.yahoo.com", new UFIDASearchDefine() { Domain = "ca.yhs4.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("cade.search.yahoo.com", new UFIDASearchDefine() { Domain = "cade.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("cn.search.yahoo.com", new UFIDASearchDefine() { Domain = "cn.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("de.search.yahoo.com", new UFIDASearchDefine() { Domain = "de.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("es.search.yahoo.com", new UFIDASearchDefine() { Domain = "es.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("fr.search.yahoo.com", new UFIDASearchDefine() { Domain = "fr.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("hk.image.search.yahoo.com", new UFIDASearchDefine() { Domain = "hk.image.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("hk.search.yahoo.com", new UFIDASearchDefine() { Domain = "hk.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("image.yahoo.cn", new UFIDASearchDefine() { Domain = "image.yahoo.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(q)" });
            Settings.Add("images.search.yahoo.com", new UFIDASearchDefine() { Domain = "images.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("in.search.yahoo.com", new UFIDASearchDefine() { Domain = "in.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("it.search.yahoo.com", new UFIDASearchDefine() { Domain = "it.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("kr.search.yahoo.com", new UFIDASearchDefine() { Domain = "kr.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("maktoob.search.yahoo.com", new UFIDASearchDefine() { Domain = "maktoob.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("malaysia.search.yahoo.com", new UFIDASearchDefine() { Domain = "malaysia.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("mx.search.yahoo.com", new UFIDASearchDefine() { Domain = "mx.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("news.yahoo.cn", new UFIDASearchDefine() { Domain = "news.yahoo.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(q)" });
            Settings.Add("nl.search.yahoo.com", new UFIDASearchDefine() { Domain = "nl.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("se.search.yahoo.com", new UFIDASearchDefine() { Domain = "se.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("search.yahoo.co.jp", new UFIDASearchDefine() { Domain = "search.yahoo.co.jp", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("search.yahoo.com", new UFIDASearchDefine() { Domain = "search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("sg.images.search.yahoo.com", new UFIDASearchDefine() { Domain = "sg.images.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("sg.search.yahoo.com", new UFIDASearchDefine() { Domain = "sg.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("tw.image.search.yahoo.com", new UFIDASearchDefine() { Domain = "tw.image.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("tw.search.yahoo.com", new UFIDASearchDefine() { Domain = "tw.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("tw.yhs4.search.yahoo.com", new UFIDASearchDefine() { Domain = "tw.yhs4.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("uk.images.search.yahoo.com", new UFIDASearchDefine() { Domain = "uk.images.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("uk.search.yahoo.com", new UFIDASearchDefine() { Domain = "uk.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("us.yhs.search.yahoo.com", new UFIDASearchDefine() { Domain = "us.yhs.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("us.yhs4.search.yahoo.com", new UFIDASearchDefine() { Domain = "us.yhs4.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("video.search.yahoo.co.jp", new UFIDASearchDefine() { Domain = "video.search.yahoo.co.jp", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("vn.search.yahoo.com", new UFIDASearchDefine() { Domain = "vn.search.yahoo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(p)" });
            Settings.Add("www.yahoo.cn", new UFIDASearchDefine() { Domain = "www.yahoo.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yahoo, KeyParameters = "(q)" });
            
            Settings.Add("news.so.360.cn", new UFIDASearchDefine() { Domain = "news.so.360.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("news.so.com", new UFIDASearchDefine() { Domain = "news.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("so.360.cn", new UFIDASearchDefine() { Domain = "so.360.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("so.v.360.cn", new UFIDASearchDefine() { Domain = "so.v.360.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "kw" });
            Settings.Add("video.so.com", new UFIDASearchDefine() { Domain = "video.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("m.so.com", new UFIDASearchDefine() { Domain = "m.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "(q)" });
            Settings.Add("www.so.com", new UFIDASearchDefine() { Domain = "www.so.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.So360, KeyParameters = "(q)" });

            Settings.Add("www.easou.com", new UFIDASearchDefine() { Domain = "www.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("pad.easou.com", new UFIDASearchDefine() { Domain = "pad.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("i.easou.com", new UFIDASearchDefine() { Domain = "i.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("wap.easou.com", new UFIDASearchDefine() { Domain = "wap.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Easou, KeyParameters = "(q)" });
            Settings.Add("n.easou.com", new UFIDASearchDefine() { Domain = "n.easou.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Easou, KeyParameters = "(q)" });

            Settings.Add("page.yicha.cn", new UFIDASearchDefine() { Domain = "page.yicha.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yicha, KeyParameters = "(key)" });
            Settings.Add("tnews.yicha.cn", new UFIDASearchDefine() { Domain = "tnews.yicha.cn", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Yicha, KeyParameters = "(key)" });

            Settings.Add("wap.roboo.com", new UFIDASearchDefine() { Domain = "wap.roboo.com", Encoding = Encoding.GetEncoding("utf-8"), GroupType = UFIDASearchGroupType.Roboo, KeyParameters = "(q)" });
            #endregion
        }

        /// <summary>
        /// 搜索定义
        /// </summary>
        public static Dictionary<string, UFIDASearchDefine> Settings = new Dictionary<string, UFIDASearchDefine>();

        /// <summary>
        /// 搜索组类型
        /// </summary>
        public UFIDASearchGroupType GroupType;

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
            var other = obj as UFIDASearchDefine;
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
