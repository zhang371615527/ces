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
    /// 年度目标子表
    /// </summary>
	public class Ndmbzb : BaseDALSQL<NdmbzbInfo>, INdmbzb
	{
		#region 对象实例及构造函数

		public static Ndmbzb Instance
		{
			get
			{
				return new Ndmbzb();
			}
		}
		public Ndmbzb() : base("BIZ_NDMBZB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override NdmbzbInfo DataReaderToEntity(IDataReader dataReader)
		{
			NdmbzbInfo info = new NdmbzbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.NdmbId = reader.GetString("NDMB_ID");
			info.HosID = reader.GetString("HosID");
			info.Type = reader.GetString("Type");
			info.Level = reader.GetString("Level");
			info.KhzbId = reader.GetString("KHZB_ID");
			info.Unit = reader.GetString("Unit");
			info.TargetValue = reader.GetDecimal("TargetValue");
			info.RealValue = reader.GetDecimal("RealValue");
			info.Ratio = reader.GetDecimal("Ratio");
			info.Desc = reader.GetString("Desc");
			info.CompTime = reader.GetDateTime("CompTime");
			info.Creator = reader.GetString("Creator");
			info.CreateTime = reader.GetDateTime("CreateTime");
			info.Editor = reader.GetString("Editor");
			info.EditTime = reader.GetDateTime("EditTime");
			info.ItemNote = reader.GetString("ItemNote");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(NdmbzbInfo obj)
		{
		    NdmbzbInfo info = obj as NdmbzbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("NDMB_ID", info.NdmbId);
 			hash.Add("HosID", info.HosID);
 			hash.Add("Type", info.Type);
 			hash.Add("Level", info.Level);
 			hash.Add("KHZB_ID", info.KhzbId);
 			hash.Add("Unit", info.Unit);
 			hash.Add("TargetValue", info.TargetValue);
 			hash.Add("RealValue", info.RealValue);
 			hash.Add("Ratio", info.Ratio);
 			hash.Add("Desc", info.Desc);
 			hash.Add("CompTime", info.CompTime);
 			hash.Add("Creator", info.Creator);
 			hash.Add("CreateTime", info.CreateTime);
 			hash.Add("Editor", info.Editor);
 			hash.Add("EditTime", info.EditTime);
 			hash.Add("ItemNote", info.ItemNote);
 				
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
             dict.Add("NdmbId", "年度目标内码");
             dict.Add("HosID", "所属医院");
             dict.Add("Type", "目标类型");
             dict.Add("Level", "目标等级");
             dict.Add("KhzbId", "目标内容");
             dict.Add("Unit", "单位");
             dict.Add("TargetValue", "目标值");
             dict.Add("RealValue", "实际值");
             dict.Add("Ratio", "完成率");
             dict.Add("Desc", "完成情况");
             dict.Add("CompTime", "完成时间");
             dict.Add("Creator", "创建人");
             dict.Add("CreateTime", "创建时间");
             dict.Add("Editor", "修改人");
             dict.Add("EditTime", "修改时间");
             dict.Add("ItemNote", "备注");
             #endregion

            return dict;
        }

    }
}