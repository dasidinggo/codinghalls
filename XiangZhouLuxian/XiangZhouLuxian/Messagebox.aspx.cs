using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace XiangZhouLuxian
{
    public partial class Messagebox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hidtype.Value = Request.QueryString["kind"];
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (CheckCodeSame(txtcheckcode.Text.Trim()))
            {
                Manager man = new Manager();
                if (man.AddMessage(messagename.Text, messagetil.Text, messagecon.Text, "1"))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "AddM1", "alert('留言成功！');cleantxt();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "ErrM1", "alert('留言失败！');cleantxt();", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "ErrM1", "alert('验证码错误！请重新输入！！');", true);
        }


        /// <summary>
        /// 判断输入的校验码是否正确
        /// </summary>
        /// <param name="checkCode"></param>
        /// <returns></returns>
        public static bool CheckCodeSame(string checkCode)
        {
            bool bSame = false; ;

            if (HttpContext.Current.Session["CheckCode"] != null)
            {
                if (checkCode.ToUpper() == HttpContext.Current.Session["CheckCode"].ToString().ToUpper())
                {
                    bSame = true;
                }
            }
            return bSame;
        }

        protected void sendbtn_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            if (man.AddMessage(txtmname.Text, txtmtitle.Text, txtmcontent.Text, "2"))
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "AddM2", "alert('发送成功！');cleantxt();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "ErrM2", "alert('发送失败！');cleantxt();", true);
            }
        }
    }
}