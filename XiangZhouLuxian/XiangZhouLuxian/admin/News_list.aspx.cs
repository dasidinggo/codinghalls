using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Web.Services;

namespace XiangZhouLuxian.admin
{
    public partial class News_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string kind = Request.QueryString["kind"];
                hidkind.Value = kind;
                bind();
            }
        }
        PagedDataSource pds = new PagedDataSource();
        protected void bind()
        {
            Manager man = new Manager();

            pds.DataSource = man.SerNews(txtserword.Text.Trim(), hidkind.Value).DefaultView;
            pds.AllowPaging = true;
            AspNetPager1.RecordCount = pds.DataSourceCount;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;

            rpNewsList.DataSource = pds;
            rpNewsList.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        [WebMethod]
        public static string GetNewsInfo(string id)
        {
            Manager man = new Manager();
            DataTable dt = man.GetNewsById(id);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["title"].ToString() + "*" + dt.Rows[0]["remark"].ToString() + "*" + dt.Rows[0]["content"].ToString();
            else
                return "";
        }

        protected void delbtn_Command(object sender, CommandEventArgs e)
        {
            string tid = e.CommandName;
            Manager man = new Manager();
            if (man.DelNews(tid))
            {
                ScriptManager.RegisterStartupScript(rpNewsList, typeof(string), "del", "alert('刪除成功！');", true);
            }
            else
                ScriptManager.RegisterStartupScript(rpNewsList, typeof(string), "del", "alert('刪除失敗！');", true);
            bind();
        }

        protected void bnserach_Click(object sender, EventArgs e)
        {
            bind();
        }
    }
}