using Microsoft.Security.Application;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace U8.Framework.Web
{
    /// <summary>
    /// 防止XSS注入的工具类
    /// </summary>
    public static class U8AntiXss
    {
        static Dictionary<int, string> chars = new Dictionary<int, string>();
        static Regex regex = new Regex(@"&#(\d{5});", RegexOptions.Compiled);
        /// <summary>
        /// Provides encoding and decoding logic
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CssEncode(string input)
        {
            return Encoder.CssEncode(input);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlAttributeEncode(string input)
        {
            return Encoder.HtmlAttributeEncode(input);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlEncode(string input)
        {
            return Encoder.HtmlEncode(input);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="useNamedEntities"></param>
        /// <returns></returns>
        public static string HtmlEncode(string input, bool useNamedEntities)
        {
            return Encoder.HtmlEncode(input, useNamedEntities);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlFormUrlEncode(string input)
        {
            return Encoder.HtmlFormUrlEncode(input);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputEncoding">code</param>
        /// <returns></returns>
        public static string HtmlFormUrlEncode(string input, System.Text.Encoding inputEncoding)
        {
            return Encoder.HtmlFormUrlEncode(input, inputEncoding);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="codePage"></param>
        /// <returns></returns>
        public static string HtmlFormUrlEncode(string input, int codePage)
        {
            return Encoder.HtmlFormUrlEncode(input, codePage);
        }
        /// <summary>
        /// JavaScript字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string JavaScriptEncode(string input)
        {
            return Encoder.JavaScriptEncode(input);
        }
        /// <summary>
        /// html字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="emitQuotes"></param>
        /// <returns></returns>
        public static string JavaScriptEncode(string input, bool emitQuotes)
        {
            return Encoder.JavaScriptEncode(input, emitQuotes);
        }
        /// <summary>
        /// 字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LdapDistinguishedNameEncode(string input)
        {
            return Encoder.LdapDistinguishedNameEncode(input);
        }
        /// <summary>
        /// 字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="useInitialCharacterRules"></param>
        /// <param name="useFinalCharacterRule"></param>
        /// <returns></returns>
        public static string LdapDistinguishedNameEncode(string input, bool useInitialCharacterRules, bool useFinalCharacterRule)
        {
            return Encoder.LdapDistinguishedNameEncode(input, useInitialCharacterRules, useFinalCharacterRule);
        }
        /// <summary>
        /// 字符串Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LdapFilterEncode(string input)
        {
            return Encoder.LdapFilterEncode(input);
        }
        /// <summary>
        /// Url Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlEncode(string input)
        {
            return Encoder.UrlEncode(input);
        }
        /// <summary>
        ///  Url Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputEncoding"></param>
        /// <returns></returns>
        public static string UrlEncode(string input, System.Text.Encoding inputEncoding)
        {
            return Encoder.UrlEncode(input, inputEncoding);
        }
        /// <summary>
        ///  Url Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <param name="codePage"></param>
        /// <returns></returns>
        public static string UrlEncode(string input, int codePage)
        {
            return Encoder.UrlEncode(input, codePage);
        }
        /// <summary>
        ///  Url Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlPathEncode(string input)
        {
            return Encoder.UrlPathEncode(input);
        }
        /// <summary>
        ///  VisualBasicScript Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string VisualBasicScriptEncode(string input)
        {
            return Encoder.VisualBasicScriptEncode(input);
        }
        /// <summary>
        /// Xml Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string XmlAttributeEncode(string input)
        {
            return Encoder.XmlAttributeEncode(input);
        }
        /// <summary>
        /// Xml Encode编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string XmlEncode(string input)
        {
            return Encoder.XmlEncode(input);
        }
        /// <summary>
        /// 非法字符串过滤
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSafeHtml(string input)
        {
            string temp = Sanitizer.GetSafeHtml(input);

            var matchs = regex.Matches(temp);
            foreach (Match match in matchs)
            {
                string keyword = match.Groups[0].Value;
                int keywordChar = U8Convert.TryToInt32(match.Groups[1].Value);

                if (chars.ContainsKey(keywordChar))
                {
                    temp = temp.Replace(keyword, chars[keywordChar]);
                }
            }
            return temp;
        }
        /// <summary>
        /// 获取安全的html片段
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSafeHtmlFragment(string input)
        {
            string temp = Sanitizer.GetSafeHtmlFragment(input);

            var matchs = regex.Matches(temp);
            foreach (Match match in matchs)
            {
                string keyword = match.Groups[0].Value;
                int keywordChar = U8Convert.TryToInt32(match.Groups[1].Value);

                if (chars.ContainsKey(keywordChar))
                {
                    temp = temp.Replace(keyword, chars[keywordChar]);
                }
            }
            return temp;
        }

        private static Regex getSafeTextRegex = new Regex("<[^>]*>", RegexOptions.Compiled);
        /// <summary>
        /// 获取过滤后的文本
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSafeText(string input)
        {
            return getSafeTextRegex.Replace(input, "");
        }

        static U8AntiXss()
        {
            chars.Add(12092, "⼼");
            chars.Add(12348, "〼");
            chars.Add(12604, "ㄼ");
            chars.Add(12860, "㈼");
            chars.Add(13116, "㌼");
            chars.Add(13372, "㐼");
            chars.Add(13628, "㔼");
            chars.Add(13884, "㘼");
            chars.Add(14140, "㜼");
            chars.Add(14396, "㠼");
            chars.Add(14652, "㤼");
            chars.Add(14908, "㨼");
            chars.Add(15164, "㬼");
            chars.Add(15360, "㰀");
            chars.Add(15361, "㰁");
            chars.Add(15362, "㰂");
            chars.Add(15363, "㰃");
            chars.Add(15364, "㰄");
            chars.Add(15365, "㰅");
            chars.Add(15366, "㰆");
            chars.Add(15367, "㰇");
            chars.Add(15368, "㰈");
            chars.Add(15369, "㰉");
            chars.Add(15370, "㰊");
            chars.Add(15371, "㰋");
            chars.Add(15372, "㰌");
            chars.Add(15373, "㰍");
            chars.Add(15374, "㰎");
            chars.Add(15375, "㰏");
            chars.Add(15376, "㰐");
            chars.Add(15377, "㰑");
            chars.Add(15378, "㰒");
            chars.Add(15379, "㰓");
            chars.Add(15380, "㰔");
            chars.Add(15381, "㰕");
            chars.Add(15382, "㰖");
            chars.Add(15383, "㰗");
            chars.Add(15384, "㰘");
            chars.Add(15385, "㰙");
            chars.Add(15386, "㰚");
            chars.Add(15387, "㰛");
            chars.Add(15388, "㰜");
            chars.Add(15389, "㰝");
            chars.Add(15390, "㰞");
            chars.Add(15391, "㰟");
            chars.Add(15392, "㰠");
            chars.Add(15393, "㰡");
            chars.Add(15394, "㰢");
            chars.Add(15395, "㰣");
            chars.Add(15396, "㰤");
            chars.Add(15397, "㰥");
            chars.Add(15398, "㰦");
            chars.Add(15399, "㰧");
            chars.Add(15400, "㰨");
            chars.Add(15401, "㰩");
            chars.Add(15402, "㰪");
            chars.Add(15403, "㰫");
            chars.Add(15404, "㰬");
            chars.Add(15405, "㰭");
            chars.Add(15406, "㰮");
            chars.Add(15407, "㰯");
            chars.Add(15408, "㰰");
            chars.Add(15409, "㰱");
            chars.Add(15410, "㰲");
            chars.Add(15411, "㰳");
            chars.Add(15412, "㰴");
            chars.Add(15413, "㰵");
            chars.Add(15414, "㰶");
            chars.Add(15415, "㰷");
            chars.Add(15416, "㰸");
            chars.Add(15417, "㰹");
            chars.Add(15418, "㰺");
            chars.Add(15419, "㰻");
            chars.Add(15420, "㰼");
            chars.Add(15421, "㰽");
            chars.Add(15422, "㰾");
            chars.Add(15423, "㰿");
            chars.Add(15424, "㱀");
            chars.Add(15425, "㱁");
            chars.Add(15426, "㱂");
            chars.Add(15427, "㱃");
            chars.Add(15428, "㱄");
            chars.Add(15429, "㱅");
            chars.Add(15430, "㱆");
            chars.Add(15431, "㱇");
            chars.Add(15432, "㱈");
            chars.Add(15433, "㱉");
            chars.Add(15434, "㱊");
            chars.Add(15435, "㱋");
            chars.Add(15436, "㱌");
            chars.Add(15437, "㱍");
            chars.Add(15438, "㱎");
            chars.Add(15439, "㱏");
            chars.Add(15440, "㱐");
            chars.Add(15441, "㱑");
            chars.Add(15442, "㱒");
            chars.Add(15443, "㱓");
            chars.Add(15444, "㱔");
            chars.Add(15445, "㱕");
            chars.Add(15446, "㱖");
            chars.Add(15447, "㱗");
            chars.Add(15448, "㱘");
            chars.Add(15449, "㱙");
            chars.Add(15450, "㱚");
            chars.Add(15451, "㱛");
            chars.Add(15452, "㱜");
            chars.Add(15453, "㱝");
            chars.Add(15454, "㱞");
            chars.Add(15455, "㱟");
            chars.Add(15456, "㱠");
            chars.Add(15457, "㱡");
            chars.Add(15458, "㱢");
            chars.Add(15459, "㱣");
            chars.Add(15460, "㱤");
            chars.Add(15461, "㱥");
            chars.Add(15462, "㱦");
            chars.Add(15463, "㱧");
            chars.Add(15464, "㱨");
            chars.Add(15465, "㱩");
            chars.Add(15466, "㱪");
            chars.Add(15467, "㱫");
            chars.Add(15468, "㱬");
            chars.Add(15469, "㱭");
            chars.Add(15470, "㱮");
            chars.Add(15471, "㱯");
            chars.Add(15472, "㱰");
            chars.Add(15473, "㱱");
            chars.Add(15474, "㱲");
            chars.Add(15475, "㱳");
            chars.Add(15476, "㱴");
            chars.Add(15477, "㱵");
            chars.Add(15478, "㱶");
            chars.Add(15479, "㱷");
            chars.Add(15480, "㱸");
            chars.Add(15481, "㱹");
            chars.Add(15482, "㱺");
            chars.Add(15483, "㱻");
            chars.Add(15484, "㱼");
            chars.Add(15485, "㱽");
            chars.Add(15486, "㱾");
            chars.Add(15487, "㱿");
            chars.Add(15488, "㲀");
            chars.Add(15489, "㲁");
            chars.Add(15490, "㲂");
            chars.Add(15491, "㲃");
            chars.Add(15492, "㲄");
            chars.Add(15493, "㲅");
            chars.Add(15494, "㲆");
            chars.Add(15495, "㲇");
            chars.Add(15496, "㲈");
            chars.Add(15497, "㲉");
            chars.Add(15498, "㲊");
            chars.Add(15499, "㲋");
            chars.Add(15500, "㲌");
            chars.Add(15501, "㲍");
            chars.Add(15502, "㲎");
            chars.Add(15503, "㲏");
            chars.Add(15504, "㲐");
            chars.Add(15505, "㲑");
            chars.Add(15506, "㲒");
            chars.Add(15507, "㲓");
            chars.Add(15508, "㲔");
            chars.Add(15509, "㲕");
            chars.Add(15510, "㲖");
            chars.Add(15511, "㲗");
            chars.Add(15512, "㲘");
            chars.Add(15513, "㲙");
            chars.Add(15514, "㲚");
            chars.Add(15515, "㲛");
            chars.Add(15516, "㲜");
            chars.Add(15517, "㲝");
            chars.Add(15518, "㲞");
            chars.Add(15519, "㲟");
            chars.Add(15520, "㲠");
            chars.Add(15521, "㲡");
            chars.Add(15522, "㲢");
            chars.Add(15523, "㲣");
            chars.Add(15524, "㲤");
            chars.Add(15525, "㲥");
            chars.Add(15526, "㲦");
            chars.Add(15527, "㲧");
            chars.Add(15528, "㲨");
            chars.Add(15529, "㲩");
            chars.Add(15530, "㲪");
            chars.Add(15531, "㲫");
            chars.Add(15532, "㲬");
            chars.Add(15533, "㲭");
            chars.Add(15534, "㲮");
            chars.Add(15535, "㲯");
            chars.Add(15536, "㲰");
            chars.Add(15537, "㲱");
            chars.Add(15538, "㲲");
            chars.Add(15539, "㲳");
            chars.Add(15540, "㲴");
            chars.Add(15541, "㲵");
            chars.Add(15542, "㲶");
            chars.Add(15543, "㲷");
            chars.Add(15544, "㲸");
            chars.Add(15545, "㲹");
            chars.Add(15546, "㲺");
            chars.Add(15547, "㲻");
            chars.Add(15548, "㲼");
            chars.Add(15549, "㲽");
            chars.Add(15550, "㲾");
            chars.Add(15551, "㲿");
            chars.Add(15552, "㳀");
            chars.Add(15553, "㳁");
            chars.Add(15554, "㳂");
            chars.Add(15555, "㳃");
            chars.Add(15556, "㳄");
            chars.Add(15557, "㳅");
            chars.Add(15558, "㳆");
            chars.Add(15559, "㳇");
            chars.Add(15560, "㳈");
            chars.Add(15561, "㳉");
            chars.Add(15562, "㳊");
            chars.Add(15563, "㳋");
            chars.Add(15564, "㳌");
            chars.Add(15565, "㳍");
            chars.Add(15566, "㳎");
            chars.Add(15567, "㳏");
            chars.Add(15568, "㳐");
            chars.Add(15569, "㳑");
            chars.Add(15570, "㳒");
            chars.Add(15571, "㳓");
            chars.Add(15572, "㳔");
            chars.Add(15573, "㳕");
            chars.Add(15574, "㳖");
            chars.Add(15575, "㳗");
            chars.Add(15576, "㳘");
            chars.Add(15577, "㳙");
            chars.Add(15578, "㳚");
            chars.Add(15579, "㳛");
            chars.Add(15580, "㳜");
            chars.Add(15581, "㳝");
            chars.Add(15582, "㳞");
            chars.Add(15583, "㳟");
            chars.Add(15584, "㳠");
            chars.Add(15585, "㳡");
            chars.Add(15586, "㳢");
            chars.Add(15587, "㳣");
            chars.Add(15588, "㳤");
            chars.Add(15589, "㳥");
            chars.Add(15590, "㳦");
            chars.Add(15591, "㳧");
            chars.Add(15592, "㳨");
            chars.Add(15593, "㳩");
            chars.Add(15594, "㳪");
            chars.Add(15595, "㳫");
            chars.Add(15596, "㳬");
            chars.Add(15597, "㳭");
            chars.Add(15598, "㳮");
            chars.Add(15599, "㳯");
            chars.Add(15600, "㳰");
            chars.Add(15601, "㳱");
            chars.Add(15602, "㳲");
            chars.Add(15603, "㳳");
            chars.Add(15604, "㳴");
            chars.Add(15605, "㳵");
            chars.Add(15606, "㳶");
            chars.Add(15607, "㳷");
            chars.Add(15608, "㳸");
            chars.Add(15609, "㳹");
            chars.Add(15610, "㳺");
            chars.Add(15611, "㳻");
            chars.Add(15612, "㳼");
            chars.Add(15613, "㳽");
            chars.Add(15614, "㳾");
            chars.Add(15615, "㳿");
            chars.Add(15676, "㴼");
            chars.Add(15932, "㸼");
            chars.Add(16188, "㼼");
            chars.Add(16444, "䀼");
            chars.Add(16700, "䄼");
            chars.Add(16956, "䈼");
            chars.Add(17212, "䌼");
            chars.Add(17468, "䐼");
            chars.Add(17724, "䔼");
            chars.Add(17980, "䘼");
            chars.Add(18236, "䜼");
            chars.Add(18492, "䠼");
            chars.Add(18748, "䤼");
            chars.Add(19004, "䨼");
            chars.Add(19260, "䬼");
            chars.Add(19516, "䰼");
            chars.Add(19772, "䴼");
            chars.Add(20028, "丼");
            chars.Add(20284, "似");
            chars.Add(20540, "值");
            chars.Add(20796, "儼");
            chars.Add(21052, "刼");
            chars.Add(21308, "匼");
            chars.Add(21564, "吼");
            chars.Add(21820, "唼");
            chars.Add(22076, "嘼");
            chars.Add(22332, "圼");
            chars.Add(22588, "堼");
            chars.Add(22844, "夼");
            chars.Add(23100, "娼");
            chars.Add(23356, "嬼");
            chars.Add(23612, "尼");
            chars.Add(23868, "崼");
            chars.Add(24124, "帼");
            chars.Add(24380, "弼");
            chars.Add(24636, "怼");
            chars.Add(24892, "愼");
            chars.Add(25148, "戼");
            chars.Add(25404, "挼");
            chars.Add(25660, "搼");
            chars.Add(25916, "攼");
            chars.Add(26172, "昼");
            chars.Add(26428, "朼");
            chars.Add(26684, "格");
            chars.Add(26940, "椼");
            chars.Add(27196, "樼");
            chars.Add(27452, "欼");
            chars.Add(27708, "氼");
            chars.Add(27964, "洼");
            chars.Add(28220, "渼");
            chars.Add(28476, "漼");
            chars.Add(28732, "瀼");
            chars.Add(28988, "焼");
            chars.Add(29244, "爼");
            chars.Add(29500, "猼");
            chars.Add(29756, "琼");
            chars.Add(30012, "甼");
            chars.Add(30268, "瘼");
            chars.Add(30524, "眼");
            chars.Add(30780, "砼");
            chars.Add(31036, "礼");
            chars.Add(31292, "稼");
            chars.Add(31548, "笼");
            chars.Add(31804, "簼");
            chars.Add(32060, "紼");
            chars.Add(32316, "縼");
            chars.Add(32572, "缼");
            chars.Add(32828, "耼");
            chars.Add(33084, "脼");
            chars.Add(33340, "舼");
            chars.Add(33596, "茼");
            chars.Add(33852, "萼");
            chars.Add(34108, "蔼");
            chars.Add(34364, "蘼");
            chars.Add(34620, "蜼");
            chars.Add(34876, "蠼");
            chars.Add(35132, "褼");
            chars.Add(35388, "証");
            chars.Add(35644, "謼");
            chars.Add(35900, "谼");
            chars.Add(36156, "贼");
            chars.Add(36412, "踼");
            chars.Add(36668, "輼");
            chars.Add(36924, "逼");
            chars.Add(37180, "鄼");
            chars.Add(37436, "鈼");
            chars.Add(37692, "錼");
            chars.Add(37948, "鐼");
            chars.Add(38204, "锼");
            chars.Add(38460, "阼");
            chars.Add(38716, "霼");
            chars.Add(38972, "頼");
            chars.Add(39228, "餼");
            chars.Add(39484, "騼");
            chars.Add(39740, "鬼");
            chars.Add(39996, "鰼");
            chars.Add(40252, "鴼");
            chars.Add(40508, "鸼");
            chars.Add(40764, "鼼");
            chars.Add(41020, "ꀼ");
            chars.Add(41276, "ꄼ");
            chars.Add(41532, "ꈼ");
            chars.Add(41788, "ꌼ");
            chars.Add(42044, "ꐼ");
            chars.Add(63804, "祿");
            chars.Add(64060, "屮");
            chars.Add(65084, "︼");
        }

    }
}
