using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace XiangZhouLuxian
{
    public partial class index : System.Web.UI.Page
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

            //轮播图片
            DataTable dtcar = man.GetCarousel();
            rpcarlist.DataSource = dtcar;
            rpcarlist.DataBind();

            //本地动态
            DataTable dtbddt = man.GetTopNews("1","6");
            rpbddt.DataSource = dtbddt;
            rpbddt.DataBind();

            //上级精神
            DataTable dtsjjs = man.GetTopNews("0", "5");
            rpsjjs.DataSource = dtsjjs;
            rpsjjs.DataBind();

            //典型人物
            DataTable dtpeo = man.GetTopNews("2", "3");
            if (dtpeo.Rows.Count > 0)
            {
                lblpeo.Text = dtpeo.Rows[0]["title"].ToString();
                lblpeocon.Text = " &nbsp; &nbsp; &nbsp; " + Substr(NoHTML(dtpeo.Rows[0]["content"].ToString()), 40);
                lbnpeo.CommandName = dtpeo.Rows[0]["ID"].ToString();
            }
            else
                lbnpeo.Visible = false;
            rppeo.DataSource = dtpeo;
            rppeo.ItemDataBound += new RepeaterItemEventHandler(rppeo_ItemDataBound);
            rppeo.DataBind();

            //典型举措
            DataTable dtjucuo = man.GetTopNews("3", "3");
            if (dtjucuo.Rows.Count > 0)
            {
                lbljucuo.Text = dtjucuo.Rows[0]["title"].ToString();
                lbljccon.Text = " &nbsp; &nbsp; &nbsp; " + Substr(NoHTML(dtjucuo.Rows[0]["content"].ToString()), 40);
                lbnjucuo.CommandName = dtjucuo.Rows[0]["ID"].ToString();
            }
            else
                lbnjucuo.Visible = false;
            rpjucuo.DataSource = dtjucuo;
            rpjucuo.ItemDataBound += new RepeaterItemEventHandler(rpjucuo_ItemDataBound);
            rpjucuo.DataBind();

            //典型事例
            DataTable dtshili = man.GetTopNews("4", "3");
            if (dtshili.Rows.Count > 0)
            {
                lblshili.Text = dtshili.Rows[0]["title"].ToString();
                lblshicon.Text = " &nbsp; &nbsp; &nbsp; " + Substr(NoHTML(dtshili.Rows[0]["content"].ToString()), 40);
                lbnshili.CommandName = dtshili.Rows[0]["ID"].ToString();
            }
            else
                lbnshili.Visible = false;
            rpshili.DataSource = dtshili;
            rpshili.ItemDataBound += new RepeaterItemEventHandler(rpshili_ItemDataBound);
            rpshili.DataBind();

            //专家解读
            DataTable dtjzjd = man.GetTopNews("5", "3");
            if (dtjzjd.Rows.Count > 0)
            {
                jiedutil.Text = dtjzjd.Rows[0]["title"].ToString();
                lbljieducon.Text = Substr(NoHTML(dtjzjd.Rows[0]["content"].ToString().Trim()), 40);
                lbnzjjd.CommandName = dtjzjd.Rows[0]["ID"].ToString();
            }

            //党报社评
            DataTable dtdbsp = man.GetTopNews("6", "3");
            if (dtdbsp.Rows.Count > 0)
            {
                lbldbsp.Text = dtdbsp.Rows[0]["title"].ToString();
                lbldbspcon.Text = Substr(NoHTML(dtdbsp.Rows[0]["content"].ToString().Trim()), 40);
                lbndbsp.CommandName = dtdbsp.Rows[0]["ID"].ToString();
            }

            //他山之石
            DataTable dttszs = man.GetTopNews("7", "6");
            rptszs.DataSource = dttszs;
            rptszs.DataBind();

            //留言板
            DataTable dtmg = man.GetTop5MessageList();
            rpmglist.DataSource = dtmg;
            rpmglist.DataBind();
        }

        public static string NoHTML(string Htmlstring)
        {
            //删除脚本 
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML 
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        void rpshili_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                e.Item.Visible = false;
            }
        }

        void rpjucuo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                e.Item.Visible = false;
            }
        }

        void rppeo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                e.Item.Visible = false;
            }
        }

        public string Hiddenfirst( int indexstr)
        {
            if (indexstr == 0)
                return "none";
            else
                return "inline-block";
        }

        protected string Substr(string str, int len)
        {
            if (str.Length > len)
            {
                return str.Substring(0, len);
            }
            else
                return str ;
        }

        protected void lbnpeo_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("News_detail.aspx?nid=" + e.CommandName);
        }

        protected void lbnjucuo_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("News_detail.aspx?nid=" + e.CommandName);
        }

        protected void lbnshili_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("News_detail.aspx?nid=" + e.CommandName);
        }

        protected void lbnzjjd_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("News_detail.aspx?nid=" + e.CommandName);
        }

        protected void lbndbsp_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("News_detail.aspx?nid=" + e.CommandName);
        }


        private void OK_Click(object sender, System.EventArgs e)
        {
            
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