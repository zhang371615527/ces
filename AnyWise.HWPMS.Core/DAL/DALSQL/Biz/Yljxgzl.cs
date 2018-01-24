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
    /// 医疗绩效工作量
    /// </summary>
	public class Yljxgzl : BaseDALSQL<YljxgzlInfo>, IYljxgzl
	{
		#region 对象实例及构造函数

		public static Yljxgzl Instance
		{
			get
			{
				return new Yljxgzl();
			}
		}
		public Yljxgzl() : base("BIZ_YLJXGZL","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YljxgzlInfo DataReaderToEntity(IDataReader dataReader)
		{
			YljxgzlInfo info = new YljxgzlInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			info.ID = reader.GetString("ID");
			info.Year = reader.GetString("Year");
			info.Month = reader.GetString("Month");
			info.Date = reader.GetDateTime("Date");
			info.Source = reader.GetString("Source");
            info.KszdId = reader.GetString("KSZD_ID");
            info.KszdName = reader.GetString("KSZD_Name");
			info.RyzdId = reader.GetString("RYZD_ID");
			info.RyzdName = reader.GetString("RYZD_Name");
			info.Xmlbid = reader.GetString("XMLB_ID");
			info.XmlbName = reader.GetString("XMLB_Name");
			info.XmzdId = reader.GetString("XMZD_ID");
			info.XmzdName = reader.GetString("XMZD_Name");
			info.Unit = reader.GetString("Unit_ID");            
			info.UnitName = reader.GetString("Unit_Name");
			info.Quantity = reader.GetDecimal("Quantity");
			info.Value = reader.GetDecimal("Value");
			info.ExecKSID = reader.GetString("ExecKSID");
			info.ExecKSName = reader.GetString("ExeckKS_Name");
			info.ExecRYZDID = reader.GetString("ExecRYZD_ID");
			info.ExecRYZDName = reader.GetString("ExecRYZD_Name");
			info.IsDrugIncome = reader.GetString("IsDrugIncome");
			info.Bqid = reader.GetString("BQID");
			info.BqName = reader.GetString("BQ_Name");
			info.ZxzdId = reader.GetString("ZXZD_ID");			
			info.Note = reader.GetString("Note");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(YljxgzlInfo obj)
		{
		    YljxgzlInfo info = obj as YljxgzlInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("Date", info.Date);
 			hash.Add("Source", info.Source);
            hash.Add("KSZD_ID", info.KszdId);
            hash.Add("KSZD_Name", info.KszdName);
            hash.Add("RYZD_ID", info.RyzdId);
            hash.Add("RYZD_Name", info.RyzdName);
            hash.Add("XMLB_ID", info.Xmlbid);
            hash.Add("XMLB_Name", info.XmlbName);
            hash.Add("XMZD_ID", info.XmzdId);
            hash.Add("XMZD_Name", info.XmzdName);
            hash.Add("Unit_ID", info.Unit);
            hash.Add("Unit_Name", info.UnitName);
            hash.Add("Quantity", info.Quantity);
            hash.Add("Value", info.Value);
            hash.Add("ExecKSID", info.ExecKSID);
            hash.Add("ExeckKS_Name", info.ExecKSName);
            hash.Add("ExecRYZD_ID", info.ExecRYZDID);
            hash.Add("ExecRYZD_Name", info.ExecRYZDName);
            hash.Add("IsDrugIncome", info.IsDrugIncome);
            hash.Add("BQID", info.Bqid);
            hash.Add("BQ_Name", info.BqName);
            hash.Add("ZXZD_ID", info.ZxzdId);
            hash.Add("Note", info.Note);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
 				
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
             dict.Add("Year", "年");
             dict.Add("Month", "月");
             dict.Add("Date", "日期");
             dict.Add("Source", "费用来源");
             dict.Add("XmzdId", "项目代码");
             dict.Add("Xmid", "项目大类");
             dict.Add("ZxzdId", "项目类别");
             dict.Add("KszdId", "科室代码");
             dict.Add("Bqid", "病区代码");
             dict.Add("RyzdId", "医生代码");
             dict.Add("ExecKSID", "执行科室代码");
             dict.Add("Unit", "计量单位代码");
             dict.Add("Quantity", "数量");
             dict.Add("Value", "金额");
             dict.Add("IsDrugIncome", "是否药品收入");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("Note", "备注");
             #endregion

            return dict;
        }

    }
}