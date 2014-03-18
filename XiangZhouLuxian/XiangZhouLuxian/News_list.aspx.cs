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
    public partial class News_list : System.Web.UI.Page
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

            //主列表
            string kind = "0";
            if(!string.IsNullOrEmpty(Request.QueryString["kind"]))
                kind = Request.QueryString["kind"];
            if (kind == "234")
            {
                rpnewslist.DataSource = man.GetAnliNews("");
                lblnewlist.Text = "案例展示";
            }
            else
            {
                if (kind == "56")
                {
                    rpnewslist.DataSource = man.GetPinlunNews("");
                    lblnewlist.Text = "评论解读";
                }
                else
                {
                    rpnewslist.DataSource = man.GetNews(kind);
                    switch (kind)
                    {
                        case "0":
                            lblnewlist.Text = "上级精神";
                            break;
                        case "1":
                            lblnewlist.Text = "本地动态";
                            break;
                        case "2":
                        case "3":
                        case "4":
                            lblnewlist.Text = "案例展示";
                            break;
                        case "7":
                            lblnewlist.Text = "他山之石";
                            break;
                    }

                }
            }

            
            rpnewslist.DataBind();

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