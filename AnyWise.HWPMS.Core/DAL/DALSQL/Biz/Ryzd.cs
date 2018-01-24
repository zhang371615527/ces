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
    /// 人员字典
    /// </summary>
	public class Ryzd : BaseDALSQL<RyzdInfo>, IRyzd
	{
		#region 对象实例及构造函数

		public static Ryzd Instance
		{
			get
			{
				return new Ryzd();
			}
		}
		public Ryzd() : base("TB_RYZD","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override RyzdInfo DataReaderToEntity(IDataReader dataReader)
		{
			RyzdInfo info = new RyzdInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.Code = reader.GetString("Code");
			info.Name = reader.GetString("Name");
			info.CardNum = reader.GetString("CardNum");
			info.KszdId = reader.GetString("KSZD_ID");
			info.GwzdId = reader.GetString("GWZD_ID");
			info.ZczdId = reader.GetString("ZCZD_ID");
			info.ZxzdId = reader.GetString("ZXZD_ID");
            info.FPLBZD_ID = reader.GetString("FPLBZD_ID");
            info.ZWZD_ID = reader.GetString("ZWZD_ID");
            info.ZDZD_ID = reader.GetString("ZDZD_ID");
            info.ZJZD_ID = reader.GetString("ZJZD_ID");
            info.NZZD_ID = reader.GetString("NZZD_ID");
			info.DocNum = reader.GetString("DocNum");
			info.HISNum = reader.GetString("HISNum");
			info.SalNum = reader.GetString("SalNum");
            info.Birth = reader.GetDateTime("Birth");
			info.CardID = reader.GetString("CardID");
			info.Sex = reader.GetString("Sex");
			info.Link = reader.GetString("Link");
			info.Record = reader.GetString("Record");
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
        protected override Hashtable GetHashByEntity(RyzdInfo obj)
		{
		    RyzdInfo info = obj as RyzdInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("Code", info.Code);
 			hash.Add("Name", info.Name);
 			hash.Add("CardNum", info.CardNum);
 			hash.Add("KSZD_ID", info.KszdId);
 			hash.Add("GWZD_ID", info.GwzdId);
 			hash.Add("ZCZD_ID", info.ZczdId);
            hash.Add("ZXZD_ID", info.ZxzdId);
            hash.Add("FPLBZD_ID", info.FPLBZD_ID);
            hash.Add("ZWZD_ID", info.ZWZD_ID);
            hash.Add("ZDZD_ID", info.ZDZD_ID);
            hash.Add("ZJZD_ID", info.ZJZD_ID);
            hash.Add("NZZD_ID", info.NZZD_ID);
 			hash.Add("DocNum", info.DocNum);
 			hash.Add("HISNum", info.HISNum);
 			hash.Add("SalNum", info.SalNum);
 			hash.Add("Birth", info.Birth);
 			hash.Add("CardID", info.CardID);
 			hash.Add("Sex", info.Sex);
 			hash.Add("Link", info.Link);
 			hash.Add("Record", info.Record);
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
             dict.Add("Code", "人员编号");
             dict.Add("Name", "人员名称");
             dict.Add("CardNum", "工号");
             dict.Add("KszdId", "科室");
             dict.Add("GwzdId", "岗位");
             dict.Add("ZczdId", "职称");
             dict.Add("ZxzdId", "职系");
             dict.Add("FPLBZD_ID", "分配类别");
             dict.Add("ZWZD_ID", "职务");
             dict.Add("ZDZD_ID", "职等");
             dict.Add("ZJZD_ID", "职级");
             dict.Add("NZZD_ID", "年资");
             dict.Add("DocNum", "医师代码");
             dict.Add("HISNum", "HIS代码");
             dict.Add("SalNum", "工资代码");
             dict.Add("Birth", "出生年月");
             dict.Add("CardID", "身份证号");
             dict.Add("Sex", "性别");
             dict.Add("Link", "联系方式");
             dict.Add("Record", "学历");
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