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
    public partial class Pwd_Man : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["user"] + ""))
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('您的帐号已过期，请重新登录！'); window.parent.location.href='login.aspx'", true);
            }
            else
                lbluser.Text = Session["user"].ToString();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string user = lbluser.Text;
            string pwd = txtnpwd.Text;
            string opwd = txtopwd.Text;
            Manager man = new Manager();
            DataTable dt = man.login(user, opwd);
            if (dt.Rows.Count > 0)
            {
                if (man.UpdatePwd(user, pwd))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "updatepwd", "alert('修改成功！');", true);
                    return;
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(string), "updatepwd", "alert('修改失敗！');", true);
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "updatepwd", "alert('密碼錯誤！');", true);
                return;
            }
        }
    }
}