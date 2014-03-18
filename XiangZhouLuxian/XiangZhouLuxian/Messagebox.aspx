<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messagebox.aspx.cs" Inherits="XiangZhouLuxian.Messagebox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" />
    <script src="js/jquery-1.10.2.min.js" type="text/javascript"> </script>
    <script type="text/javascript" language="Javascript">

        function f_refreshtype() {
            var Image1 = document.getElementById("IMGCheckCode");
            if (Image1 != null) {
                Image1.src = Image1.src + "?";
            }
        }

        function checkbox1() {
            if ($("#messagename").val() == "") {
                alert("请填写姓名！");
                $("#messagename").focus();
                return false;
            }
            if ($("#messagetil").val() == "") {
                alert("请填写主题！");
                $("#messagetil").focus();
                return false;
            }
            if ($("#messagecon").val() == "请遵守社区公约") {
                alert("请填写内容！");
                $("#messagecon").focus();
                return false;
            }
            if ($("#txtcheckcode").val() == "") {
                alert("请填写验证码！");
                $("#txtcheckcode").focus();
                return false;
            }
            return true;
        }

        function checkbox2() {
            if ($("#txtmname").val() == "") {
                alert("请填写您的昵称！");
                $("#txtmname").focus();
                return false;
            }
            if ($("#txtmtitle").val() == "") {
                alert("请填写主题！");
                $("#txtmtitle").focus();
                return false;
            }
            if ($("#txtmcontent").val() == "") {
                alert("请填写内容！");
                $("#txtmcontent").focus();
                return false;
            }
            return true;
        }

        function clearcon() {
            if ($("#messagecon").val() == "请遵守社区公约")
                $("#messagecon").val("");
        }

        function resetcon() {
            if ($("#messagecon").val() == "")
                $("#messagecon").val("请遵守社区公约");

        }
        function cleantxt() {
            $("#messagename").val("");
            $("#messagetil").val("");
            $("#messagecon").val("");
            $("#txtcheckcode").val("");
            $("#txtmname").val("");
            $("#txtmtitle").val("");
            $("#txtmcontent").val("");
        }

        $(function () {
            if ($("#hidtype").val() == "1")
                $("#mesbox1").css({ display: "block" });
            else
                $("#mesbox2").css({ display: "block" });
        });
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidtype" runat="server" Value="1" />
    <table id="mesbox1" class="messagetb" cellpadding="0" cellspacing="0" style=" display:none;">
                <tr >
                    <td style="padding-left:10px; width:190px;">您的昵称：<asp:TextBox ID="messagename" CssClass="txtbox" runat="server" Width="80"></asp:TextBox></td>
                    <td >主题：<asp:TextBox ID="messagetil" CssClass="txtbox" runat="server" Width="180"></asp:TextBox></td>
                </tr>
                <tr>
                	<td height="8" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td style="padding-left:10px; padding-right:10px;" colspan="2">
                        <asp:TextBox ID="messagecon" onfocus="clearcon()" onblur="resetcon()" runat="server" CssClass="mesagearea" TextMode="MultiLine">请遵守社区公约</asp:TextBox>
                    </td>
                </tr>
                <tr>
                	<td height="8" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left:10px; font-weight:normal;">验证码：<asp:TextBox ID="txtcheckcode" CssClass="txtbox" runat="server" Width="80"></asp:TextBox> &nbsp; &nbsp; 
                    <asp:Image ID="IMGCheckCode" runat="server" style=" vertical-align:middle;" ImageUrl="GenerateCheckCode.aspx" /> &nbsp; &nbsp; <a onclick="f_refreshtype()" title="看不清楚?点击获取新的校验码!" class="swaparh" href="#1">换一张</a> 
                        <asp:Button ID="btnsubmit" runat="server" CssClass="submitbtn" OnClientClick="return checkbox1()" onclick="btnsubmit_Click"/><asp:HiddenField ID="hidcheckc" runat="server" /></td>
                </tr>
            </table>

        <table id="mesbox2" cellpadding="0" cellspacing="0" style=" display:none;" class="messagetb2">
            <tr>
                <td width="40%" style=" padding-left:22px; padding-top:20px; height:40px; line-height:40px;"><img src="images/dudaotitle.png" /></td>
                <td width="60%" style=" padding-top:20px; height:40px; line-height:40px; text-align:right; padding-right:20px;"><a href="#1" class="delbtn" onclick="parent.closemak();"></a></td>
            </tr>
            <tr>
                <td style=" padding-left:50px;padding-top:10px; *padding-top:0px;">收件人：<input type="text" Class="txtbox" style=" color:#666; text-align:center; width:80px; padding:0;" readonly="readonly" value="督导组" /></td>
                <td style="text-align:right; padding-top:10px; *padding-top:0px; padding-right:50px;">您的昵称：<asp:TextBox CssClass="txtbox" ID="txtmname" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style=" padding-left:50px;" colspan="2">主题：<asp:TextBox CssClass="txtbox" style=" width:362px;" ID="txtmtitle" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td height="150" valign="top" colspan="2" style=" padding:0; padding-left:50px; padding-right:40px;"><asp:TextBox ID="txtmcontent" CssClass="messagearea2" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" colspan="2" style=" text-align:right; padding-right:50px;">
                    <asp:Button ID="sendbtn" runat="server" CssClass="btnsend" OnClientClick="checkbox2()" onclick="sendbtn_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
