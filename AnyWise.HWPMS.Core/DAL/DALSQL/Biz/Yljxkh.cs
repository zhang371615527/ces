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
    /// 医疗绩效二次考核
    /// </summary>
	public class Yljxkh : BaseDALSQL<YljxkhInfo>, IYljxkh
	{
		#region 对象实例及构造函数

		public static Yljxkh Instance
		{
			get
			{
				return new Yljxkh();
			}
		}
		public Yljxkh() : base("BIZ_YLJXKH","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YljxkhInfo DataReaderToEntity(IDataReader dataReader)
		{
			YljxkhInfo info = new YljxkhInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.HosID = reader.GetString("HosID");
			info.Year = reader.GetString("Year");
			info.Month = reader.GetString("Month");
			info.Weight = reader.GetDecimal("Weight");
			info.ResPersion = reader.GetString("ResPersion");
			info.ResKS_ID = reader.GetString("ResKS_ID");
			info.CheckKS_ID = reader.GetString("CheckKS_ID");
			info.Checker = reader.GetString("Checker");
			info.BeginDate = reader.GetDateTime("BeginDate");
			info.EndDate = reader.GetDateTime("EndDate");
			info.CheckTime = reader.GetDateTime("CheckTime");
			info.ZXZD_ID = reader.GetString("ZXZD_ID");
			info.Type = reader.GetString("Type");
			info.State = reader.GetString("State");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			info.Note = reader.GetString("Note");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(YljxkhInfo obj)
		{
		    YljxkhInfo info = obj as YljxkhInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("HosID", info.HosID);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("Weight", info.Weight);
 			hash.Add("ResPersion", info.ResPersion);
 			hash.Add("ResKS_ID", info.ResKS_ID);
 			hash.Add("CheckKS_ID", info.CheckKS_ID);
 			hash.Add("Checker", info.Checker);
 			hash.Add("BeginDate", info.BeginDate);
 			hash.Add("EndDate", info.EndDate);
 			hash.Add("CheckTime", info.CheckTime);
 			hash.Add("ZXZD_ID", info.ZXZD_ID);
 			hash.Add("Type", info.Type);
 			hash.Add("State", info.State);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
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
             dict.Add("Code", "考核编号");
             dict.Add("HosID", "所属医院");
             dict.Add("Year", "年度");
             dict.Add("Month", "月度");
             dict.Add("Weight", "权重");
             dict.Add("ResPersion", "责任人");
             dict.Add("ResKS_ID", "责任部门");
             dict.Add("CheckKS_ID", "考核部门");
             dict.Add("Checker", "考核人");
             dict.Add("BeginDate", "开始日期");
             dict.Add("EndDate", "结束日期");
             dict.Add("CheckTime", "考核时间");
             dict.Add("ZXZD_ID", "职系");
             dict.Add("Type", "类型");
             dict.Add("State", "状态");
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