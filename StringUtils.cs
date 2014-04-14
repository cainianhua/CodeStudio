using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeStudio {
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringUtils {
        /// <summary>
        /// 检测一个字符串是不是数值型
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool IsNumber(this string strNumber) {
            return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strNumber);
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(this string str) {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(this string strEmail) {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 是否为合法的IP格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(this string ip) {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 判断字符串是否是yy-mm-dd字符串
        /// </summary>
        /// <param name="str">待判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsDateString(this string str) {
            return Regex.IsMatch(str, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        /// <summary>
        /// 是否是中文字符串
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool IsCN(this string Str) {
            return Regex.IsMatch(Str, "[一-龥]+");
        }

        /// <summary>
        /// 返回小写形式的经过MD5加密的32位字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5(this string s) {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
        }

        /// <summary>
        /// 把给定的字符串转换为Int32类型
        /// </summary>
        /// <param name="strValue">需要转换的字符串</param>
        /// <param name="defValue">转换失败的默认值</param>
        /// <returns></returns>
        internal static int StringToInt(object strValue, int defValue) {
            if (((strValue == null) || (strValue.ToString() == string.Empty)) || (strValue.ToString().Length > 10)) {
                return defValue;
            }
            string str = strValue.ToString();
            string strNumber = str[0].ToString();
            if (((str.Length == 10) && IsNumber(strNumber)) && (int.Parse(strNumber) > 1)) {
                return defValue;
            }
            if (!((str.Length != 10) || IsNumber(strNumber))) {
                return defValue;
            }
            int num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString())) {
                num = Convert.ToInt32(strValue);
            }
            return num;
        }

        /// <summary>
        /// 把给定的字符串转换为Float数据类型
        /// </summary>
        /// <param name="strValue">需要转换的字符串</param>
        /// <param name="defValue">转换失败的默认值</param>
        /// <returns></returns>
        internal static float StringToFloat(object strValue, float defValue) {
            if ((strValue == null) || (strValue.ToString().Length > 10)) {
                return defValue;
            }
            float num = defValue;
            if ((strValue != null) && new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString())) {
                num = Convert.ToSingle(strValue);
            }
            return num;
        }
    }
}
