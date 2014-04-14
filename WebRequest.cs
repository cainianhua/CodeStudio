using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace CodeStudio {
    /// <summary>
    /// 
    /// </summary>
    public class WebRequest {
        /// <summary>
        /// ��ȡUrl����ֵ��Int32��������
        /// </summary>
        /// <param name="strQueryName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetQueryInt(string strQueryName, int defaultValue) {
            return StringUtils.StringToInt(HttpContext.Current.Request.QueryString[strQueryName], defaultValue);
        }
        /// <summary>
        /// ��ȡUrl����ֵ��Float��������
        /// </summary>
        /// <param name="strQueryName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetQueryFloat(string strQueryName, float defaultValue) {
            return StringUtils.StringToFloat(HttpContext.Current.Request.QueryString[strQueryName], defaultValue);
        }
        /// <summary>
        /// ��ȡUrl������ֵ,û�ж�Ӧ�������ؿ��ַ���
        /// </summary>
        /// <param name="strQueryName"></param>
        /// <returns></returns>
        public static string GetQueryString(string strQueryName) {
			return HttpContext.Current.Request.QueryString[strQueryName] ?? String.Empty;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strQueryName"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static string GetQueryString( string strQueryName, string defaultValue ) {
			return HttpContext.Current.Request.QueryString[strQueryName] ?? defaultValue;
		}
		/// <summary>
		/// ��ȡ�ͻ��˵�IP��ַ
		/// </summary>
		/// <returns></returns>
		public static string GetIP() {
			//����͸�����������
			string userIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (userIP == null || userIP == "") {
				//û�д��������,����д����������ȡ���Ǵ����������IP
				userIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			return userIP;
		}
    }
}
