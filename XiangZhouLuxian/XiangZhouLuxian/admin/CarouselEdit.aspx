<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarouselEdit.aspx.cs" Inherits="XiangZhouLuxian.admin.CarouselEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/js/jquery-1.7.1.min.js"></script>
    <script language="javascript" type="text/javascript">
        function getPicUrl(str) {
            $('#Img1').attr({ src: "products/" + str });
            $('#hidpicurl').val(str);
        }
    </script>
</head>
<body style=" overflow:hidden;">
    <form id="form1" runat="server">
    <div>
                <table cellpadding="0" cellspacing="0" style="width:790px; border:solid 1px; margin:5px; padding:0;">
                <tr class="headtr">
                        <td colspan="2" class="headtd"><asp:HiddenField ID="hidnid" runat="server" /><asp:HiddenField ID="isupdate" Value="0" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:left; line-height:40px; font-size:14px; padding-left:18px;">标题：<asp:TextBox ID="txttitle" CssClass="txttil" Width="380" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:left; line-height:40px; font-size:14px; padding-left:18px;">链接：<asp:TextBox ID="txthrefstr" CssClass="txttil" Width="380" runat="server"></asp:TextBox></td>
                    </tr>
<%--                    <tr>
                        <td style="text-align:center; line-height:40px; font-size:14px;">内容</td>
                    </tr>--%>
                    <tr>
                        <td style="text-align:left; line-height:40px; font-size:14px; padding-left:18px;">图片：<asp:HiddenField ID="hidpicurl" runat="server" Value="" /></td>
                        <td><iframe id="ifarme1" src="Uploadpic.aspx" style=" margin:0; padding:0; border:none; height:30px; width:400px;"></iframe></td>
                    </tr>
                    <tr>
                        <td colspan="2" style=" text-align:center;"><img runat="server" src="" style=" width:473px; height:349px;" id="Img1" alt="" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center; height:30px; line-height:30px; padding-top:8px; padding-bottom:8px;"><asp:Button ID="btnSave" class="btnblock" runat="server" Text="保存" OnClientClick="" onclick="btnSave_Click" />&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" class="btnblock" Text="关闭" OnClientClick="parent.closediv();" /></td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
