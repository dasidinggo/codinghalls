using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Manager
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
            Service s = new Service();
            return s.login(user, pwd);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool UpdatePwd(string user, string pwd)
        {
            Service s = new Service();
            return s.UpdatePwd(user, pwd);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool AddUser(string user, string pwd)
        {
            Service s = new Service();
            return s.AddUser(user, pwd);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool DelUser(string id)
        {
            Service s = new Service();
            return s.DelUser(id);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            Service s = new Service();
            return s.GetUserList();
        }

        /// <summary>
        /// 通过用户ID获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public DataTable GetUserById(string id)
        {
            Service s = new Service();
            return s.GetUserById(id);
        }


        #endregion

        #region "后台菜单"

        /// <summary>
        /// 获取后台一级菜单
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenuList()
        {
            Service s = new Service();
            return s.GetMenuList();
        }

        /// <summary>
        /// 根据父级菜单获取子菜单
        /// </summary>
        /// <param name="pid">父级菜单ID</param>
        /// <returns></returns>
        public DataTable GetSonM(string pid)
        {
            Service s = new Service();
            return s.GetSonM(pid);
        }

        #endregion

        #region "公司简介"

        /// <summary>
        /// 获取公司简介
        /// </summary>
        /// <returns></returns>
        public DataTable GetProfile()
        {
            Service s = new Service();
            return s.GetProfile();
        }

        /// <summary>
        /// 修改公司简介
        /// </summary>
        /// <param name="con">新内容</param>
        /// <returns></returns>
        public bool SaveProfile(string con, string title)
        {
            Service s = new Service();
            return s.SaveProfile(con, title);
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
            Service s = new Service();
            return s.GetNews(kind);
        }

        /// <summary>
        /// 根据类型获取新闻列表前N条
        /// </summary>
        /// <param name="kind">新闻类型</param>
        /// <param name="count">条数</param>
        /// <returns></returns>
        public DataTable GetTopNews(string kind, string count)
        {
            Service s = new Service();
            return s.GetTopNews(kind, count);
        }

        /// <summary>
        /// 根据标题查找新闻
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public DataTable SerNews(string title, string kind)
        {
            Service s = new Service();
            return s.SerNews(title, kind);
        }

        /// <summary>
        /// 获取最新几条新闻
        /// </summary>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public DataTable GetTopNews(int count)
        {
            Service s = new Service();
            return s.GetTopNews(count);
        }

        /// <summary>
        /// 根据新闻ID获取新闻信息
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <returns></returns>
        public DataTable GetNewsById(string id)
        {
            Service s = new Service();
            return s.GetNewsById(id);
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
            Service s = new Service();
            return s.AddNews(con, title, kind, datetime, Author, Remark);
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
            Service s = new Service();
            return s.SaveNews(con, title, kind, id, datetime, Author, Remark);
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <returns></returns>
        public bool DelNews(string id)
        {
            Service s = new Service();
            return s.DelNews(id);
        }

        /// <summary>
        /// 获取新闻类型列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewsKindList()
        {
            Service s = new Service();
            return s.GetNewsKindList();
        }

        /// <summary>
        /// 根据类型ID获取新闻类型
        /// </summary>
        /// <param name="kindid">类型ID</param>
        /// <returns></returns>
        public DataTable GetNewsKindById(string kindid)
        {
            Service s = new Service();
            return s.GetNewsKindById(kindid);
        }

        /// <summary>
        /// 新增新闻类型
        /// </summary>
        /// <param name="kname">类型名称</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public bool AddNewsKind(string kname, string remark)
        {
            Service s = new Service();
            return s.AddNewsKind(kname, remark);
        }

        /// <summary>
        /// 根据类型ID删除新闻类型
        /// </summary>
        /// <param name="id">类型ID</param>
        /// <returns></returns>
        public bool DelNewsKind(string id)
        {
            Service s = new Service();
            return s.DelNewsKind(id);
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
            Service s = new Service();
            return s.UpdateNewsKind(id, kname, remark);
        }

        /// <summary>
        /// 获取案例展示
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetAnliNews(string count)
        {
            Service s = new Service();
            return s.GetAnliNews(count);
        }

        /// <summary>
        /// 获取评论解读
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetPinlunNews(string count)
        {
            Service s = new Service();
            return s.GetPinlunNews(count);
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
            Service s = new Service();
            return s.SerProList(kind, pname);
        }

        /// <summary>
        /// 根据类型获取产品
        /// </summary>
        /// <param name="kind">产品类型</param>
        /// <returns></returns>
        public DataTable GetProListByKind(string kind)
        {
            Service s = new Service();
            return s.GetProListByKind(kind);
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
        public bool AddProduct(string pname, string picurl, string content, string kind, string remark, string oper)
        {
            Service s = new Service();
            return s.AddProduct(pname, picurl, content, kind, remark, oper);
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
        public bool UpdateProduct(string id, string pname, string picurl, string content, string kind, string remark, string oper)
        {
            Service s = new Service();
            return s.UpdateProduct(id, pname, picurl, content, kind, remark, oper);
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="pid">产品ID</param>
        /// <returns></returns>
        public bool DelProduct(string pid)
        {
            Service s = new Service();
            return s.DelProduct(pid);
        }

        /// <summary>
        /// 根据产品ID获取产品
        /// </summary>
        /// <param name="pid">产品ID</param>
        /// <returns></returns>
        public DataTable GetProductByPid(string pid)
        {
            Service s = new Service();
            return s.GetProductByPid(pid);
        }

        #endregion

        #region "联系信息"

        /// <summary>
        /// 获取联系信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetContact()
        {
            Service s = new Service();
            return s.GetContact();
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
            Service s = new Service();
            return s.SaveContact(til, con, remark);
        }

        #endregion

        #region "留言模块"

        /// <summary>
        /// 获取留言列表
        /// </summary>
        /// <param name="kind">留言类型</param>
        /// <returns></returns>
        public DataTable GetMessageList(string kind)
        {
            Service s = new Service();
            return s.GetMessageList(kind);
        }

        /// <summary>
        /// 查找留言列表
        /// </summary>
        /// <param name="kind">留言类型</param>
        /// <param name="title">留言主题</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public DataTable SerMessageList(string kind, string title, string status)
        {
            Service s = new Service();
            return s.SerMessageList(kind, title, status);
        }

        /// <summary>
        /// 根据留言ID获取留言信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public DataTable GetMessageById(string mid)
        {
            Service s = new Service();
            return s.GetMessageById(mid);
        }

        /// <summary>
        /// 获取前5条留言信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTop5MessageList()
        {
            Service s = new Service();
            return s.GetTop5MessageList();
        }

        /// <summary>
        /// 新增留言
        /// </summary>
        /// <param name="mname">留言人</param>
        /// <param name="title">主题</param>
        /// <param name="content">内容</param>
        /// <param name="kind">留言类型</param>
        /// <returns></returns>
        public bool AddMessage(string mname, string title, string content, string kind)
        {
            Service s = new Service();
            return s.AddMessage(mname, title, content, kind);
        }

        /// <summary>
        /// 审核留言
        /// </summary>
        /// <param name="mid">留言ID</param>
        /// <returns></returns>
        public bool AuditMessage(string mid, string status)
        {
            Service s = new Service();
            return s.AuditMessage(mid,status);
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="mid">留言ID</param>
        /// <returns></returns>
        public bool DelMessage(string mid)
        {
            Service s = new Service();
            return s.DelMessage(mid);
        }

        #endregion

        #region "轮播图设置"
        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetCarousel()
        {
            Service s = new Service();
            return s.GetCarousel();
        }

        public DataTable GetCarouselById(string id)
        {
            Service s = new Service();
            return s.GetCarouselById(id);
        }

        /// <summary>
        /// 新增轮播图
        /// </summary>
        /// <param name="title"></param>
        /// <param name="picurl"></param>
        /// <param name="hrefstr"></param>
        /// <returns></returns>
        public bool AddCarousel(string title, string picurl, string hrefstr)
        {
            Service s = new Service();
            return s.AddCarousel(title, picurl, hrefstr);
        }

        /// <summary>
        /// 修改轮播图
        /// </summary>
        /// <param name="title"></param>
        /// <param name="picurl"></param>
        /// <param name="hrefstr"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateCarousel(string title, string picurl, string hrefstr, string id)
        {
            Service s = new Service();
            return s.UpdateCarousel(title,picurl,hrefstr,id);
        }

        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelCarousel(string id)
        {
            Service s = new Service();
            return s.DelCarousel(id);
        }

        #endregion
    }
}
