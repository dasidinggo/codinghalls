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
    public partial class News_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void bind()
        {
            Manager man = new Manager();
            string nid = Request.QueryString["nid"];
            if (string.IsNullOrEmpty(nid))
                return;
            DataTable dtnewcon = man.GetNewsById(nid);
            rpnewcon.DataSource = dtnewcon;
            rpnewcon.DataBind();

            if (dtnewcon.Rows.Count > 0)
            {
                string kind = dtnewcon.Rows[0]["kind"].ToString();
                lbnnewlist.CommandName = kind;
                switch (kind)
                {
                    case "0":
                        lbnnewlist.Text = "上级精神";
                        break;
                    case "1":
                        lbnnewlist.Text = "本地动态";
                        break;
                    case "2":
                    case "3":
                    case "4":
                        lbnnewlist.Text = "案例展示";
                        break;
                    case "5":
                    case "6":
                        lbnnewlist.Text = "评论解读";
                        break;
                    case "7":
                        lbnnewlist.Text = "他山之石";
                        break;
                }
            }

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

        protected void lbnnewlist_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("News_list.aspx?kind=" + e.CommandName);
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
    }
}