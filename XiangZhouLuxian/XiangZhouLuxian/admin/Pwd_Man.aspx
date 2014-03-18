<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pwd_Man.aspx.cs" Inherits="XiangZhouLuxian.admin.Pwd_Man" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/JScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="sonpage">
        <table class="introtb">
            <tr>
                <td align="right" width="100">用户名：</td>
                <td><asp:Label ID="lbluser" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">旧密码：</td>
                <td><asp:TextBox ID="txtopwd" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">新密码：</td>
                <td ><asp:TextBox ID="txtnpwd" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">密码确认：</td>
                <td><asp:TextBox ID="txtnpwd2" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center"><asp:LinkButton ID="btnOk" OnClientClick="return checkpwdman()" CssClass="btnblock" runat="server" onclick="btnOk_Click">保存</asp:LinkButton></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
