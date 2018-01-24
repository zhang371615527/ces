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
    /// 医疗绩效二次考核子表
    /// </summary>
	public class Yljxkhzb : BaseDALSQL<YljxkhzbInfo>, IYljxkhzb
	{
		#region 对象实例及构造函数

		public static Yljxkhzb Instance
		{
			get
			{
				return new Yljxkhzb();
			}
		}
		public Yljxkhzb() : base("BIZ_YLJXKHZB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override YljxkhzbInfo DataReaderToEntity(IDataReader dataReader)
		{
			YljxkhzbInfo info = new YljxkhzbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.JXKH_ID = reader.GetString("JXKH_ID");
            info.ZBID = reader.GetString("ZBID");
            info.XMMC = reader.GetString("XMMC");
            info.ZBMC = reader.GetString("ZBMC");
			info.Desc = reader.GetString("Desc");
			info.WeightPoint = reader.GetDecimal("WeightPoint");
			info.Point = reader.GetDecimal("Point");
            info.OrderNo = reader.GetDecimal("OrderNo");
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
        protected override Hashtable GetHashByEntity(YljxkhzbInfo obj)
		{
		    YljxkhzbInfo info = obj as YljxkhzbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("JXKH_ID", info.JXKH_ID);
            hash.Add("ZBID", info.ZBID);
            hash.Add("XMMC", info.XMMC);
            hash.Add("ZBMC", info.ZBMC);
 			hash.Add("Desc", info.Desc);
 			hash.Add("WeightPoint", info.WeightPoint);
 			hash.Add("Point", info.Point);
            hash.Add("OrderNo", info.OrderNo);
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
            dict.Add("JXKH_ID", "主表内码");
             dict.Add("ZBID", "指标编码");
             dict.Add("XMMC", "项目名称");
             dict.Add("ZBMC", "关键指标");
             dict.Add("Desc", "考核标准");
             dict.Add("WeightPoint", "权重分值");
             dict.Add("Point", "考核得分");
             dict.Add("Ratio", "完成率");
             dict.Add("Note", "备注");
             #endregion

            return dict;
        }

    }
}