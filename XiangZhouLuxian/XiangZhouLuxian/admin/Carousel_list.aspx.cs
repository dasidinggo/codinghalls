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
    public partial class Carousel_list : System.Web.UI.Page
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

            rpNewsList.DataSource = man.GetCarousel();
            rpNewsList.DataBind();
            hiditcount.Value = rpNewsList.Items.Count.ToString();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void delbtn_Command(object sender, CommandEventArgs e)
        {
            string tid = e.CommandName;
            Manager man = new Manager();
            if (man.DelCarousel(tid))
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