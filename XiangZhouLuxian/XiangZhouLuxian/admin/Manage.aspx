<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" validateRequest="false" Inherits="XiangZhouLuxian.admin.Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站管理后台</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/JScript.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.unsela').click(function () {
                $('.unsela').css({ color: "#555555" });
                $(this).css({ color: "#ff3300" });
            });
        });
    </script>
    <style type="text/css">
        body { background:url(images/topbg.png) repeat-x #747474;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
	        <img src="images/adlogo.png" alt="Logo" />
        </div>
        <div class="navi">
            <span style=" float:left; padding-left:30px;">用户名：<asp:Label ID="lbluser" runat="server"></asp:Label></span>
	        <a href="../index.aspx">网站首页</a>&nbsp; &nbsp;
            <asp:LinkButton ID="lbnexit" runat="server" onclick="lbnexit_Click">安全退出</asp:LinkButton>
        </div>
        
        <div class="content">
        <div style=" width:1200px;">
	        <div class="left">
    	        <table>
                    <asp:Repeater ID="rpMenu" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="menu"><a style=' display:<%#Getdisplay(Eval("linktype").ToString()) %>' class="unsela" href="<%#Eval("urlstr") %>" target="iframe1"><%#Eval("MenuName") %></a><span style='display:<%#Getdisplay((int.Parse(Eval("linktype").ToString())-1).ToString()) %>'><%#Eval("MenuName") %></span><asp:HiddenField ID="hidmid" runat="server" Value='<%#Eval("Mid") %>' /></td>
                            </tr>
                            <asp:Repeater ID="rpSonM" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="sonM"><a href='<%#Eval("urlstr") %>' target="iframe1" class="unsela" onclick=""><%#Eval("MenuName")%></a></td>
                                </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="right">
    	        <iframe id="iframe1" name="iframe1" style=" height:700px; width:850px; border:none; background:#fff; overflow:hidden; " src=""></iframe>
            </div>
        </div>
        </div>
        <div class="bottom"></div>
    </form>
</body>
</html>
