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
    /// 科室字典
    /// </summary>
	public class Kszd : BaseDALSQL<KszdInfo>, IKszd
	{
		#region 对象实例及构造函数

		public static Kszd Instance
		{
			get
			{
				return new Kszd();
			}
		}
		public Kszd() : base("TB_KSZD","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override KszdInfo DataReaderToEntity(IDataReader dataReader)
		{
			KszdInfo info = new KszdInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.Name = reader.GetString("Name");
			info.ZxzdId = reader.GetString("ZXZD_ID");
			info.Path = reader.GetString("Path");
			info.Layer = reader.GetInt32("Layer");
			info.IsDetail = reader.GetString("IsDetail");
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
        protected override Hashtable GetHashByEntity(KszdInfo obj)
		{
		    KszdInfo info = obj as KszdInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("Name", info.Name);
 			hash.Add("ZXZD_ID", info.ZxzdId);
 			hash.Add("Path", info.Path);
 			hash.Add("Layer", info.Layer);
 			hash.Add("IsDetail", info.IsDetail);
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
             dict.Add("Code", "科室编号");
             dict.Add("Name", "科室名称");
             dict.Add("ZxzdId", "职系");
             dict.Add("Path", "路径");
             dict.Add("Layer", "层级");
             dict.Add("IsDetail", "是否明细");
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