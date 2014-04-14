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
        /// 获取Url参数值的Int32数据类型
        /// </summary>
        /// <param name="strQueryName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetQueryInt(string strQueryName, int defaultValue) {
            return StringUtils.StringToInt(HttpContext.Current.Request.QueryString[strQueryName], defaultValue);
        }
        /// <summary>
        /// 获取Url参数值的Float数据类型
        /// </summary>
        /// <param name="strQueryName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetQueryFloat(string strQueryName, float defaultValue) {
            return StringUtils.StringToFloat(HttpContext.Current.Request.QueryString[strQueryName], defaultValue);
        }
        /// <summary>
        /// 获取Url参数的值,没有对应参数返回空字符串
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
		/// 获取客户端的IP地址
		/// </summary>
		/// <returns></returns>
		public static string GetIP() {
			//可以透过代理服务器
			string userIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			if (userIP == null || userIP == "") {
				//没有代理服务器,如果有代理服务器获取的是代理服务器的IP
				userIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			return userIP;
		}
    }
}
