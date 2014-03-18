using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace XiangZhouLuxian
{
    public partial class Message_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        PagedDataSource pds = new PagedDataSource();
        protected void bind()
        {
            Manager man = new Manager();

            pds.DataSource = man.GetMessageList("1").DefaultView;
            pds.AllowPaging = true;
            AspNetPager1.RecordCount = pds.DataSourceCount;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;

            rpmessagelist.DataSource = pds;
            rpmessagelist.DataBind();

            //上级精神
            rpsjjs.DataSource = man.GetTopNews("0", "7");
            rpsjjs.DataBind();

            //本地动态
            rpbddt.DataSource = man.GetTopNews("1", "7");
            rpbddt.DataBind();

            //案例展示
            rpanzs.DataSource = man.GetAnliNews("7");
            rpanzs.DataBind();

            //他山之石
            rptszs.DataSource = man.GetTopNews("7", "7");
            rptszs.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        public string Substr(string str, int len)
        {
            if (str.Length > len)
            {
                return str.Substring(0, len) + "...";
            }
            else
                return str;
        }

        public string convdate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            else
                return Convert.ToDateTime(str).ToString("yyyy-MM-dd");
        }
    }
}