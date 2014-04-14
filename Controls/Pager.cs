using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CodeStudio.Controls {
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData("<{0}:Pager runat=server></{0}:Pager>"), DefaultProperty("Text")]
    public class Pager : Literal {
        private string goScript() {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script type='text/javascript'>\r\n");
            builder.Append("var btngo = document.getElementById('__btnGo');\r\n");
            builder.Append("var url = document.getElementById('__Url');\r\n");
            builder.Append("var pagenum = document.getElementById('__PageNum');\r\n");
            builder.Append("btngo.onclick = function(){\r\n");
            builder.Append("if(isNaN(pagenum.value)){return;}\r\n");
            builder.Append("window.location = url.value.replace('{0}',pagenum.value);\r\n");
            builder.Append("}\r\n");
            builder.Append("</script>\r\n");
            return builder.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output) {
            string[] strArray;
            string str7;
            int num12;
            object obj2;
            int total = this.Total;
            int pageSize = this.PageSize;
            if (pageSize == 0) {
                pageSize = 20;
            }
            int currentPage = this.CurrentPage;
            if (currentPage < 1) {
                currentPage = 1;
            }
            int num4 = ((total % pageSize) == 0) ? (total / pageSize) : ((total / pageSize) + 1);
            if (currentPage > num4) {
                currentPage = num4;
            }
            int num5 = 6;
            int num6 = 2;
            int num7 = 2;
            int num8 = 6;
            int num9 = currentPage - num6;
            int num10 = currentPage + num6;
            if (num9 < 1) {
                num9 = 1;
            }
            if (num10 > num4) {
                num10 = num4;
            }
            string newValue = string.Empty;
            string str2 = "\n<!-- This Page Create At:" + DateTime.Now.ToString() + ",24040132,67970113-->\n<table id='" + this.ID + "' class='" + this.CssClass + "' align=\"{align}\" style=\"{style}\"><tr><td>{body}</td></tr></table>\n<!--24040132,67970113-->";
            string str3 = "border:0px solid #77C0EB;padding:0px 3px 0px 3px;;text-decoration:none";
            string str4 = "color:red";
            string str5 = string.Format("{0}", this.PText);
            string str6 = string.Format("{0}", this.NText);
            if (this.IfShowTotalText) {
                newValue = newValue + string.Format("Total&nbsp;<span style='color:red'>{0}</span>&nbsp;", this.Total);
            }
            if (this.IfShowFirstAndLastLink) {
                if (currentPage == 1) {
                    newValue = newValue + "<a disabled='disabled'>First</a>&nbsp;";
                }
                else {
                    newValue = newValue + "<a href='" + this.url.Replace("{0}", "1") + "'>First</a>&nbsp;";
                }
            }
            if (currentPage > 1) {
                str7 = newValue;
                strArray = new string[6];
                strArray[0] = str7;
                strArray[1] = "&nbsp;<a  href=\"";
                num12 = this.CurrentPage - 1;
                strArray[2] = this.url.Replace("{0}", num12.ToString());
                strArray[3] = "\">";
                strArray[4] = str5;
                strArray[5] = "</a>&nbsp;";
                newValue = string.Concat(strArray);
            }
            else if (this.IfAllwaysShowNextAndPretext) {
                newValue = newValue + "<a disabled='disabled'>" + str5 + "</a>&nbsp;";
            }
            if (this.IfShowNumber) {
                int num11;
                if ((num9 - num7) > num8) {
                    for (num11 = 1; num11 <= num7; num11++) {
                        obj2 = newValue;
                        newValue = string.Concat(new object[] { obj2, "&nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" });
                    }
                    newValue = newValue + "...";
                    for (num11 = (num4 - num5) + 1; num11 < num9; num11++) {
                        obj2 = newValue;
                        newValue = string.Concat(new object[] { obj2, "&nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" });
                    }
                }
                else {
                    for (num11 = 1; num11 < num9; num11++) {
                        obj2 = newValue;
                        newValue = string.Concat(new object[] { obj2, "&nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" });
                    }
                }
                num11 = num9;
                while (num11 <= num10) {
                    newValue = newValue + ((currentPage == num11) ? (" &nbsp;<b style=\"{itemStyleThis}\">" + num11.ToString() + "</b>&nbsp;") : string.Concat(new object[] { "&nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" }));
                    num11++;
                }
                if ((((num4 - num7) - num10) + 1) > num8) {
                    for (num11 = num10 + 1; num11 <= num5; num11++) {
                        obj2 = newValue;
                        newValue = string.Concat(new object[] { obj2, " &nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" });
                    }
                    newValue = newValue + "...";
                    for (num11 = (num4 - num7) + 1; num11 <= num4; num11++) {
                        obj2 = newValue;
                        newValue = string.Concat(new object[] { obj2, "&nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" });
                    }
                }
                else {
                    for (num11 = num10 + 1; num11 <= num4; num11++) {
                        obj2 = newValue;
                        newValue = string.Concat(new object[] { obj2, "&nbsp;<a style=\"{itemStyleLink}\" href=\"", this.url.Replace("{0}", num11.ToString()), "\">", num11, "</a>&nbsp;" });
                    }
                }
            }
            if (currentPage < num4) {
                str7 = newValue;
                strArray = new string[6];
                strArray[0] = str7;
                strArray[1] = "&nbsp;<a  href=\"";
                num12 = this.CurrentPage + 1;
                strArray[2] = this.url.Replace("{0}", num12.ToString());
                strArray[3] = "\">";
                strArray[4] = str6;
                strArray[5] = "</a>&nbsp;";
                newValue = string.Concat(strArray);
            }
            else if (this.IfAllwaysShowNextAndPretext) {
                newValue = newValue + "<a disabled='disabled'>" + str6 + "</a>&nbsp;";
            }
            if (this.IfShowFirstAndLastLink) {
                if (currentPage == num4) {
                    newValue = newValue + "&nbsp;<a disabled='disabled'>Last</a>";
                }
                else {
                    newValue = newValue + "<a href='" + this.url.Replace("{0}", num4.ToString()) + "'>&nbsp;Last</a>";
                }
            }
            if (this.IfShowInput) {
                obj2 = newValue;
                newValue = string.Concat(new object[] { obj2, "&nbsp;<input id='__Url' type='hidden' value='", this.url, "' totalpage='", num4, "'><input id='__PageNum' style='width:30px'><input id='__btnGo' type='button' value='Go' >", this.goScript() });
            }
            newValue = str2.Replace("{body}", newValue).Replace("{style}", this.style).Replace("{align}", this.align).Replace("{itemStyleLink}", str3).Replace("{itemStyleThis}", str4);
            output.Write(newValue);
        }
        /// <summary>
        /// 对齐方式
        /// </summary>
        [DefaultValue("right"), Bindable(true), Localizable(true), Category("Appearance")]
        public string align {
            get {
                string str = (string)this.ViewState["align"];
                return ((str == null) ? "right" : str);
            }
            set {
                this.ViewState["align"] = value;
            }
        }
        /// <summary>
        /// 分页信息的CSS样式
        /// </summary>
        public string CssClass {
            get {
                object obj2 = this.ViewState["CssClass"];
                return ((obj2 == null) ? "" : ((string)obj2));
            }
            set {
                this.ViewState["CssClass"] = value;
            }
        }
        /// <summary>
        /// 当前页
        /// </summary>
        [Category("Appearance"), Bindable(true), Localizable(true), DefaultValue("1")]
        public int CurrentPage {
            get {
                object obj2 = this.ViewState["CurrentPage"];
                return ((obj2 == null) ? 1 : ((int)obj2));
            }
            set {
                this.ViewState["CurrentPage"] = value;
            }
        }
        /// <summary>
        /// 是否显示Next和Previous链接
        /// </summary>
        [Bindable(true), Localizable(true), Category("Appearance"), DefaultValue("false")]
        public bool IfAllwaysShowNextAndPretext {
            get {
                object obj2 = this.ViewState["IfAllwaysShowNextAndPretext"];
                return ((obj2 != null) && bool.Parse(obj2.ToString()));
            }
            set {
                this.ViewState["IfAllwaysShowNextAndPretext"] = value;
            }
        }
        /// <summary>
        /// 是否显示First和Last链接
        /// </summary>
        [Category("Appearance"), Bindable(true), Localizable(true), DefaultValue("false")]
        public bool IfShowFirstAndLastLink {
            get {
                object obj2 = this.ViewState["IfShowFirstAndLastLink"];
                return ((obj2 != null) && bool.Parse(obj2.ToString()));
            }
            set {
                this.ViewState["IfShowFirstAndLastLink"] = value;
            }
        }
        /// <summary>
        /// 是否显示输入框
        /// </summary>
        [Bindable(true), Category("Appearance"), DefaultValue("false"), Localizable(true)]
        public bool IfShowInput {
            get {
                object obj2 = this.ViewState["IfShowInput"];
                return ((obj2 != null) && bool.Parse(obj2.ToString()));
            }
            set {
                this.ViewState["IfShowInput"] = value;
            }
        }
        /// <summary>
        /// 是否显示页号数据
        /// </summary>
        [Localizable(true), DefaultValue("true"), Bindable(true), Category("Appearance")]
        public bool IfShowNumber {
            get {
                object obj2 = this.ViewState["IfShowNumber"];
                return ((obj2 == null) || bool.Parse(obj2.ToString()));
            }
            set {
                this.ViewState["IfShowNumber"] = value;
            }
        }
        /// <summary>
        /// 是否显示总记录数据
        /// </summary>
        [Bindable(true), Localizable(true), Category("Appearance"), DefaultValue("false")]
        public bool IfShowTotalText {
            get {
                object obj2 = this.ViewState["IfShowTotalText"];
                return ((obj2 != null) && bool.Parse(obj2.ToString()));
            }
            set {
                this.ViewState["IfShowTotalText"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Localizable(true), Bindable(true), DefaultValue("Next")]
        public string NText {
            get {
                object obj2 = this.ViewState["NText"];
                return ((obj2 == null) ? "Next" : ((string)obj2));
            }
            set {
                this.ViewState["NText"] = value;
            }
        }
        /// <summary>
        /// 分页大小
        /// </summary>
        [Localizable(true), Bindable(true), Category("Appearance"), DefaultValue("20")]
        public int PageSize {
            get {
                object obj2 = this.ViewState["PageSize"];
                return ((obj2 == null) ? 20 : ((int)obj2));
            }
            set {
                this.ViewState["PageSize"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Localizable(true), Category("Appearance"), Bindable(true), DefaultValue("Previous")]
        public string PText {
            get {
                object obj2 = this.ViewState["PText"];
                return ((obj2 == null) ? "Previous" : ((string)obj2));
            }
            set {
                this.ViewState["PText"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Localizable(true), Bindable(true), Category("Appearance"), DefaultValue("float:right;border:0px solid #FF9A35;font-size:9pt;text-align:right; height:25px; vertical-align:middle; margin-top:10px")]
        public string style {
            get {
                string str = (string)this.ViewState["style"];
                return ((str == null) ? string.Empty : str);
            }
            set {
                this.ViewState["style"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("1981"), Localizable(true), Category("Appearance"), Bindable(true)]
        public int Total {
            get {
                object obj2 = this.ViewState["Total"];
                return ((obj2 == null) ? 0x7bd : ((int)obj2));
            }
            set {
                this.ViewState["Total"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Bindable(true), Localizable(true), Category("Appearance"), DefaultValue("?Page={0}")]
        public string url {
            get {
                string str = (string)this.ViewState["url"];
                return ((str == null) ? string.Empty : str);
            }
            set {
                this.ViewState["url"] = value;
            }
        }
    }
}