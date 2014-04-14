using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeStudio {
    /// <summary>
    /// �ַ�����չ��
    /// </summary>
    public static class StringUtils {
        /// <summary>
        /// ���һ���ַ����ǲ�����ֵ��
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool IsNumber(this string strNumber) {
            return new Regex(@"^([0-9])[0-9]*(\.\w*)?$").IsMatch(strNumber);
        }

        /// <summary>
        /// ����Ƿ���SqlΣ���ַ�
        /// </summary>
        /// <param name="str">Ҫ�ж��ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool IsSafeSqlString(this string str) {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// ����Ƿ����email��ʽ
        /// </summary>
        /// <param name="strEmail">Ҫ�жϵ�email�ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool IsValidEmail(this string strEmail) {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// �Ƿ�Ϊ�Ϸ���IP��ʽ
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(this string ip) {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// �ж��ַ����Ƿ���yy-mm-dd�ַ���
        /// </summary>
        /// <param name="str">���ж��ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool IsDateString(this string str) {
            return Regex.IsMatch(str, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        /// <summary>
        /// �Ƿ��������ַ���
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool IsCN(this string Str) {
            return Regex.IsMatch(Str, "[һ-��]+");
        }

        /// <summary>
        /// ����Сд��ʽ�ľ���MD5���ܵ�32λ�ַ���
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5(this string s) {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
        }

        /// <summary>
        /// �Ѹ������ַ���ת��ΪInt32����
        /// </summary>
        /// <param name="strValue">��Ҫת�����ַ���</param>
        /// <param name="defValue">ת��ʧ�ܵ�Ĭ��ֵ</param>
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
        /// �Ѹ������ַ���ת��ΪFloat��������
        /// </summary>
        /// <param name="strValue">��Ҫת�����ַ���</param>
        /// <param name="defValue">ת��ʧ�ܵ�Ĭ��ֵ</param>
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
