using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using AnyWise.Pager.Entity;
using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;

namespace AnyWise.HWPMS.DALSQL
{
    /// <summary>
    /// 医疗绩效奖金汇总
    /// </summary>
	public class Yljxjjhz : BaseDALSQL<YljxjjhzInfo>, IYljxjjhz
	{
		#region 对象实例及构造函数

		public static Yljxjjhz Instance
		{
			get
			{
				return new Yljxjjhz();
			}
		}
		public Yljxjjhz() : base("BIZ_YLJXJJHZ","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YljxjjhzInfo DataReaderToEntity(IDataReader dataReader)
		{
			YljxjjhzInfo info = new YljxjjhzInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Year = reader.GetString("Year");
			info.Month = reader.GetString("Month");
			info.ZxzdId = reader.GetString("ZXZD_ID");
			info.KszdId = reader.GetString("KSZD_ID");
			info.AccountWay = reader.GetString("AccountWay");
			info.Formula = reader.GetString("Formula");
			info.Detail = reader.GetString("Detail");
			info.Value = reader.GetDecimal("Value");
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
        protected override Hashtable GetHashByEntity(YljxjjhzInfo obj)
		{
		    YljxjjhzInfo info = obj as YljxjjhzInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("ZXZD_ID", info.ZxzdId);
 			hash.Add("KSZD_ID", info.KszdId);
 			hash.Add("AccountWay", info.AccountWay);
 			hash.Add("Formula", info.Formula);
 			hash.Add("Detail", info.Detail);
 			hash.Add("Value", info.Value);
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
             dict.Add("Year", "年度");
             dict.Add("Month", "月度");
             dict.Add("ZxzdId", "职系");
             dict.Add("KszdId", "科室编码");
             dict.Add("AccountWay", "核算方式");
             dict.Add("Formula", "核算公式");
             dict.Add("Detail", "明细项");
             dict.Add("Value", "金额");
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