using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.Entity
{
    /// <summary>
    /// View_RoleUsers
    /// </summary>
    [DataContract]
    public class View_RoleUsersInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public View_RoleUsersInfo()
		{
   
		}

        #region Property Members
        
        /// <summary>
        /// 编号
        /// </summary>
		[DataMember]
        public virtual int ID { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
		[DataMember]
        public virtual int PID { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
		[DataMember]
        public virtual string HandNo { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
		[DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
		[DataMember]
        public virtual string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
		[DataMember]
        public virtual string FullName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
		[DataMember]
        public virtual string Nickname { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
		[DataMember]
        public virtual bool IsExpire { get; set; }

        /// <summary>
        /// 职  务
        /// </summary>
		[DataMember]
        public virtual string Title { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
		[DataMember]
        public virtual string IdentityCard { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
		[DataMember]
        public virtual string MobilePhone { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>
		[DataMember]
        public virtual string OfficePhone { get; set; }

        /// <summary>
        /// 家庭电话
        /// </summary>
		[DataMember]
        public virtual string HomePhone { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
		[DataMember]
        public virtual string Email { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
		[DataMember]
        public virtual string Address { get; set; }

        /// <summary>
        /// 办公地址
        /// </summary>
		[DataMember]
        public virtual string WorkAddr { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
		[DataMember]
        public virtual string Gender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
		[DataMember]
        public virtual DateTime Birthday { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
		[DataMember]
        public virtual string QQ { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
		[DataMember]
        public virtual string Signature { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
		[DataMember]
        public virtual string AuditStatus { get; set; }

        /// <summary>
        /// 个人图片
        /// </summary>
		[DataMember]
        public virtual byte[] Portrait { get; set; }

        /// <summary>
        /// 个人备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }

        /// <summary>
        /// 自定义内容
        /// </summary>
		[DataMember]
        public virtual string CustomField { get; set; }

        /// <summary>
        /// 默认部门
        /// </summary>
		[DataMember]
        public virtual string Dept_ID { get; set; }

        /// <summary>
        /// 默认部门名称
        /// </summary>
		[DataMember]
        public virtual string DeptName { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
		[DataMember]
        public virtual string Company_ID { get; set; }

        /// <summary>
        /// 所属公司名称
        /// </summary>
		[DataMember]
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
		[DataMember]
        public virtual string SortCode { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
		[DataMember]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
		[DataMember]
        public virtual string Creator_ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 编辑人
        /// </summary>
		[DataMember]
        public virtual string Editor { get; set; }

        /// <summary>
        /// 编辑人ID
        /// </summary>
		[DataMember]
        public virtual string Editor_ID { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
		[DataMember]
        public virtual DateTime EditTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
		[DataMember]
        public virtual int Deleted { get; set; }

        /// <summary>
        /// 密保：提示问题
        /// </summary>
		[DataMember]
        public virtual string Question { get; set; }

        /// <summary>
        /// 密保：问题答案
        /// </summary>
		[DataMember]
        public virtual string Answer { get; set; }

        /// <summary>
        /// 上次登录IP
        /// </summary>
		[DataMember]
        public virtual string LastLoginIP { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
		[DataMember]
        public virtual DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录MAC地址
        /// </summary>
		[DataMember]
        public virtual string LastMacAddress { get; set; }

        /// <summary>
        /// 当前登录IP
        /// </summary>
		[DataMember]
        public virtual string CurrentLoginIP { get; set; }

        /// <summary>
        /// 当前登录时间
        /// </summary>
		[DataMember]
        public virtual DateTime CurrentLoginTime { get; set; }

        /// <summary>
        /// 当前登录MAC地址
        /// </summary>
		[DataMember]
        public virtual string CurrentMacAddress { get; set; }

        /// <summary>
        /// 最后修改密码日期时间
        /// </summary>
		[DataMember]
        public virtual DateTime LastPasswordTime { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
		[DataMember]
        public virtual string Role_ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
		[DataMember]
        public virtual string Role_Name { get; set; }


        #endregion

    }
}