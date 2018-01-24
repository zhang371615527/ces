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
    /// 收入明细表
    /// </summary>
	public class Srmxb : BaseDALSQL<SrmxbInfo>, ISrmxb
	{
		#region 对象实例及构造函数

		public static Srmxb Instance
		{
			get
			{
				return new Srmxb();
			}
		}
		public Srmxb() : base("BIZ_SRMXB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override SrmxbInfo DataReaderToEntity(IDataReader dataReader)
		{
			SrmxbInfo info = new SrmxbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
			info.HosID = reader.GetString("HosID");
			info.Year = reader.GetString("Year");
			info.Month = reader.GetString("Month");
			info.KszdId = reader.GetString("KSZD_ID");
			info.KSZD_Name = reader.GetString("KSZD_Name");
			info.Ylsr = reader.GetDecimal("YLSR");
			info.Ypsr = reader.GetDecimal("YPSR");
            info.Qtsr = reader.GetDecimal("QTSR");
			info.Total = reader.GetDecimal("Total");
			info.Sr1 = reader.GetDecimal("SR1");
			info.Sr2 = reader.GetDecimal("SR2");
			info.Sr3 = reader.GetDecimal("SR3");
			info.Sr4 = reader.GetDecimal("SR4");
			info.Sr5 = reader.GetDecimal("SR5");
			info.Sr6 = reader.GetDecimal("SR6");
			info.Sr7 = reader.GetDecimal("SR7");
			info.Sr8 = reader.GetDecimal("SR8");
			info.Sr9 = reader.GetDecimal("SR9");
			info.Sr10 = reader.GetDecimal("SR10");
			info.Sr11 = reader.GetDecimal("SR11");
			info.Sr12 = reader.GetDecimal("SR12");
			info.Sr13 = reader.GetDecimal("SR13");
			info.Sr14 = reader.GetDecimal("SR14");
			info.Sr15 = reader.GetDecimal("SR15");
			info.Sr16 = reader.GetDecimal("SR16");
			info.Sr17 = reader.GetDecimal("SR17");
			info.Sr18 = reader.GetDecimal("SR18");
			info.Sr19 = reader.GetDecimal("SR19");
			info.Sr20 = reader.GetDecimal("SR20");
			info.Sr21 = reader.GetDecimal("SR21");
			info.Sr22 = reader.GetDecimal("SR22");
			info.Sr23 = reader.GetDecimal("SR23");
			info.Sr24 = reader.GetDecimal("SR24");
			info.Sr25 = reader.GetDecimal("SR25");
			info.Sr26 = reader.GetDecimal("SR26");
			info.Sr27 = reader.GetDecimal("SR27");
			info.Sr28 = reader.GetDecimal("SR28");
			info.Sr29 = reader.GetDecimal("SR29");
			info.Sr30 = reader.GetDecimal("SR30");
			info.Sr31 = reader.GetDecimal("SR31");
			info.Sr32 = reader.GetDecimal("SR32");
			info.Sr33 = reader.GetDecimal("SR33");
			info.Sr34 = reader.GetDecimal("SR34");
			info.Sr35 = reader.GetDecimal("SR35");
			info.Sr36 = reader.GetDecimal("SR36");
			info.Sr37 = reader.GetDecimal("SR37");
			info.Sr38 = reader.GetDecimal("SR38");
			info.Sr39 = reader.GetDecimal("SR39");
			info.Sr40 = reader.GetDecimal("SR40");
			info.Sr41 = reader.GetDecimal("SR41");
			info.Sr42 = reader.GetDecimal("SR42");
			info.Sr43 = reader.GetDecimal("SR43");
			info.Sr44 = reader.GetDecimal("SR44");
			info.Sr45 = reader.GetDecimal("SR45");
			info.Sr46 = reader.GetDecimal("SR46");
			info.Sr47 = reader.GetDecimal("SR47");
			info.Sr48 = reader.GetDecimal("SR48");
			info.Sr49 = reader.GetDecimal("SR49");
			info.Sr50 = reader.GetDecimal("SR50");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(SrmxbInfo obj)
		{
		    SrmxbInfo info = obj as SrmxbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("HosID", info.HosID);
 			hash.Add("Year", info.Year);
 			hash.Add("Month", info.Month);
 			hash.Add("KSZD_ID", info.KszdId);
 			hash.Add("KSZD_Name", info.KSZD_Name);
 			hash.Add("YLSR", info.Ylsr);
 			hash.Add("YPSR", info.Ypsr);
            hash.Add("QTSR", info.Qtsr);
 			hash.Add("Total", info.Total);
 			hash.Add("SR1", info.Sr1);
 			hash.Add("SR2", info.Sr2);
 			hash.Add("SR3", info.Sr3);
 			hash.Add("SR4", info.Sr4);
 			hash.Add("SR5", info.Sr5);
 			hash.Add("SR6", info.Sr6);
 			hash.Add("SR7", info.Sr7);
 			hash.Add("SR8", info.Sr8);
 			hash.Add("SR9", info.Sr9);
 			hash.Add("SR10", info.Sr10);
 			hash.Add("SR11", info.Sr11);
 			hash.Add("SR12", info.Sr12);
 			hash.Add("SR13", info.Sr13);
 			hash.Add("SR14", info.Sr14);
 			hash.Add("SR15", info.Sr15);
 			hash.Add("SR16", info.Sr16);
 			hash.Add("SR17", info.Sr17);
 			hash.Add("SR18", info.Sr18);
 			hash.Add("SR19", info.Sr19);
 			hash.Add("SR20", info.Sr20);
 			hash.Add("SR21", info.Sr21);
 			hash.Add("SR22", info.Sr22);
 			hash.Add("SR23", info.Sr23);
 			hash.Add("SR24", info.Sr24);
 			hash.Add("SR25", info.Sr25);
 			hash.Add("SR26", info.Sr26);
 			hash.Add("SR27", info.Sr27);
 			hash.Add("SR28", info.Sr28);
 			hash.Add("SR29", info.Sr29);
 			hash.Add("SR30", info.Sr30);
 			hash.Add("SR31", info.Sr31);
 			hash.Add("SR32", info.Sr32);
 			hash.Add("SR33", info.Sr33);
 			hash.Add("SR34", info.Sr34);
 			hash.Add("SR35", info.Sr35);
 			hash.Add("SR36", info.Sr36);
 			hash.Add("SR37", info.Sr37);
 			hash.Add("SR38", info.Sr38);
 			hash.Add("SR39", info.Sr39);
 			hash.Add("SR40", info.Sr40);
 			hash.Add("SR41", info.Sr41);
 			hash.Add("SR42", info.Sr42);
 			hash.Add("SR43", info.Sr43);
 			hash.Add("SR44", info.Sr44);
 			hash.Add("SR45", info.Sr45);
 			hash.Add("SR46", info.Sr46);
 			hash.Add("SR47", info.Sr47);
 			hash.Add("SR48", info.Sr48);
 			hash.Add("SR49", info.Sr49);
 			hash.Add("SR50", info.Sr50);
 				
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
             dict.Add("HosID", "所属医院");
             dict.Add("Year", "年度");
             dict.Add("Month", "月度");
             dict.Add("KszdId", "科室代码");
             dict.Add("KSZD_Name", "科室名称");
             dict.Add("Ylsr", "医疗收入");
             dict.Add("Ypsr", "药品收入");
             dict.Add("Qtsr", "其他收入");
             dict.Add("Total", "总收入");
             dict.Add("Sr1", "SR1");
             dict.Add("Sr2", "SR2");
             dict.Add("Sr3", "SR3");
             dict.Add("Sr4", "SR4");
             dict.Add("Sr5", "SR5");
             dict.Add("Sr6", "SR6");
             dict.Add("Sr7", "SR7");
             dict.Add("Sr8", "SR8");
             dict.Add("Sr9", "SR9");
             dict.Add("Sr10", "SR10");
             dict.Add("Sr11", "SR11");
             dict.Add("Sr12", "SR12");
             dict.Add("Sr13", "SR13");
             dict.Add("Sr14", "SR14");
             dict.Add("Sr15", "SR15");
             dict.Add("Sr16", "SR16");
             dict.Add("Sr17", "SR17");
             dict.Add("Sr18", "SR18");
             dict.Add("Sr19", "SR19");
             dict.Add("Sr20", "SR20");
             dict.Add("Sr21", "SR21");
             dict.Add("Sr22", "SR22");
             dict.Add("Sr23", "SR23");
             dict.Add("Sr24", "SR24");
             dict.Add("Sr25", "SR25");
             dict.Add("Sr26", "SR26");
             dict.Add("Sr27", "SR27");
             dict.Add("Sr28", "SR28");
             dict.Add("Sr29", "SR29");
             dict.Add("Sr30", "SR30");
             dict.Add("Sr31", "SR31");
             dict.Add("Sr32", "SR32");
             dict.Add("Sr33", "SR33");
             dict.Add("Sr34", "SR34");
             dict.Add("Sr35", "SR35");
             dict.Add("Sr36", "SR36");
             dict.Add("Sr37", "SR37");
             dict.Add("Sr38", "SR38");
             dict.Add("Sr39", "SR39");
             dict.Add("Sr40", "SR40");
             dict.Add("Sr41", "SR41");
             dict.Add("Sr42", "SR42");
             dict.Add("Sr43", "SR43");
             dict.Add("Sr44", "SR44");
             dict.Add("Sr45", "SR45");
             dict.Add("Sr46", "SR46");
             dict.Add("Sr47", "SR47");
             dict.Add("Sr48", "SR48");
             dict.Add("Sr49", "SR49");
             dict.Add("Sr50", "SR50");
             #endregion

            return dict;
        }

    }
}