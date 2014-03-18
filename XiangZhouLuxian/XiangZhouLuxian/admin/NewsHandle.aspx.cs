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
    public partial class NewsHandle : System.Web.UI.Page
    {
        string isupd, kindid,pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            isupd = Request.QueryString["isupdate"];
            kindid = Request.QueryString["kind"];
            pid = Request.QueryString["id"];
            bind();
        }

        protected void bind()
        {
            if (!string.IsNullOrEmpty(pid))
            {
                Manager man = new Manager();
                DataTable dtb = new DataTable();
                dtb = man.GetNewsById(pid);
                if (dtb.Rows.Count > 0)
                {
                    hidnid.Value = dtb.Rows[0]["id"].ToString();
                    txttitle.Text = dtb.Rows[0]["title"].ToString();
                    txtremark.Text = dtb.Rows[0]["remark"].ToString();
                    txtcontent.Text = dtb.Rows[0]["content"].ToString();
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            if (isupd == "0")
            {
                if (man.AddNews(txtcontent.Text, txttitle.Text, kindid, "", "", txtremark.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('新增成功！');parent.closediv();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('新增失败！');parent.closediv();", true);
                }
            }
            else
            {
                if (man.SaveNews(txtcontent.Text, txttitle.Text, kindid, hidnid.Value, "", "", txtremark.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Update", "alert('修改成功！');parent.closediv();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Update", "alert('修改失败！');parent.closediv();", true);
                }
            }
        }
    }
}