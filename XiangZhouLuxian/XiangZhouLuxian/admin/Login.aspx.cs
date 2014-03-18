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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnlogin_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pwd = txtpwd.Text;
            Manager man = new Manager();
            DataTable dt = man.login(user, pwd);
            if (dt.Rows.Count > 0)
            {
                Session["user"] = dt.Rows[0]["user"].ToString();
                Response.Redirect("Manage.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "loginErr", "alert('用戶密碼錯誤！');", true);
                return;
            }
        }
    }
}