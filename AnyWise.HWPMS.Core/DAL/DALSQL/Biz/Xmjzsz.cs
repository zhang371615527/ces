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
    /// 项目基准设置
    /// </summary>
	public class Xmjzsz : BaseDALSQL<XmjzszInfo>, IXmjzsz
	{
		#region 对象实例及构造函数

		public static Xmjzsz Instance
		{
			get
			{
				return new Xmjzsz();
			}
		}
		public Xmjzsz() : base("TB_XMJZSZ","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override XmjzszInfo DataReaderToEntity(IDataReader dataReader)
		{
			XmjzszInfo info = new XmjzszInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.Name = reader.GetString("Name");
			info.HISCode = reader.GetString("HISCode");
			info.HISName = reader.GetString("HISName");
			info.ZxzdId = reader.GetString("ZXZD_ID");
			info.Pym = reader.GetString("PYM");
			info.Except = reader.GetString("Except");
			info.Unit = reader.GetString("Unit");
			info.PriceStand = reader.GetDecimal("PriceStand");
			info.BillPoint = reader.GetDecimal("BillPoint");
			info.ExecPoint = reader.GetDecimal("ExecPoint");
			info.OrderNo = reader.GetInt32("OrderNo");
			info.Desc = reader.GetString("Desc");
			info.Flag = reader.GetString("Flag");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Enabled = reader.GetString("Enabled");
			info.Note = reader.GetString("Note");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(XmjzszInfo obj)
		{
		    XmjzszInfo info = obj as XmjzszInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("Name", info.Name);
 			hash.Add("HISCode", info.HISCode);
 			hash.Add("HISName", info.HISName);
 			hash.Add("ZXZD_ID", info.ZxzdId);
 			hash.Add("PYM", info.Pym);
 			hash.Add("Except", info.Except);
 			hash.Add("Unit", info.Unit);
 			hash.Add("PriceStand", info.PriceStand);
 			hash.Add("BillPoint", info.BillPoint);
 			hash.Add("ExecPoint", info.ExecPoint);
 			hash.Add("OrderNo", info.OrderNo);
 			hash.Add("Desc", info.Desc);
 			hash.Add("Flag", info.Flag);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("Enabled", info.Enabled);
 			hash.Add("Note", info.Note);
 				
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
            dict.Add("ID", "内码");
             dict.Add("Code", "项目编号");
             dict.Add("Name", "项目名称");
             dict.Add("HISCode", "HIS分类编码");
             dict.Add("HISName", "HIS分类名称");
             dict.Add("ZxzdId", "项目类别");
             dict.Add("Pym", "拼音码");
             dict.Add("Except", "除外内容");
             dict.Add("Unit", "计价单位");
             dict.Add("PriceStand", "价格标准");
             dict.Add("BillPoint", "开单点值");
             dict.Add("ExecPoint", "执行点值");
             dict.Add("OrderNo", "排序");
             dict.Add("Desc", "说明");
             dict.Add("Flag", "标识");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("Enabled", "是否启用");
             dict.Add("Note", "备注");
             #endregion

            return dict;
        }

    }
}