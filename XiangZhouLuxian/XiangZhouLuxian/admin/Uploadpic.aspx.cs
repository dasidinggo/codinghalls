using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XiangZhouLuxian.admin
{
    public partial class Uploadpic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupld_Click(object sender, EventArgs e)
        {
            bool fileok = false;
            string fileExtension = "";
            string filename = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff").Replace(" ", "").Replace(":", "").Replace("-", "");
            if (FileUpload1.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowExtension = { ".jpg", ".gif", ".png" };
                int j = 0;
                for (int i = 0; i < allowExtension.Length; i++)
                {
                    if (fileExtension == allowExtension[i])
                    {
                        fileok = true;
                    }
                    else
                    {
                        j++;
                    }
                }
                if (j >= allowExtension.Length)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "del", "alert('文件格式不正确！');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "del", "alert('请选择要上传的图片！');", true);
                return;
            }
            if (fileok)
            {
                FileUpload1.SaveAs(HttpContext.Current.Server.MapPath("products\\" + filename + fileExtension));
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "del", "alert('上传成功！');posturl('" + filename + fileExtension + "')", true);
                upfilename.Value = filename + fileExtension;
            }
        }
    }
}