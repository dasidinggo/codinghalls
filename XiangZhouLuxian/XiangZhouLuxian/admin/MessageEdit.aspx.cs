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
    public partial class MessageEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidkind.Value = Request.QueryString["kind"];
                hidnid.Value = Request.QueryString["id"];
                bind();
            }
        }

        protected void bind()
        {
            if (!string.IsNullOrEmpty(hidnid.Value))
            {
                Manager man = new Manager();
                DataTable dtb = new DataTable();
                dtb = man.GetMessageById(hidnid.Value);
                if (dtb.Rows.Count > 0)
                {
                    lbltitle.Text = dtb.Rows[0]["title"].ToString();
                    lblcontent.Text = dtb.Rows[0]["content"].ToString();
                    lblmname.Text = dtb.Rows[0]["mname"].ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            if (man.AuditMessage(hidnid.Value, "1"))
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('处理完成！'); window.parent.location.href='Message_list.aspx?kind=" + hidkind.Value + "'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('处理失败！'); window.parent.location.href='Message_list.aspx?kind=" + hidkind.Value + "'", true);
            }
        }

        protected void BtnRefusal_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            if (man.AuditMessage(hidnid.Value, "2"))
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('处理完成！'); window.parent.location.href='Message_list.aspx?kind=" + hidkind.Value + "'", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('处理失败！'); window.parent.location.href='Message_list.aspx?kind=" + hidkind.Value + "'", true);
            }
        }

    }
}