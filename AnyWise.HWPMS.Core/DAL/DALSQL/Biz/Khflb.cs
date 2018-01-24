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
    /// 考核分类表
    /// </summary>
    public class Khflb : BaseDALSQL<KhflbInfo>, IKhflb, IBaseDAL<KhflbInfo>
	{
		#region 对象实例及构造函数

		public static Khflb Instance
		{
			get
			{
				return new Khflb();
			}
		}
		public Khflb() : base("BIZ_KHFLB","ID")
		{
            base.sortField = "ParentCode";
            base.isDescending = false;
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override KhflbInfo DataReaderToEntity(IDataReader dataReader)
		{
			KhflbInfo info = new KhflbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.ParentCode = reader.GetString("ParentCode");
			info.Name = reader.GetString("Name");
			info.Content = reader.GetString("Content");
            info.NodeType = reader.GetString("NodeType");
			info.Type = reader.GetString("Type");
            info.Weight = reader.GetDecimal("Weight");
			info.Time = reader.GetString("Time");
			info.Method = reader.GetString("Method");
            info.LowerLimit = reader.GetDecimal("LowerLimit");
            info.StandValue = reader.GetDecimal("StandValue");
            info.TargetValue = reader.GetDecimal("TargetValue");
            info.HighLimit = reader.GetDecimal("HighLimit");
            info.Value = reader.GetDecimal("Value");
			info.Unit = reader.GetString("Unit");
			info.Source = reader.GetString("Source");
			info.Formula = reader.GetString("Formula");
            info.Point = reader.GetDecimal("Point");
            info.ResKS_ID = reader.GetString("ResKS_ID");
            info.CheckKS_ID = reader.GetString("CheckKS_ID");
            info.CheckRole = reader.GetString("CheckRole");
            info.Checker = reader.GetString("Checker");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Editor = reader.GetString("Editor");
			info.Note = reader.GetString("Note");
            info.WebIcon = reader.GetString("WebIcon");
			info.Enabled = reader.GetBoolean("Enabled");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(KhflbInfo obj)
		{
		    KhflbInfo info = obj as KhflbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("ParentCode", info.ParentCode);
 			hash.Add("Name", info.Name);
 			hash.Add("Content", info.Content);
            hash.Add("NodeType", info.NodeType);
 			hash.Add("Type", info.Type);
 			hash.Add("Weight", info.Weight);
 			hash.Add("Time", info.Time);
 			hash.Add("Method", info.Method);
 			hash.Add("LowerLimit", info.LowerLimit);
 			hash.Add("StandValue", info.StandValue);
 			hash.Add("TargetValue", info.TargetValue);
 			hash.Add("HighLimit", info.HighLimit);
 			hash.Add("Value", info.Value);
 			hash.Add("Unit", info.Unit);
 			hash.Add("Source", info.Source);
 			hash.Add("Formula", info.Formula);
            hash.Add("Point", info.Point);
            hash.Add("ResKS_ID", info.ResKS_ID);
            hash.Add("CheckKS_ID", info.CheckKS_ID);
            hash.Add("CheckRole", info.CheckRole);
            hash.Add("Checker", info.Checker);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("Note", info.Note);
            hash.Add("WebIcon", info.WebIcon);
 			hash.Add("Enabled", info.Enabled);
 				
			return hash;
		}

        public List<KhflbInfo> GetAllKhflb(string nodeType)
        {
            string str = !string.IsNullOrEmpty(nodeType) ? string.Format("Where NodeType='{0}'", nodeType) : "";
            string sql = string.Format("Select * From {0} {1} Order  By  Code  ", base.tableName, str);
            return this.GetList(sql, null);
        }

        public List<KhflbInfo> GetKhflbByID(string ParentCode)
        {
            string sql = string.Format("Select t.*,case ParentCode when '-1' then '0' else ParentCode end as parentId From {1} t \r\n                                         Where  ParentCode='{0}' Order By ParentCode ", ParentCode, base.tableName);
            return this.GetList(sql, null);
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
            dict.Add("ID", "内码");
             dict.Add("Code", "指标编号");
             dict.Add("ParentCode", "父级编号");
             dict.Add("Name", "指标名称");
             dict.Add("Content", "基本内容");
             dict.Add("NodeType","节点类型");
             dict.Add("Type", "考核类别");
             dict.Add("Weight", "权重");
             dict.Add("Time", "考核时限");
             dict.Add("Method", "考核方法");
             dict.Add("LowerLimit", "警戒值下线");
             dict.Add("StandValue", "标准值");
             dict.Add("TargetValue", "目标值");
             dict.Add("HighLimit", "警戒值上线");
             dict.Add("Value", "实际值");
             dict.Add("Unit", "值计量单位");
             dict.Add("Source", "数据来源");
             dict.Add("Formula", "执行公式");
             dict.Add("Point", "考核得分");
             dict.Add("ResKS_ID", "责任部门");
             dict.Add("CheckKS_ID", "考核部门");
             dict.Add("CheckRole", "考核角色");
             dict.Add("Checker", "考核人");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("EditTime", "修改时间");
             dict.Add("Editor", "修改人");
             dict.Add("Note", "备注");
             dict.Add("Enabled", "是否有效");
             #endregion

            return dict;
        }

    }
}