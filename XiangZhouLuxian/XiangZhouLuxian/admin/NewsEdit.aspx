<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="XiangZhouLuxian.admin.NewsEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="kindeditor-4.1.10/themes/default/default.css" />
    <link rel="stylesheet" href="kindeditor-4.1.10/plugins/code/prettify.css" />
    <link type="text/css" href="js/css/jquery-ui-1.8.17.custom.css" rel="stylesheet" />
    <link type="text/css" href="js/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    
    <script type="text/javascript" charset="utf-8" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script type="text/javascript" src="js/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="js/js/jquery-ui-1.8.17.custom.min.js"></script>
	<script type="text/javascript" src="js/js/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript" src="js/js/jquery-ui-timepicker-zh-CN.js"></script>
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

        $(function () {
            $("#txttimes").datetimepicker();
            $("#txttimes").datepicker();
            $("#txttimes").timepicker();
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
                        <td style="text-align:left; line-height:40px; font-size:14px; padding-left:18px;">标题：<asp:TextBox ID="txttitle" CssClass="txttil" Width="380" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align:left; line-height:40px; font-size:14px; padding-left:18px;">作者：<asp:TextBox ID="txtauthor" CssClass="txttil" runat="server"></asp:TextBox> &nbsp; 发布时间：<asp:TextBox ID="txttimes" name="txttimes" CssClass="txttil" runat="server"></asp:TextBox> &nbsp; 来源：<asp:TextBox ID="txtremark" CssClass="txttil" runat="server"></asp:TextBox></td>
                    </tr>
<%--                    <tr>
                        <td style="text-align:center; line-height:40px; font-size:14px;">内容</td>
                    </tr>--%>
                    <tr>
                        <td style="text-align:center; padding-left:8px;"><asp:TextBox ID="txtcontent" CssClass="kindeditor" TextMode="MultiLine" Width="98%" Height="393" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align:center; height:30px; line-height:30px; padding-top:8px; padding-bottom:8px;"><asp:Button ID="btnSave" class="btnblock" runat="server" Text="保存" OnClientClick="" onclick="btnSave_Click" />&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" class="btnblock" Text="关闭" OnClientClick="parent.closediv();" /></td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
