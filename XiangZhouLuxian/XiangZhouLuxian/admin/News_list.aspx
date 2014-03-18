<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News_list.aspx.cs" Inherits="XiangZhouLuxian.admin.News_list" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link href="style/pagingstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/JScript.js"></script>
    <script type="text/javascript">
        function closediv(i) {
            $('#editarea').css({ display: 'none' });
        }

        function updatenew(id) {
            $.ajax({
                //要用post方式
                type: "Post",
                //方法所在页面和方法名
                url: "News_list.aspx/GetNewsInfo",
                data: "{'id':'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容
                    var str = data.d;
                    $("#txttitle").val(str.split("*")[0]);
                    $("#txtremark").val(str.split("*")[1]);
                    $("#txtcontent").val(str.split("*")[2]);
                    $("#isupdate").val('1');
                    $("#hidnid").val(id);
                },
                error: function (err) {
                    alert(err);
                }
            });
            $("#editarea").css({ display: "block" });
        }

        $(function () {
            $("#addaln").attr({ href: "NewsEdit.aspx?isupdate=0&kind=" + $("#hidkind").val() });
        })

        function addnew() {
            $("#txttitle").val('');
            $("#txtremark").val('');
            $("#txtcontent").val('');
            $("#isupdate").val('0')
            $("#editarea").css({ display: "block" });
        }
    </script>
</head>
<body style=" overflow:hidden;">
    <form id="form1" runat="server">
    <div class="sonpage">
        <div class="htbar"><asp:HiddenField ID="hidkind" runat="server" /> 
        标题：<asp:TextBox ID="txtserword" runat="server"></asp:TextBox> 
             &nbsp; &nbsp; &nbsp; <asp:Button ID="bnserach" CssClass="btnblock" runat="server" Text="查找" onclick="bnserach_Click" />
            &nbsp; &nbsp; &nbsp; <a id="addaln" class="btnblock" onclick='$("#editarea").css({ display: "block" });' href='NewsEdit.aspx?isupdate=0' target="inproframe">新增</a>
            </div>
            <div style=" height:450px;">
            <table class="tblist" cellpadding="0" cellspacing="0" style=" width:600px;">
            <asp:Repeater ID="rpNewsList" runat="server">
                <HeaderTemplate>
                    <tr class="headtr">
                        <td width="20%">编号</td>
                        <td>标题</td>
                        <td width="20%">操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td width="100"><asp:Label ID="lbltid" runat="server" Text='<%#Container.ItemIndex + 1 %>'></asp:Label></td>
                        <td><asp:Label ID="lbltname" runat="server" Text='<%#Eval("title") %>'></asp:Label></td>
<%--                        <td width="100"><a href="#1" data_id="<%#Eval("tid") %>" class="datarow">修改</a></td>--%>
                        <td width="100"><a onclick='$("#editarea").css({ display: "block" });' href='NewsEdit.aspx?id=<%#Eval("ID") %>&isupdate=1&kind=<%#Eval("kind") %>' target="inproframe" >修改</a> &nbsp; 
                        <asp:LinkButton CommandName='<%#Eval("ID") %>' ID="delbtn" runat="server" OnClientClick="return confirm('确定要删除么?')" OnCommand="delbtn_Command">刪除</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </table>
            </div>
            <div style=" width:500px; padding-top:10px; "><webdiyer:AspNetPager ID="AspNetPager1" 
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
        <div id="editarea" style=" width:900px; left:20px; top:20px; border:none; overflow:hidden;" class="hdiv">
            <iframe id="inproframe" name="inproframe" src="" style="margin:0; padding:0; border:solid 1px; width:800px; height:560px; "></iframe>
        </div>
        
    </div>
    </form>
</body>
</html>
