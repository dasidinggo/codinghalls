using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace XiangZhouLuxian.admin
{
    public partial class Profile : System.Web.UI.Page
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
            DataTable dt = man.GetProfile();
            if (dt.Rows.Count > 0)
            {
                txtcontent.Text = dt.Rows[0]["content"].ToString();
                txttitle.Text = dt.Rows[0]["title"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            if (Session["user"] != null)
            {
                if (man.SaveProfile(txtcontent.Text,txttitle.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "del", "$('#divcon1').css({display:'none'});alert('保存成功！');", true);
                }
            }
            else
            {

            }
        }
    }
}