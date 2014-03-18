<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageEdit.aspx.cs" Inherits="XiangZhouLuxian.admin.MessageEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="kindeditor-4.1.10/themes/default/default.css" />
    <link rel="stylesheet" href="kindeditor-4.1.10/plugins/code/prettify.css" />	
    <script type="text/javascript" charset="utf-8" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script type="text/javascript">
        $(function () {
            if ($("#hidkind").val() == "2") {
                $("#BtnRefusal").css({ display: "none" });
                $("#btnSave").css({ display: "none" });
            }
        })
    </script>
</head>
<body style=" overflow:hidden;">
    <form id="form1" runat="server">
    <div>
                <table cellpadding="0" cellspacing="0" style="width:790px; border:solid 1px; margin:5px; padding:0;">
                    <tr class="headtr">
                        <td class="headtd"><asp:HiddenField ID="hidnid" runat="server" /><asp:HiddenField ID="isupdate" Value="0" runat="server" /><asp:HiddenField ID="hidkind" Value="0" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="text-align:left; line-height:30px; font-size:14px; padding-left:18px;">标题：<asp:Label ID="lbltitle" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align:left; line-height:30px; font-size:12px; padding-left:18px;">姓名：<asp:Label ID="lblmname" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align:center; line-height:10px; font-size:14px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" style="text-align:left; padding-left:18px;padding-right:18px; height:393px;">
                        <asp:TextBox ID="lblcontent" runat="server" TextMode="MultiLine" style=" padding:8px;" ReadOnly="true" Width="734" Height="374"></asp:TextBox>
                        <%--<asp:Label ID="lblcontent" runat="server"></asp:Label>--%>
                    </td>
                    </tr>
                    <tr>
                        <td style="text-align:center; line-height:10px; font-size:14px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:center; height:30px; line-height:30px; padding-top:8px; padding-bottom:8px;"><asp:Button ID="btnSave" class="btnblock" runat="server" Text="审核通过" OnClientClick="" onclick="btnSave_Click" />&nbsp; &nbsp;<asp:Button 
                        ID="BtnRefusal" class="btnblock" runat="server" Text="审核不通过" OnClientClick="" 
                        onclick="BtnRefusal_Click" />&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" class="btnblock" Text="关闭" OnClientClick="parent.closediv();" /></td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
