using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class Service
    {

        #region "用户管理"
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataTable login(string user, string pwd)
        {
            string sql = "select * from Memberlist where [user]=@memberId and pwd=@pwd and isstop=@isstop ";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@memberid",user),                
                new OleDbParameter("@pwd",pwd),
                new OleDbParameter("@isstop","0")
            };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool UpdatePwd(string user, string pwd)
        {
            string sql = "update Memberlist set pwd = @pwd where user = @user";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@pwd",pwd),
                new OleDbParameter("@user",user)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool AddUser(string user, string pwd)
        {
            string sql = "insert into Memberlist ([user],[pwd],isstop) values (@user,@pwd,@isstop)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@user",user),
                new OleDbParameter("@pwd",pwd),
                new OleDbParameter("@isstop","0")
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool DelUser(string id)
        {
            string sql = "delete from Memberlist where ID = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            string sql = "select * from Memberlist";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 通过用户ID获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public DataTable GetUserById(string id)
        {
            string sql = "select * from Memberlist where id = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",id)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }


        #endregion

        #region "后台菜单"

        /// <summary>
        /// 获取后台一级菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenuList()
        {
            string sql = "select * from MenuList where deep = @deep and isshow = @isshow order by orderno ";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@deep",1),
                new OleDbParameter("@isshow","1")
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 根据父级菜单获取子菜单
        /// </summary>
        /// <param name="pid">父级菜单ID</param>
        /// <returns></returns>
        public DataTable GetSonM(string pid)
        {
            string sql = "select * from MenuList where pid = @pid and isshow = @isshow order by orderno";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@pid",pid),
                new OleDbParameter("@isshow","1")
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        #endregion

        #region "公司简介"

        /// <summary>
        /// 获取公司简介
        /// </summary>
        /// <returns></returns>
        public DataTable GetProfile()
        {
            string sql = "select * from Profile ";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 修改公司简介
        /// </summary>
        /// <param name="con">新内容</param>
        /// <returns></returns>
        public bool SaveProfile(string con, string title)
        {
            string sql = "update Profile set content = @con, title = @title";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@con",con),
                new OleDbParameter("@remark",title)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        #endregion

        #region "新闻模块"

        /// <summary>
        /// 根据类型获取新闻列表
        /// </summary>
        /// <param name="kind">新闻类型</param>
        /// <returns></returns>
        public DataTable GetNews(string kind)
        {
            string sql = "select * from News where kind = @kind";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",kind)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 根据类型获取新闻列表前N条
        /// </summary>
        /// <param name="kind">新闻类型</param>
        /// <param name="count">条数</param>
        /// <returns></returns>
        public DataTable GetTopNews(string kind, string count)
        {
            string sql = "select top " + count + " * from News where kind = @kind";
            OleDbParameter[] parms = new OleDbParameter[]{
                //new OleDbParameter("@count",count),
                new OleDbParameter("@kind",kind)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 根据标题查找新闻
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable SerNews(string title,string kind)
        {
            string sql = "select * from News where title like '%" + title + "%' and kind = @kind";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",kind)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 获取最新几条新闻
        /// </summary>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public DataTable GetTopNews(int count)
        {
            string sql = "select top 8 * from News order by times desc ";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 根据新闻ID获取新闻信息
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <returns></returns>
        public DataTable GetNewsById(string id)
        {
            string sql = "select * from News where id = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",id)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 新增新闻
        /// </summary>
        /// <param name="con">内容</param>
        /// <param name="title">标题</param>
        /// <param name="kind">类型</param>
        /// <param name="datetime">发布日期</param>
        /// <param name="Author">作者</param>
        /// <param name="Remark">备注</param>
        /// <returns></returns>
        public bool AddNews(string con, string title, string kind, string datetime, string Author, string Remark)
        {
            string sql = "insert into News (content,title,kind,times,author,remark) values (@con,@title,@kind,@datetime,@Author,@Remark)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@con",con),
                new OleDbParameter("@title",title),
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@datetime",datetime),
                new OleDbParameter("@Author",Author),
                new OleDbParameter("@Remark",Remark)
             };

            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="con">内容</param>
        /// <param name="title">标题</param>
        /// <param name="kind">类型</param>
        /// <param name="id">新闻ID</param>
        /// <param name="datetime">发布日期</param>
        /// <param name="Author">作者</param>
        /// <param name="Remark">备注</param>
        /// <returns></returns>
        public bool SaveNews(string con, string title, string kind, string id, string datetime, string Author, string Remark)
        {
            string sql = "update News set content = @con ,title = @title , kind = @kind, times = @datetime,Author=@Author,Remark=@Remark where id = @id ";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@con",con),
                new OleDbParameter("@title",title),
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@datetime",datetime),
                new OleDbParameter("@Author",Author),
                new OleDbParameter("@Remark",Remark),
                new OleDbParameter("@id",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <returns></returns>
        public bool DelNews(string id)
        {
            string sql = "delete from News where id =@id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 获取新闻类型列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewsKindList()
        {
            string sql = "select * from News_kind order by ID";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 根据类型ID获取新闻类型
        /// </summary>
        /// <param name="kindid">类型ID</param>
        /// <returns></returns>
        public DataTable GetNewsKindById(string kindid)
        {
            string sql = "select * from News_kind where ID = @kindid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kindid",kindid)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 新增新闻类型
        /// </summary>
        /// <param name="kname">类型名称</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool AddNewsKind(string kname, string remark)
        {
            string sql = "insert into News_kind (Kname,remark) values (@kname,@remark)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kname",kname),
                new OleDbParameter("@remark",remark)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 根据类型ID删除新闻类型
        /// </summary>
        /// <param name="id">类型ID</param>
        /// <returns></returns>
        public bool DelNewsKind(string id)
        {
            string sql = "delete from News_kind where ID = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",int.Parse(id))
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 修改新闻类型
        /// </summary>
        /// <param name="id">类型ID</param>
        /// <param name="kname">类型名称</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool UpdateNewsKind(string id, string kname, string remark)
        {
            string sql = "update News_kind set kName = @kname,remark = @remark where ID = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kname",kname),
                new OleDbParameter("@ename",remark),
                new OleDbParameter("@tid",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 获取案例展示
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetAnliNews(string count)
        {
            string sql = "select top " + count + " * from News where kind = '2' or kind = '3' or kind ='4'";
            if(string.IsNullOrEmpty(count))
                sql = "select * from News where kind = '2' or kind = '3' or kind ='4'";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 获取评论解读
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetPinlunNews(string count)
        {
            string sql = "select top " + count + " * from News where kind = '5' or kind = '6'";
            if (string.IsNullOrEmpty(count))
                sql = "select * from News where kind = '5' or kind = '6'";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        #endregion

        #region "产品模块"

        /// <summary>
        /// 查询产品列表
        /// </summary>
        /// <param name="kind">产品类型</param>
        /// <param name="pname">产品名称</param>
        /// <returns></returns>
        public DataTable SerProList(string kind, string pname)
        {
            string sql = "select * from Products where ((@kind = '' and kind is not null) or (@kind <> '' and kind = @kind)) and ((@pname = '' and pname <> '') or (@pname <> '' and pname = @pname)) order by pid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@pname",pname)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 根据类型获取产品
        /// </summary>
        /// <param name="kind">产品类型</param>
        /// <returns></returns>
        public DataTable GetProListByKind(string kind)
        {
            string sql = "select * from Products where kind = @kind";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",kind)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="pname">产品名称</param>
        /// <param name="picurl">产品图片</param>
        /// <param name="content">产品内容</param>
        /// <param name="kind">产品类型</param>
        /// <param name="remark">备注</param>
        /// <param name="oper">操作人员</param>
        /// <returns></returns>
        public bool AddProduct(string pname,string picurl, string content,string kind,string remark,string oper)
        {
            string sql = "insert into Products (pname,picurl,content,kind,remark,operator) values (@pname,@picurl,@content,@kind,@remark,@operator)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@pname",pname),
                new OleDbParameter("@picurl",picurl),
                new OleDbParameter("@content",content),
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@remark",remark),
                new OleDbParameter("@operator", oper)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 修改产品资料
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <param name="pname">产品名称</param>
        /// <param name="picurl">产品图片</param>
        /// <param name="content">产品内容</param>
        /// <param name="kind">产品类型</param>
        /// <param name="remark">备注</param>
        /// <param name="oper">操作人员</param>
        /// <returns></returns>
        public bool UpdateProduct(string id,string pname,string picurl,string content,string kind,string remark,string oper)
        {
            string sql = "update Products set pname=@pname,picurl=@picurl,content=@content,kind=@kind,remark=@remark,oper=@oper where id =@id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@pname",pname),
                new OleDbParameter("@picurl",picurl),
                new OleDbParameter("@content",content),
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@remark",remark),
                new OleDbParameter("@operator", oper),
                new OleDbParameter("@id",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="pid">产品ID</param>
        /// <returns></returns>
        public bool DelProduct(string pid)
        {
            string sql = "delete from Products where id = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",pid)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 根据产品ID获取产品
        /// </summary>
        /// <param name="pid">产品ID</param>
        /// <returns></returns>
        public DataTable GetProductByPid(string pid)
        {
            string sql = "select * from Products where id = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",pid)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 获取产品类型列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetProKindList()
        {
            string sql = "select * from Product_Kind order by ID";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 根据类型ID获取类型
        /// </summary>
        /// <param name="tid">类型ID</param>
        /// <returns></returns>
        public DataTable GetProKindByTid(string tid)
        {
            string sql = "select * from Product_Kind where id = @tid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@tid",tid)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 修改产品类型
        /// </summary>
        /// <param name="tid">类型ID</param>
        /// <param name="kname">类型名称</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool UpdateProKind(string tid, string kname, string remark)
        {
            string sql = "update Product_Kind set kName = @kname, remark=@remark where id = @tid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kname",kname),
                new OleDbParameter("@remark",remark),
                new OleDbParameter("@tid",tid)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 新增产品类型
        /// </summary>
        /// <param name="kname">类型名称</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool AddProKind(string kname, string remark)
        {
            string sql = "insert into Product_Kind (kName,remark) values (@kname,@remark)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kname",kname),
                new OleDbParameter("@remark",remark)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 删除产品类型
        /// </summary>
        /// <param name="tid">类型ID</param>
        /// <returns></returns>
        public bool DelProKind(string tid)
        {
            string sql = "delete from Product_Kind where id = @tid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@tid",int.Parse(tid))
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        #endregion

        #region "联系信息"

        /// <summary>
        /// 获取联系信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetContact()
        {
            string sql = "select * from Contact";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 保存联系信息
        /// </summary>
        /// <param name="til">标题</param>
        /// <param name="con">内容</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool SaveContact(string til, string con, string remark)
        {
            string sql = "update Contact set title = @til,content = @con,remark=@remark";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@til",til),
                new OleDbParameter("@con",con),
                new OleDbParameter("@remark",remark)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        #endregion

        #region "留言模块"

        /// <summary>
        /// 获取通过审核的留言列表
        /// </summary>
        /// <param name="kind">留言类型</param>
        /// <returns></returns>
        public DataTable GetMessageList(string kind)
        {
            string sql = "select * from Message where kind = @kind and status = @status";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@status",1)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 查找留言列表
        /// </summary>
        /// <param name="kind">留言类型</param>
        /// <param name="title">留言主题</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public DataTable SerMessageList(string kind,string title,string status)
        {
            string sql = "select * from Message where kind = @kind and title like '%" + title + "%' and ((status = @status and @status <> 3) or (@status = 3))";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@status",status)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 根据留言ID获取留言信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public DataTable GetMessageById(string mid)
        {
            string sql = "select * from Message where ID = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",mid)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 获取前5条留言信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTop5MessageList()
        {
            string sql = "select top 5 * from Message where kind = @kind and status =@status order by datetimes desc";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@kind",1),
                new OleDbParameter("@status",1)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 新增留言
        /// </summary>
        /// <param name="mname">留言人</param>
        /// <param name="title">主题</param>
        /// <param name="content">内容</param>
        /// <param name="kind">留言类型</param>
        /// <returns></returns>
        public bool AddMessage(string mname,string title,string content,string kind)
        {
            string sql = "insert into Message (mname,title,content,kind,status,datetimes) values (@mname,@title,@content,@kind,@status,@datetimes)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@mname",mname),
                new OleDbParameter("@title",title),
                new OleDbParameter("@content",content),
                new OleDbParameter("@kind",kind),
                new OleDbParameter("@status","0"),
                new OleDbParameter("@datetimes",DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 审核留言
        /// </summary>
        /// <param name="mid">留言ID</param>
        /// <returns></returns>
        public bool AuditMessage(string mid,string status)
        {
            string sql = "update Message set status = @status where ID= @mid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@status",status),
                new OleDbParameter("@mid",mid)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="mid">留言ID</param>
        /// <returns></returns>
        public bool DelMessage(string mid)
        {
            string sql = "delete from Message where ID= @mid";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@mid",mid)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        #endregion

        #region "轮播图设置"
        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetCarousel()
        {
            string sql = "select * from Carousel";
            return DBHelper.getDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 根据ID获取轮播图内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetCarouselById(string id)
        {
            string sql = "select * from Carousel where id = @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",id)
             };
            return DBHelper.getDataTable(CommandType.Text, sql, parms);
        }

        /// <summary>
        /// 新增轮播图
        /// </summary>
        /// <param name="title"></param>
        /// <param name="picurl"></param>
        /// <param name="hrefstr"></param>
        /// <returns></returns>
        public bool AddCarousel(string title,string picurl,string hrefstr)
        {
            string sql = "insert into Carousel (title,picurl,hrefstr) values (@title,@picurl,@hrefstr)";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@title",title),
                new OleDbParameter("@picurl",picurl),
                new OleDbParameter("@hrefstr",hrefstr)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 修改轮播图
        /// </summary>
        /// <param name="title"></param>
        /// <param name="picurl"></param>
        /// <param name="hrefstr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateCarousel(string title, string picurl,string hrefstr,string id)
        {
            string sql = "update Carousel set title = @title,picurl=@picurl,hrefstr=@hrefstr where ID= @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@title",title),
                new OleDbParameter("@picurl",picurl),
                new OleDbParameter("@hrefstr",hrefstr),
                new OleDbParameter("@id",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelCarousel(string id)
        {
            string sql = "delete from Carousel where ID= @id";
            OleDbParameter[] parms = new OleDbParameter[]{
                new OleDbParameter("@id",id)
             };
            return DBHelper.ExecuteNonQuery(CommandType.Text, sql, parms) > 0;
        }

        #endregion 
    }
}
