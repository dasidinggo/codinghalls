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
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isupdate.Value = Request.QueryString["isupdate"];
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
                dtb = man.GetNewsById(hidnid.Value);
                if (dtb.Rows.Count > 0)
                {
                    hidnid.Value = dtb.Rows[0]["id"].ToString();
                    txttitle.Text = dtb.Rows[0]["title"].ToString();
                    txtremark.Text = dtb.Rows[0]["remark"].ToString();
                    txtcontent.Text = dtb.Rows[0]["content"].ToString();
                    txttimes.Text = dtb.Rows[0]["times"].ToString();
                    txtauthor.Text = dtb.Rows[0]["Author"].ToString();
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            if (isupdate.Value == "0")
            {
                if (man.AddNews(txtcontent.Text, txttitle.Text, hidkind.Value, txttimes.Text , txtauthor.Text, txtremark.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('新增成功！'); window.parent.location.href='News_list.aspx?kind=" + hidkind.Value + "'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('新增成功！'); window.parent.location.href='News_list.aspx?kind=" + hidkind.Value + "'", true);
                }
            }
            else
            {
                if (man.SaveNews(txtcontent.Text, txttitle.Text, hidkind.Value, hidnid.Value, txttimes.Text, txtauthor.Text, txtremark.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Update", "alert('新增成功！'); window.parent.location.href='News_list.aspx?kind=" + hidkind.Value + "'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Update", "alert('新增成功！'); window.parent.location.href='News_list.aspx?kind=" + hidkind.Value + "'", true);
                }
            }
        }

    }
}