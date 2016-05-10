﻿using System.Collections.Generic;

namespace UFIDA.Framework.Business
{
    /// <summary>
    /// 城市定义
    /// </summary>
    public static class UFIDACityDefine
    {
        private static Dictionary<string, int> Settings = new Dictionary<string, int>();

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static UFIDACityDefine()
        {
            Settings.Add("安康", 1);
            Settings.Add("百色", 2);
            Settings.Add("吉林", 3);
            Settings.Add("济南", 4);
            Settings.Add("济宁", 5);
            Settings.Add("佳木斯", 6);
            Settings.Add("嘉兴", 7);
            Settings.Add("嘉峪关", 8);
            Settings.Add("江门", 9);
            Settings.Add("江阴", 10);
            Settings.Add("焦作", 11);
            Settings.Add("揭阳", 12);
            Settings.Add("蚌埠", 13);
            Settings.Add("金昌", 14);
            Settings.Add("金华", 15);
            Settings.Add("锦州", 16);
            Settings.Add("晋城", 17);
            Settings.Add("晋中", 18);
            Settings.Add("荆门", 19);
            Settings.Add("荆州", 20);
            Settings.Add("景德镇", 21);
            Settings.Add("九江", 22);
            Settings.Add("酒泉", 23);
            Settings.Add("包头", 24);
            Settings.Add("开封", 25);
            Settings.Add("克拉玛依", 26);
            Settings.Add("昆明", 27);
            Settings.Add("昆山", 28);
            Settings.Add("来宾", 29);
            Settings.Add("莱芜", 30);
            Settings.Add("兰州", 31);
            Settings.Add("廊坊", 32);
            Settings.Add("乐山", 33);
            Settings.Add("丽江", 34);
            Settings.Add("宝鸡", 35);
            Settings.Add("丽水", 36);
            Settings.Add("连云港", 37);
            Settings.Add("凉山", 38);
            Settings.Add("辽阳", 39);
            Settings.Add("辽源", 40);
            Settings.Add("聊城", 41);
            Settings.Add("临沧", 42);
            Settings.Add("临汾", 43);
            Settings.Add("临沂", 44);
            Settings.Add("柳州", 45);
            Settings.Add("保定", 46);
            Settings.Add("六安", 47);
            Settings.Add("六盘水", 48);
            Settings.Add("龙岩", 49);
            Settings.Add("陇南", 50);
            Settings.Add("娄底", 51);
            Settings.Add("泸州", 52);
            Settings.Add("吕梁", 53);
            Settings.Add("洛阳", 54);
            Settings.Add("漯河", 55);
            Settings.Add("马鞍山", 56);
            Settings.Add("保山", 57);
            Settings.Add("茂名", 58);
            Settings.Add("眉山", 59);
            Settings.Add("梅州", 60);
            Settings.Add("绵阳", 61);
            Settings.Add("牡丹江", 62);
            Settings.Add("内江", 63);
            Settings.Add("南昌", 64);
            Settings.Add("南充", 65);
            Settings.Add("南京", 66);
            Settings.Add("南宁", 67);
            Settings.Add("北海", 68);
            Settings.Add("南平", 69);
            Settings.Add("南通", 70);
            Settings.Add("南阳", 71);
            Settings.Add("宁波", 72);
            Settings.Add("宁德", 73);
            Settings.Add("攀枝花", 74);
            Settings.Add("盘锦", 75);
            Settings.Add("平顶山", 76);
            Settings.Add("平凉", 77);
            Settings.Add("萍乡", 78);
            Settings.Add("北京", 79);
            Settings.Add("莆田", 80);
            Settings.Add("濮阳", 81);
            Settings.Add("普洱", 82);
            Settings.Add("七台河", 83);
            Settings.Add("齐齐哈尔", 84);
            Settings.Add("黔东南", 86);
            Settings.Add("黔南", 87);
            Settings.Add("黔西南", 88);
            Settings.Add("钦州", 89);
            Settings.Add("本溪", 90);
            Settings.Add("秦皇岛", 91);
            Settings.Add("青岛", 92);
            Settings.Add("清远", 93);
            Settings.Add("庆阳", 94);
            Settings.Add("曲靖", 95);
            Settings.Add("衢州", 96);
            Settings.Add("泉州", 97);
            Settings.Add("日照", 98);
            Settings.Add("三门峡", 99);
            Settings.Add("三明", 100);
            Settings.Add("毕节", 101);
            Settings.Add("三亚", 102);
            Settings.Add("汕头", 103);
            Settings.Add("汕尾", 104);
            Settings.Add("商洛", 105);
            Settings.Add("商丘", 106);
            Settings.Add("上海", 107);
            Settings.Add("上饶", 108);
            Settings.Add("韶关", 109);
            Settings.Add("邵阳", 110);
            Settings.Add("绍兴", 111);
            Settings.Add("安庆", 112);
            Settings.Add("滨州", 113);
            Settings.Add("深圳", 114);
            Settings.Add("沈阳", 115);
            Settings.Add("十堰", 116);
            Settings.Add("石家庄", 117);
            Settings.Add("石嘴山", 118);
            Settings.Add("双鸭山", 119);
            Settings.Add("顺德", 120);
            Settings.Add("朔州", 121);
            Settings.Add("四平", 122);
            Settings.Add("松原", 123);
            Settings.Add("亳州", 124);
            Settings.Add("苏州", 125);
            Settings.Add("宿迁", 126);
            Settings.Add("宿州", 127);
            Settings.Add("绥化", 128);
            Settings.Add("随州", 129);
            Settings.Add("遂宁", 130);
            Settings.Add("台州", 131);
            Settings.Add("太仓", 132);
            Settings.Add("太原", 133);
            Settings.Add("泰安", 134);
            Settings.Add("沧州", 135);
            Settings.Add("泰州", 136);
            Settings.Add("唐山", 137);
            Settings.Add("天津", 138);
            Settings.Add("天水", 139);
            Settings.Add("铁岭", 140);
            Settings.Add("通化", 141);
            Settings.Add("铜川", 142);
            Settings.Add("铜陵", 143);
            Settings.Add("铜仁", 144);
            Settings.Add("威海", 145);
            Settings.Add("长春", 146);
            Settings.Add("潍坊", 147);
            Settings.Add("渭南", 148);
            Settings.Add("温州", 149);
            Settings.Add("文山", 150);
            Settings.Add("乌鲁木齐", 151);
            Settings.Add("无锡", 152);
            Settings.Add("吴江", 153);
            Settings.Add("吴忠", 154);
            Settings.Add("芜湖", 155);
            Settings.Add("梧州", 156);
            Settings.Add("长沙", 157);
            Settings.Add("武汉", 158);
            Settings.Add("武威", 159);
            Settings.Add("西安", 160);
            Settings.Add("西宁", 161);
            Settings.Add("西双版纳", 162);
            Settings.Add("厦门", 163);
            Settings.Add("仙桃", 164);
            Settings.Add("咸宁", 165);
            Settings.Add("咸阳", 166);
            Settings.Add("香河", 167);
            Settings.Add("长兴", 168);
            Settings.Add("湘潭", 169);
            Settings.Add("湘西", 170);
            Settings.Add("襄阳", 171);
            Settings.Add("孝感", 172);
            Settings.Add("忻州", 173);
            Settings.Add("新乡", 174);
            Settings.Add("新余", 175);
            Settings.Add("信阳", 176);
            Settings.Add("邢台", 177);
            Settings.Add("徐州", 178);
            Settings.Add("长治", 179);
            Settings.Add("许昌", 180);
            Settings.Add("宣城", 181);
            Settings.Add("雅安", 182);
            Settings.Add("烟台", 183);
            Settings.Add("延安", 184);
            Settings.Add("延边", 185);
            Settings.Add("盐城", 186);
            Settings.Add("燕郊", 187);
            Settings.Add("扬州", 188);
            Settings.Add("阳江", 189);
            Settings.Add("常德", 190);
            Settings.Add("阳泉", 191);
            Settings.Add("伊春", 192);
            Settings.Add("宜宾", 193);
            Settings.Add("宜昌", 194);
            Settings.Add("宜春", 195);
            Settings.Add("益阳", 196);
            Settings.Add("银川", 197);
            Settings.Add("鹰潭", 198);
            Settings.Add("营口", 199);
            Settings.Add("永州", 200);
            Settings.Add("常熟", 201);
            Settings.Add("榆林", 202);
            Settings.Add("玉林", 203);
            Settings.Add("玉溪", 204);
            Settings.Add("岳阳", 205);
            Settings.Add("云浮", 206);
            Settings.Add("运城", 207);
            Settings.Add("枣庄", 208);
            Settings.Add("湛江", 209);
            Settings.Add("张家港", 210);
            Settings.Add("张家界", 211);
            Settings.Add("常州", 212);
            Settings.Add("张家口", 213);
            Settings.Add("张掖", 214);
            Settings.Add("漳州", 215);
            Settings.Add("昭通", 216);
            Settings.Add("肇庆", 217);
            Settings.Add("镇江", 218);
            Settings.Add("郑州", 219);
            Settings.Add("中山", 220);
            Settings.Add("中卫", 221);
            Settings.Add("重庆", 222);
            Settings.Add("安顺", 223);
            Settings.Add("巢湖", 224);
            Settings.Add("舟山", 225);
            Settings.Add("周口", 226);
            Settings.Add("株洲", 227);
            Settings.Add("珠海", 228);
            Settings.Add("驻马店", 229);
            Settings.Add("涿州", 230);
            Settings.Add("资阳", 231);
            Settings.Add("淄博", 232);
            Settings.Add("自贡", 233);
            Settings.Add("遵义", 234);
            Settings.Add("朝阳", 235);
            Settings.Add("潮州", 236);
            Settings.Add("郴州", 237);
            Settings.Add("成都", 238);
            Settings.Add("承德", 239);
            Settings.Add("池州", 240);
            Settings.Add("崇左", 241);
            Settings.Add("滁州", 242);
            Settings.Add("楚雄", 243);
            Settings.Add("安阳", 244);
            Settings.Add("达州", 245);
            Settings.Add("大理", 246);
            Settings.Add("大连", 247);
            Settings.Add("大庆", 248);
            Settings.Add("大同", 249);
            Settings.Add("丹东", 250);
            Settings.Add("德宏", 251);
            Settings.Add("德阳", 252);
            Settings.Add("定西", 253);
            Settings.Add("东莞", 254);
            Settings.Add("鞍山", 255);
            Settings.Add("东营", 256);
            Settings.Add("鄂尔多斯", 257);
            Settings.Add("鄂州", 258);
            Settings.Add("恩施", 259);
            Settings.Add("防城港", 260);
            Settings.Add("佛山", 261);
            Settings.Add("福州", 262);
            Settings.Add("抚顺", 263);
            Settings.Add("抚州", 264);
            Settings.Add("阜新", 265);
            Settings.Add("巴中", 266);
            Settings.Add("阜阳", 267);
            Settings.Add("赣州", 268);
            Settings.Add("固安", 269);
            Settings.Add("固原", 270);
            Settings.Add("广安", 271);
            Settings.Add("广元", 272);
            Settings.Add("广州", 273);
            Settings.Add("贵港", 274);
            Settings.Add("贵阳", 275);
            Settings.Add("桂林", 276);
            Settings.Add("白城", 277);
            Settings.Add("哈尔滨", 278);
            Settings.Add("海口", 279);
            Settings.Add("海南", 280);
            Settings.Add("邯郸", 281);
            Settings.Add("汉中", 282);
            Settings.Add("杭州", 283);
            Settings.Add("合肥", 284);
            Settings.Add("河池", 285);
            Settings.Add("河源", 286);
            Settings.Add("菏泽", 287);
            Settings.Add("白山", 288);
            Settings.Add("贺州", 289);
            Settings.Add("鹤壁", 290);
            Settings.Add("鹤岗", 291);
            Settings.Add("黑河", 292);
            Settings.Add("衡水", 293);
            Settings.Add("衡阳", 294);
            Settings.Add("红河", 295);
            Settings.Add("呼和浩特", 296);
            Settings.Add("湖州", 297);
            Settings.Add("葫芦岛", 298);
            Settings.Add("白银", 299);
            Settings.Add("怀化", 300);
            Settings.Add("淮安", 301);
            Settings.Add("淮北", 302);
            Settings.Add("淮南", 303);
            Settings.Add("黄冈", 304);
            Settings.Add("黄山", 305);
            Settings.Add("黄石", 306);
            Settings.Add("惠州", 307);
            Settings.Add("鸡西", 308);
            Settings.Add("吉安", 309);
            Settings.Add("永川", 310);
            Settings.Add("万州", 311);
            Settings.Add("涪陵", 312);
            Settings.Add("綦江", 313);
            Settings.Add("合川", 314);
            Settings.Add("襄樊", 315);
            Settings.Add("德州", 316);
            Settings.Add("香港", 317);
            Settings.Add("安徽", 318);
            Settings.Add("福建", 319);
            Settings.Add("甘肃", 320);
            Settings.Add("广东", 321);
            Settings.Add("广西", 322);
            Settings.Add("贵州", 323);
            Settings.Add("河北", 324);
            Settings.Add("河南", 325);
            Settings.Add("黑龙江", 326);
            Settings.Add("湖北", 327);
            Settings.Add("湖南", 328);
            Settings.Add("江苏", 329);
            Settings.Add("江西", 330);
            Settings.Add("辽宁", 331);
            Settings.Add("内蒙古", 332);
            Settings.Add("宁夏", 333);
            Settings.Add("青海", 334);
            Settings.Add("山东", 335);
            Settings.Add("山西", 336);
            Settings.Add("陕西", 337);
            Settings.Add("四川", 338);
            Settings.Add("新疆", 339);
            Settings.Add("云南", 340);
            Settings.Add("浙江", 341);
            Settings.Add("澳门", 342);
            Settings.Add("台湾", 343);
            Settings.Add("宜兴", 344);
        }


        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>结果</returns>
        public static int GetID(string name)
        {
            if (Settings.ContainsKey(name))
            {
                return Settings[name];
            }

            //其他
            return 85;
        }
    }
}
