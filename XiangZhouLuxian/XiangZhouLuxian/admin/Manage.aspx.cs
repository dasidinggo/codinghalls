using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace XiangZhouLuxian.admin
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkonline();
            Manager man = new Manager();
            rpMenu.DataSource = man.GetMenuList();
            rpMenu.ItemDataBound += new RepeaterItemEventHandler(rpMenu_ItemDataBound);
            rpMenu.DataBind();
            lbluser.Text = Session["user"].ToString();
        }

        protected void rpMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Manager man = new Manager();
                string pid = (e.Item.FindControl("hidmid") as HiddenField).Value;
                Repeater rpt = e.Item.FindControl("rpSonM") as Repeater;
                rpt.DataSource = man.GetSonM(pid);
                rpt.DataBind();
            }
        }

        protected void checkonline()
        {
            if (string.IsNullOrEmpty(Session["user"] + ""))
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void lbnexit_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("login.aspx");
        }

        public string Getdisplay(string type)
        {
            if (type == "1")
                return "";
            else
                return "none";
        }


    }
}