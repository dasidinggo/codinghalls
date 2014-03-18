<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XiangZhouLuxian.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站管理后台</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/JScript.js"></script>
    <style type="text/css">
        *{ border:none;}
    </style>
</head>
<body style="background:#000;" onload="if($('#txtuser').val().length ==0 )$('#txtuser').focus(); else $('#txtpwd').focus();">
    <form id="form1" runat="server">
    <div class="loginform">
        <table class="lgtb">
    	    <tr>
        	    <td><asp:TextBox ID="txtuser" runat="server" CssClass="txt" autocomplete='off'></asp:TextBox></td>
            </tr>
            <tr>
        	    <td><asp:TextBox TextMode="Password" runat="server" ID="txtpwd" CssClass="txt"></asp:TextBox></td>
            </tr>
            <tr>
        	    <td align="left"><asp:LinkButton ID="lnlogin" runat="server" CssClass="btnlogin" OnClientClick="return checklogin()"
                        onclick="lnlogin_Click"></asp:LinkButton> &nbsp; <asp:LinkButton ID="lbncancel" runat="server" CssClass="btncancel"></asp:LinkButton></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
