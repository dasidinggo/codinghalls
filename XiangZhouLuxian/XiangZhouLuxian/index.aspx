<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XiangZhouLuxian.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>香洲群众路线网</title>
    <link href="style/style.css" rel="stylesheet" />
    <script src="js/jquery-1.4a2.min.js" type="text/javascript"></script>
    <script src="js/jquery.KinSlideshow-1.2.1.min.js" type="text/javascript"></script>
    <script src="js/tab1.js" type="text/javascript"></script>
    <script src="js/jcarousellite_1.0.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".pljdul li:last").css({ border: "none" });
            $(".menuul li:last").css({ background: "none" });
            $("#swat2").css({ background: "url(images/swatbtn.png) left top no-repeat" });
            //$("#scroolbar").Marquee({ line: 1, speed: 100, timer: 2000, left: "pbtnright", right: "pbtnleft" });
        });

        function swatact(i) {
            $(".swtcc").css({ display: "none" });
            $("#swatbox" + i).css({ display: "block"});
            $(".swatbtn").css({ background: "url(images/swatbtn1.png) left top no-repeat" });
            $("#swat" + i).css({ background: "url(images/swatbtn.png) left top no-repeat" });
        }
        $(function () {
            $("#KinSlideshow").KinSlideshow({
                titleFont: { TitleFont_size: 14,TitleFont_lineheight:30 }
            });
        })
    </script>
    <script type="text/javascript" language="Javascript">
        function showmak() {
            $("#ddxx").css({ visibility: "visible" });
            $("#munmask").css({ visibility: "visible" });
            //$("body").css({ overflow: "hidden" });
        }

        function closemak() {
            $("#ddxx").css({ visibility: "hidden" });
            $("#munmask").css({ visibility: "hidden" });
            $("body").css({ overflow: "auto" });
        }


        function f_refreshtype() {
            var Image1 = document.getElementById("IMGCheckCode");
            if (Image1 != null) {
                Image1.src = Image1.src + "?";
            }
        }

        function checkimgcode() {
            //return false;
            var str = $("#txtcheckcode").val();
            $.ajax({
                //要用post方式
                type: "Post",
                //方法所在页面和方法名
                url: "index.aspx/CheckCodeSame",
                data: "{'str':'" + str + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容
                    var rel = data.d;
                    if (rel == "N") {
                        alert("验证码错误！请重新输入！！");
                        return false;
                    }
                    else
                        return true;
                },
                error: function (err) {
                    return false;
                }
            });
            
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
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
<div class="mainbox">
	<div class="content">
        <table class="toptb1">
            <tr>
                <td rowspan="2" style="padding-top:3px; padding-right:15px;">
                <div id="KinSlideshow"  style="visibility:hidden;">
                <asp:Repeater ID="rpcarlist" runat="server">
                    <ItemTemplate>
                  	    <a href='<%#Eval("hrefstr") %>' target="_blank"><img src='admin/products/<%#Eval("picurl")%>' width="473px" alt='<%#Eval("title") %>' height="349px"/></a>
                    </ItemTemplate>
                </asp:Repeater>
                </div>
                
                </td>
                <td class="yjiantil" valign="top"><span>《关于创新群众工作方法解决信访突出问题意见》</span><p>一、着力从源头上预防和减少信访问题发生（一）加大保障和改善民生力度。二、进一步畅通和规范群众诉求表达渠道（五）健全... </p></td>
            </tr>
            <tr>
                <td valign="top">
                <div class="benditd" >
                	<span class="bendititle">本地动态<a class="moreaf" href="News_list.aspx?kind=1">更多》</a></span><br />
                	<ul class="bendiul">
                    <asp:Repeater ID="rpbddt" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Substr(Eval("title").ToString(),28)%></a><%#convdate(Eval("times").ToString())%></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </div>
                </td>
            </tr>
        </table>
        <table style="margin-top:15px;">
            <tr>
                <td>
                <div class="sjjstd" >
                	<span class="sjjstitle">上级精神<a class="moreaf" style="margin-left:340px;" href="News_list.aspx?kind=0">更多》</a></span><br />
                	<ul class="sjjsul">
                    <asp:Repeater ID="rpsjjs" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Substr(Eval("title").ToString(),25)%></a><%#convdate(Eval("times").ToString())%></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </div>
                </td>
                <td>
                	<div class="swatbox">
                    	<div class="swatil">
                        	<a class="swatbtn" id="swat1" onmouseover="swatact(1)" href="#1">指导思想</a><a class="swatbtn" id="swat2" onmouseover="swatact(2)" href="#1">目标要求</a><a class="swatbtn" id="swat3" style="margin-right:0px;" onmouseover="swatact(3)" href="#1">总体安排</a>
                        </div>
                        <div id="swatbox1" class="swtcc" style="display:none;">
				        <ul><li><img width="508" height="183" border="0" src="images/swaimg1.png"></li>
				        </ul>
				        </div>

				        <div id="swatbox2" class="swtcc" style=" overflow: hidden; position: relative; z-index: 2; left: 0px;top:0px; width: 508px; display:block;">
				        <div id="LeftBotton01" class="LeftBotton01"><img width="22" height="38" alt="" style="cursor:pointer;" src="images/zuo.png"></div>

				        <ul style="margin: 0px; padding: 0px; position: relative; list-style-type: none; z-index: 1; width: 3955px; left: -508px;">		
				        <li style="overflow: hidden; float: left; width: 508px; height: 183px;"><img width="508" height="183" border="0" src="images/swaimg2.png"></li>
				        <li style="overflow: hidden; float: left; width: 508px; height: 183px;"><img width="508" height="183" border="0" src="images/swaimg3.png"></li>
				        <li style="overflow: hidden; float: left; width: 508px; height: 183px;"><img width="508" height="183" border="0" src="images/swaimg4.png"></li>
				        <li style="overflow: hidden; float: left; width: 508px; height: 183px;"><img width="508" height="183" border="0" src="images/swaimg5.png"></li>
				        <li style="overflow: hidden; float: left; width: 508px; height: 183px;"><img width="508" height="183" border="0" src="images/swaimg6.png"></li>
				        </ul>
				
				        <div id="RightBotton01" class="RightBotton01"><img width="22" height="38" alt="" style="cursor:pointer;" src="images/you.png"></div>
				        </div>

				        <div id="swatbox3" class="swtcc" style="display: none;">
				        <ul><li><img width="508" height="183" border="0" src="images/swaimg7.png"></li>
				        </ul>
				        </div>
                        <%--<div class="swatcon" id="swatbox1" style="display:block;">
                        	<img src="images/swaimg1.png" />
                        </div>
                        <div class="swatcon" id="swatbox2" style="1display:block;">
                        	<a href="#1" id="pbtnleft" class="pbtnleft"></a>
                        	<div id="scroolbar" style="visibility: visible; overflow: hidden; position: relative; z-index: 2; left: 0px;top:0px; width: 508px; display:block;">
                            <ul style="margin: 0px; padding: 0px; position: relative; list-style-type: none; z-index: 1; width: 3955px; left: -705px;">
                            	<li style="overflow:hidden; float:left; width:508px; height:183px;"><img src="images/swaimg2.png" /></li>
                                <li style="overflow:hidden; float:left; width:508px; height:183px;"><img src="images/swaimg3.png" /></li>
                                <li style="overflow:hidden; float:left; width:508px; height:183px;"><img src="images/swaimg4.png" /></li>
                                <li style="overflow:hidden; float:left; width:508px; height:183px;"><img src="images/swaimg5.png" /></li>
                                <li style="overflow:hidden; float:left; width:508px; height:183px;"><img src="images/swaimg6.png" /></li>
                            </ul></div>
                            <a href="#1" id="pbtnright" class="pbtnright"></a>
                        </div>
                        <div class="swatcon" id="swatbox3">
                        	<img src="images/swaimg7.png" />
                        </div>--%>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="case">
    	<div class="casetitle"></div>
        <div class="casebox">
        <table>
        	<tr>
            	<td class="casetd" valign="top"><span class="casetil">典型人物<a class="moreaf" style="margin-left:170px;" href="News_list.aspx?kind=2">更多》</a></span><br />
                	<strong class="caseston"><asp:Label ID="lblpeo" runat="server"></asp:Label></strong>
                    <asp:Label ID="lblpeocon" CssClass="casedecon" runat="server"></asp:Label>
                    <asp:LinkButton ID="lbnpeo" runat="server" CommandName="" CssClass="detahr" 
                        Text="【详细】" oncommand="lbnpeo_Command"></asp:LinkButton><br />
                    <ul class="caseul">
                    <asp:Repeater ID="rppeo" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Eval("title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
                <td class="casetd" valign="top"><span class="casetil">典型举措<a class="moreaf" style="margin-left:170px;" href="News_list.aspx?kind=3">更多》</a></span><br />
                	<strong class="caseston"><asp:Label ID="lbljucuo" runat="server"></asp:Label></strong><br />
                    <asp:Label ID="lbljccon" CssClass="casedecon" runat="server"></asp:Label>
                    <asp:LinkButton ID="lbnjucuo" runat="server" CommandName="" CssClass="detahr" 
                        Text="【详细】" oncommand="lbnjucuo_Command"></asp:LinkButton><br />
                    <ul class="caseul">
                    <asp:Repeater ID="rpjucuo" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Eval("title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
                <td class="casetd" valign="top" style="border:none;"><span class="casetil">典型事例<a class="moreaf" style="margin-left:170px;" href="News_list.aspx?kind=4">更多》</a></span><br />
                	<strong class="caseston"><asp:Label ID="lblshili" runat="server"></asp:Label></strong><br />
                    <asp:Label ID="lblshicon" CssClass="casedecon" runat="server"></asp:Label>
                    <asp:LinkButton ID="lbnshili" runat="server" CommandName="" CssClass="detahr" 
                        Text="【详细】" oncommand="lbnshili_Command"></asp:LinkButton><br />
                    <ul class="caseul">
                    <asp:Repeater ID="rpshili" runat="server">
                        <ItemTemplate>
                    	    <li style='display:<%#Hiddenfirst(Container.ItemIndex)%>'><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Eval("title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </td>
            </tr>
        </table>
        </div>
    </div>
    <div class="plts">
    	<table class="pltstb">
        	<tr>
            	<td>
                <div class="pljdtd" >
                	<span class="pljdtitle">评论解说<a class="moreaf" style="margin-left:360px;" href="#1">更多》</a></span><br />
                	<ul class="pljdul">
                    	<li>
                        	<table class="jdtb">
                            <tr>
                            	<td class="jdtdleft">专家解读</td>
                                <td class="jdtdright"><strong><asp:Label ID="jiedutil" runat="server"></asp:Label></strong><br />
                                	<asp:Label ID="lbljieducon" runat="server" CssClass="casedecon"></asp:Label><asp:LinkButton ID="lbnzjjd" runat="server" CommandName="" CssClass="detahr" 
                        Text="【详细】" oncommand="lbnzjjd_Command"></asp:LinkButton>
                                </td>
                            </tr>
                            </table>
                        </li>
                        <li>
                        	<table class="jdtb">
                            <tr>
                            	<td class="jdtdleft">党报社评</td>
                                <td class="jdtdright"><strong><asp:Label ID="lbldbsp" runat="server"></asp:Label></strong><br />
                                	<asp:Label ID="lbldbspcon" runat="server" CssClass="casedecon"></asp:Label><asp:LinkButton ID="lbndbsp" runat="server" CommandName="" CssClass="detahr" 
                        Text="【详细】" oncommand="lbndbsp_Command"></asp:LinkButton>
                                </td>
                            </tr>
                            </table>
                        </li>
                    </ul>
                </div>
                </td>
                <td style="width:15px;">&nbsp;</td>
                <td>
                <div class="tszstd" >
                	<span class="tszstitle">他山之石<a class="moreaf" style="margin-left:360px;" href="News_list.aspx?kind=7">更多》</a></span><br />
                	<ul class="tszsul">
                    <asp:Repeater ID="rptszs" runat="server">
                        <ItemTemplate>
                    	    <li><a href='News_detail.aspx?nid=<%#Eval("ID") %>'><%#Eval("title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="voice" id="voice">
    	
    </div>
    <div class="weibodiv">
        <a href="http://www.xzfamily.com/portal.php?mod=list&catid=91" target="_blank" class="abtnwyh"></a>
        <a href="#1" class="abtnddz" onclick="showmak()"></a>
        <table>
            <tr>
                <td><div class="messagebox">
                    <iframe src="Messagebox.aspx?kind=1" scrolling="no" border="0" frameborder="0" allowtransparency="true" style=" border:none; padding:0px; margin:0px; width:432px; height:413px;" id="ibox1"></iframe>
                    </div>
                </td>
                <td valign="top">
                    <div class="mglist">
                        <ul style=" height:155px;">
                        <asp:Repeater ID="rpmglist" runat="server">
                            <ItemTemplate>
                                <li><a href="#1"><%#Eval("title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                        <a href="Message_list.aspx" target="_blank" class="moreaf" style=" margin-left:300px;">更多》</a>
                    </div>
                </td>
            </tr>
        </table>
        
        
    </div>
    
</div>
<div class="foot">
	<div class="footbox">
    	香洲群众路线网版权所有，未经书面授权禁止使用<br />
Copyright ©1997-2014 by www.xzqzlx.com.cn. all rights reserved
    </div>
</div>
<div id="munmask"></div>
<div id="ddxx">
    <iframe src="Messagebox.aspx?kind=2" scrolling="no" border="0" frameborder="0" allowtransparency="true" style="border:none; padding:0px; margin:0px; width:505px; height:413px;" id="ifddzxx"></iframe>
</div>
    </form>
</body>
</html>
