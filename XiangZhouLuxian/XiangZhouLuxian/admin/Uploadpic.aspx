﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploadpic.aspx.cs" Inherits="XiangZhouLuxian.admin.Uploadpic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function posturl(str) {
            parent.getPicUrl(str);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="upfilename" runat="server" Value="33" />
        <asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp; 
        <asp:Button ID="btnupld" runat="server" onclick="btnupld_Click" Text="上传" />
    </div>
    </form>
</body>
</html>
