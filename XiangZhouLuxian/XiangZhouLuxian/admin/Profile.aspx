<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="XiangZhouLuxian.admin.Profile" %>

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
    		    KindEditor.ready(function (K) {
    		        var editor1 = K.create('#txtcontent', {
    		            cssPath: 'kindeditor-4.1.10/plugins/code/prettify.css',
    		            uploadJson: 'kindeditor-4.1.10/asp.net/upload_json.ashx',
    		            fileManagerJson: 'kindeditor-4.1.10/asp.net/file_manager_json.ashx',
    		            allowFileManager: true,
    		            afterCreate: function () {
    		                var self = this;
    		                K.ctrl(document, 13, function () {
    		                    self.sync();
    		                    K('form[name=form1]')[0].submit();
    		                });
    		                K.ctrl(self.edit.doc, 13, function () {
    		                    self.sync();
    		                    K('form[name=form1]')[0].submit();
    		                });
    		            }
    		        });
    		        prettyPrint();
    		    });
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="sonpage" id="divcon1">
        <table class="introtb">
            <tr>
                <td width="60">标题：</td>
                <td><asp:TextBox ID="txttitle" CssClass="aborder tiltxt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top">内容：</td>
                <td><asp:TextBox ID="txtcontent" CssClass="kindeditor" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center"> <asp:Button ID="btnSave" runat="server" CssClass="btnblock" Text="保存" OnClientClick="" onclick="btnSave_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
