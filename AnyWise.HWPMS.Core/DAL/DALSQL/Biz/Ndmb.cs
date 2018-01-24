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
    /// 年度目标表
    /// </summary>
	public class Ndmb : BaseDALSQL<NdmbInfo>, INdmb
	{
		#region 对象实例及构造函数

		public static Ndmb Instance
		{
			get
			{
				return new Ndmb();
			}
		}
		public Ndmb() : base("BIZ_NDMB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override NdmbInfo DataReaderToEntity(IDataReader dataReader)
		{
			NdmbInfo info = new NdmbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.HosID = reader.GetString("HosID");
			info.Year = reader.GetString("Year");
			info.ManDep_ID = reader.GetString("ManDep_ID");
			info.SubDep_ID = reader.GetString("SubDep_ID");
			info.SubUser_ID = reader.GetString("SubUser_ID");
			info.SubTime = reader.GetDateTime("SubTime");
			info.SubState = reader.GetString("SubState");
			info.Checker = reader.GetString("Checker");
			info.CheckTime = reader.GetDateTime("CheckTime");
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
        protected override Hashtable GetHashByEntity(NdmbInfo obj)
		{
		    NdmbInfo info = obj as NdmbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("HosID", info.HosID);
 			hash.Add("Year", info.Year);
 			hash.Add("ManDep_ID", info.ManDep_ID);
 			hash.Add("SubDep_ID", info.SubDep_ID);
 			hash.Add("SubUser_ID", info.SubUser_ID);
 			hash.Add("SubTime", info.SubTime);
 			hash.Add("SubState", info.SubState);
 			hash.Add("Checker", info.Checker);
 			hash.Add("CheckTime", info.CheckTime);
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
             dict.Add("Code", "目标编号");
             dict.Add("HosID", "所属医院");
             dict.Add("Year", "年度");
             dict.Add("ManDep_ID", "管理部门");
             dict.Add("SubDep_ID", "提报部门");
             dict.Add("SubUser_ID", "提报人");
             dict.Add("SubTime", "提报时间");
             dict.Add("SubState", "提报状态");
             dict.Add("Checker", "审批人");
             dict.Add("CheckTime", "审批时间");
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