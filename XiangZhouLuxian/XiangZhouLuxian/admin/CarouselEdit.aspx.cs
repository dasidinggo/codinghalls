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
    public partial class CarouselEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isupdate.Value = Request.QueryString["isupdate"];
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
                dtb = man.GetCarouselById(hidnid.Value);
                if (dtb.Rows.Count > 0)
                {
                    hidnid.Value = dtb.Rows[0]["id"].ToString();
                    txttitle.Text = dtb.Rows[0]["title"].ToString();
                    txthrefstr.Text = dtb.Rows[0]["hrefstr"].ToString();
                    hidpicurl.Value = dtb.Rows[0]["picurl"].ToString();
                    Img1.Src = "products/" + dtb.Rows[0]["picurl"].ToString();
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
                if (man.AddCarousel(txttitle.Text,hidpicurl.Value,"http://" + txthrefstr.Text.Replace("http://","")))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('新增成功！'); window.parent.location.href='Carousel_list.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Add", "alert('新增成功！'); window.parent.location.href='Carousel_list.aspx'", true);
                }
            }
            else
            {
                if (man.UpdateCarousel(txttitle.Text, hidpicurl.Value, "http://" + txthrefstr.Text.Replace("http://", ""), hidnid.Value))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Update", "alert('修改成功！'); window.parent.location.href='Carousel_list.aspx'", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Update", "alert('修改成功！'); window.parent.location.href='Carousel_list.aspx'", true);
                }
            }
        }

    }
}