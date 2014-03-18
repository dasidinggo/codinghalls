<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_list.aspx.cs" Inherits="XiangZhouLuxian.Message_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>香洲群众路线网</title>
    <link href="style/style.css" rel="stylesheet" />
    <link href="style/pagingstyle.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.10.2.min.js" type="text/javascript"> </script>
    <script type="text/javascript">
        $(function () {
            $(".pljdul li:last").css({ border: "none" });
            $(".menuul li:last").css({ background: "none" });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">

<div class="banner"></div>
<div class="menu">
	<div class="menubox">
    <ul class="menuul">
    	<li><a href="index.aspx">首 页</a></li>
        <li><a href="News_list.aspx?kind=0">上级精神</a></li>
        <li><a href="News_list.aspx?kind=1">本地动态</a></li>
        <li><a href="News_list.aspx?kind=234">案例展示</a></li>
        <li><a href="News_list.aspx?kind=56">评论解读</a></li>
        <li><a href="News_list.aspx?kind=7">他山之石</a></li>
        <li><a href="index.aspx#voice">网友声音</a></li>
    </ul>
    </div>
</div>
<div class="newslist">
	<div class="listleft">
    	<div class="listtitle">
        	<a href="index.aspx">香洲群众路线网</a> &nbsp; > &nbsp; 群众有话说
        </div>
        <div class="messagelist">
        	<table cellpadding="0" cellspacing="0">
            <asp:Repeater ID="rpmessagelist" runat="server">
                <ItemTemplate>
                <tr class="mestiltr">
                	<td class="messtiltd" width="55%"><%#Eval("title") %></td>
                    <td class="messremark"><label style=" font-size:12px;" id='m<%#Eval("ID") %>'>网友</label>：<%#Eval("mname") %> &nbsp; &nbsp; &nbsp; <%#Eval("datetimes") %></td>
                </tr>
                <tr>
                	<td colspan="2" class="messcontd"><%#Eval("content") %></td>
                </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table>
            <div style=" width:500px; padding-top:10px; margin:0 auto;"><webdiyer:AspNetPager ID="AspNetPager1" 
                CssClass="paginator" CustomInfoClass="paginator2" 
                    CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条 &nbsp; &nbsp; &nbsp;"  
                    CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
            FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="15" 
                    PrevPageText="上一页"  ShowCustomInfoSection="Left" 
            ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  
                    CustomInfoTextAlign="Left" LayoutType="Table" NumericButtonCount="5" 
                CustomInfoSectionWidth="30%"  >
            </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    <div class="listright">
    	<table class="righttb" cellpadding="0" cellspacing="0">
        	<tr>
            	<td class="rtiltd">上级精神<a class="moreaf" style="margin-left:140px;" href="News_list.aspx?kind=0">更多》</a></td>
            </tr>
            <tr>
            	<td class="rcontd" valign="top">
                	<ul class="righttbul">
                    <asp:Repeater ID="rpsjjs" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Substr(Eval("title").ToString().Trim(),17)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
            </tr>
        </table>
        <table class="righttb" cellpadding="0" cellspacing="0">
        	<tr>
            	<td class="rtiltd">本地动态<a class="moreaf" style="margin-left:140px;" href="News_list.aspx?kind=1">更多》</a></td>
            </tr>
            <tr>
            	<td class="rcontd" valign="top">
                	<ul class="righttbul">
                    	<asp:Repeater ID="rpbddt" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Substr(Eval("title").ToString().Trim(),17)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
            </tr>
        </table>
        <table class="righttb" cellpadding="0" cellspacing="0">
        	<tr>
            	<td class="rtiltd">案例展示<a class="moreaf" style="margin-left:140px;" href="News_list.aspx?kind=234">更多》</a></td>
            </tr>
            <tr>
            	<td class="rcontd" valign="top">
                	<ul class="righttbul">
                    <asp:Repeater ID="rpanzs" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Substr(Eval("title").ToString().Trim(),17)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
            </tr>
        </table>
        <table class="righttb" cellpadding="0" cellspacing="0">
        	<tr>
            	<td class="rtiltd">他山之石<a class="moreaf" style="margin-left:140px;" href="News_list.aspx?kind=7">更多》</a></td>
            </tr>
            <tr>
            	<td class="rcontd" valign="top">
                	<ul class="righttbul">
                    <asp:Repeater ID="rptszs" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Substr(Eval("title").ToString().Trim(),17)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="clear"></div>
<div class="foot">
	<div class="footbox">
    	香洲群众路线网版权所有，未经书面授权禁止使用<br />
Copyright ©1997-2014 by www.xzqzlx.com.cn. all rights reserved
    </div>
</div>

    </form>
</body>
</html>
