<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsHandle.aspx.cs" Inherits="XiangZhouLuxian.admin.NewsHandle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
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
                        K('form[name=form3]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=form3]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
	</script>
</head>
<body style=" overflow:hidden;">
    <form id="form3" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" style="width:790px; border:solid 1px; margin:5px; padding:0;">
                <tr class="headtr">
                    <td class="headtd"><asp:HiddenField ID="hidnid" runat="server" /><asp:HiddenField ID="isupdate" Value="0" runat="server" /></td>
                </tr>
                <tr>
                    <td style="text-align:center; line-height:40px; font-size:18px;">标题：<asp:TextBox ID="txttitle" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:center; line-height:40px; font-size:14px;">备注内容：<asp:TextBox ID="txtremark" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:center; line-height:40px; font-size:14px;">中文内容</td>
                </tr>
                <tr>
                    <td style="text-align:center;"><asp:TextBox ID="txtcontent" CssClass="kindeditor" TextMode="MultiLine" Width="780" Height="370" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:center; height:30px; line-height:30px;"><asp:LinkButton ID="btnOk" runat="server" onclick="btnOk_Click">保存</asp:LinkButton>&nbsp; &nbsp;<a href="#1" onclick="parent.closediv();">关闭</a></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
