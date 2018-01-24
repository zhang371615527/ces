using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.Pager.Entity;
using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;

namespace AnyWise.HWPMS.DALSQL
{
    /// <summary>
    /// View_RoleUsers
    /// </summary>
	public class View_RoleUsers : BaseDALSQL<View_RoleUsersInfo>, IView_RoleUsers
	{
		#region 对象实例及构造函数

		public static View_RoleUsers Instance
		{
			get
			{
				return new View_RoleUsers();
			}
		}
		public View_RoleUsers() : base("View_RoleUsers","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override View_RoleUsersInfo DataReaderToEntity(IDataReader dataReader)
		{
			View_RoleUsersInfo info = new View_RoleUsersInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetInt32("ID");
			info.PID = reader.GetInt32("PID");
			info.HandNo = reader.GetString("HandNo");
			info.Name = reader.GetString("Name");
			info.Password = reader.GetString("Password");
			info.FullName = reader.GetString("FullName");
			info.Nickname = reader.GetString("Nickname");
			info.IsExpire = reader.GetBoolean("IsExpire");
			info.Title = reader.GetString("Title");
			info.IdentityCard = reader.GetString("IdentityCard");
			info.MobilePhone = reader.GetString("MobilePhone");
			info.OfficePhone = reader.GetString("OfficePhone");
			info.HomePhone = reader.GetString("HomePhone");
			info.Email = reader.GetString("Email");
			info.Address = reader.GetString("Address");
			info.WorkAddr = reader.GetString("WorkAddr");
			info.Gender = reader.GetString("Gender");
			info.Birthday = reader.GetDateTime("Birthday");
			info.QQ = reader.GetString("QQ");
			info.Signature = reader.GetString("Signature");
			info.AuditStatus = reader.GetString("AuditStatus");
			info.Portrait = reader.GetBytes("Portrait");
			info.Note = reader.GetString("Note");
			info.CustomField = reader.GetString("CustomField");
			info.Dept_ID = reader.GetString("Dept_ID");
			info.DeptName = reader.GetString("DeptName");
			info.Company_ID = reader.GetString("Company_ID");
			info.CompanyName = reader.GetString("CompanyName");
			info.SortCode = reader.GetString("SortCode");
			info.Creator = reader.GetString("Creator");
			info.Creator_ID = reader.GetString("Creator_ID");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.Editor_ID = reader.GetString("Editor_ID");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Deleted = reader.GetInt32("Deleted");
			info.Question = reader.GetString("Question");
			info.Answer = reader.GetString("Answer");
			info.LastLoginIP = reader.GetString("LastLoginIP");
			info.LastLoginTime = reader.GetDateTime("LastLoginTime");
			info.LastMacAddress = reader.GetString("LastMacAddress");
			info.CurrentLoginIP = reader.GetString("CurrentLoginIP");
			info.CurrentLoginTime = reader.GetDateTime("CurrentLoginTime");
			info.CurrentMacAddress = reader.GetString("CurrentMacAddress");
			info.LastPasswordTime = reader.GetDateTime("LastPasswordTime");
            info.Role_ID = reader.GetString("Role_ID");
			info.Role_Name = reader.GetString("Role_Name");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(View_RoleUsersInfo obj)
		{
		    View_RoleUsersInfo info = obj as View_RoleUsersInfo;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("PID", info.PID);
 			hash.Add("HandNo", info.HandNo);
 			hash.Add("Name", info.Name);
 			hash.Add("Password", info.Password);
 			hash.Add("FullName", info.FullName);
 			hash.Add("Nickname", info.Nickname);
 			hash.Add("IsExpire", info.IsExpire);
 			hash.Add("Title", info.Title);
 			hash.Add("IdentityCard", info.IdentityCard);
 			hash.Add("MobilePhone", info.MobilePhone);
 			hash.Add("OfficePhone", info.OfficePhone);
 			hash.Add("HomePhone", info.HomePhone);
 			hash.Add("Email", info.Email);
 			hash.Add("Address", info.Address);
 			hash.Add("WorkAddr", info.WorkAddr);
 			hash.Add("Gender", info.Gender);
 			hash.Add("Birthday", info.Birthday);
 			hash.Add("QQ", info.QQ);
 			hash.Add("Signature", info.Signature);
 			hash.Add("AuditStatus", info.AuditStatus);
 			hash.Add("Portrait", info.Portrait);
 			hash.Add("Note", info.Note);
 			hash.Add("CustomField", info.CustomField);
 			hash.Add("Dept_ID", info.Dept_ID);
 			hash.Add("DeptName", info.DeptName);
 			hash.Add("Company_ID", info.Company_ID);
 			hash.Add("CompanyName", info.CompanyName);
 			hash.Add("SortCode", info.SortCode);
 			hash.Add("Creator", info.Creator);
 			hash.Add("Creator_ID", info.Creator_ID);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("Editor_ID", info.Editor_ID);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("Deleted", info.Deleted);
 			hash.Add("Question", info.Question);
 			hash.Add("Answer", info.Answer);
 			hash.Add("LastLoginIP", info.LastLoginIP);
 			hash.Add("LastLoginTime", info.LastLoginTime);
 			hash.Add("LastMacAddress", info.LastMacAddress);
 			hash.Add("CurrentLoginIP", info.CurrentLoginIP);
 			hash.Add("CurrentLoginTime", info.CurrentLoginTime);
 			hash.Add("CurrentMacAddress", info.CurrentMacAddress);
 			hash.Add("LastPasswordTime", info.LastPasswordTime);
 			hash.Add("Role_ID", info.Role_ID);
 			hash.Add("Role_Name", info.Role_Name);
 				
			return hash;
		}

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
             dict.Add("PID", "父级编号");
             dict.Add("HandNo", "用户编码");
             dict.Add("Name", "用户名");
             dict.Add("Password", "用户密码");
             dict.Add("FullName", "真实姓名");
             dict.Add("Nickname", "用户昵称");
             dict.Add("IsExpire", "是否过期");
             dict.Add("Title", "职  务");
             dict.Add("IdentityCard", "身份证");
             dict.Add("MobilePhone", "移动电话");
             dict.Add("OfficePhone", "办公电话");
             dict.Add("HomePhone", "家庭电话");
             dict.Add("Email", "邮件地址");
             dict.Add("Address", "居住地址");
             dict.Add("WorkAddr", "办公地址");
             dict.Add("Gender", "性别");
             dict.Add("Birthday", "出生日期");
             dict.Add("QQ", "QQ号码");
             dict.Add("Signature", "个性签名");
             dict.Add("AuditStatus", "审核状态");
             dict.Add("Portrait", "个人图片");
             dict.Add("Note", "个人备注");
             dict.Add("CustomField", "自定义内容");
             dict.Add("Dept_ID", "默认部门");
             dict.Add("DeptName", "默认部门名称");
             dict.Add("Company_ID", "所属公司");
             dict.Add("CompanyName", "所属公司名称");
             dict.Add("SortCode", "排序码");
             dict.Add("Creator", "创建人");
             dict.Add("Creator_ID", "创建人ID");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "编辑人");
             dict.Add("Editor_ID", "编辑人ID");
             dict.Add("EditTime", "编辑时间");
             dict.Add("Deleted", "是否删除");
             dict.Add("Question", "密保：提示问题");
             dict.Add("Answer", "密保：问题答案");
             dict.Add("LastLoginIP", "上次登录IP");
             dict.Add("LastLoginTime", "上次登录时间");
             dict.Add("LastMacAddress", "上次登录MAC地址");
             dict.Add("CurrentLoginIP", "当前登录IP");
             dict.Add("CurrentLoginTime", "当前登录时间");
             dict.Add("CurrentMacAddress", "当前登录MAC地址");
             dict.Add("LastPasswordTime", "最后修改密码日期时间");
             dict.Add("Role_ID", "角色编号");
             dict.Add("Role_Name", "角色名称");
             #endregion

            return dict;
        }

    }
}