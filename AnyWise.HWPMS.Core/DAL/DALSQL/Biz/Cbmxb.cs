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
    /// 成本明细表
    /// </summary>
	public class Cbmxb : BaseDALSQL<CbmxbInfo>, ICbmxb
	{
		#region 对象实例及构造函数

		public static Cbmxb Instance
		{
			get
			{
				return new Cbmxb();
			}
		}
		public Cbmxb() : base("BIZ_CBMXB","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override CbmxbInfo DataReaderToEntity(IDataReader dataReader)
		{
			CbmxbInfo info = new CbmxbInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.HosID = reader.GetString("HosID");
			info.Month = reader.GetString("Month");
			info.Kkcb = reader.GetDecimal("KKCB");
			info.Total = reader.GetDecimal("Total");
			info.ID = reader.GetString("ID");
			info.KszdId = reader.GetString("KSZD_ID");
			info.Cb1 = reader.GetDecimal("CB1");
			info.KSZD_Name = reader.GetString("KSZD_Name");
			info.Year = reader.GetString("Year");
			info.Fkkcb = reader.GetDecimal("FKKCB");
			info.Cb2 = reader.GetDecimal("CB2");
			info.Cb3 = reader.GetDecimal("CB3");
			info.Cb4 = reader.GetDecimal("CB4");
			info.Cb5 = reader.GetDecimal("CB5");
			info.Cb6 = reader.GetDecimal("CB6");
			info.Cb7 = reader.GetDecimal("CB7");
			info.Cb8 = reader.GetDecimal("CB8");
			info.Cb9 = reader.GetDecimal("CB9");
			info.Cb10 = reader.GetDecimal("CB10");
			info.Cb11 = reader.GetDecimal("CB11");
			info.Cb12 = reader.GetDecimal("CB12");
			info.Cb13 = reader.GetDecimal("CB13");
			info.Cb14 = reader.GetDecimal("CB14");
			info.Cb15 = reader.GetDecimal("CB15");
			info.Cb16 = reader.GetDecimal("CB16");
			info.Cb17 = reader.GetDecimal("CB17");
			info.Cb18 = reader.GetDecimal("CB18");
			info.Cb19 = reader.GetDecimal("CB19");
			info.Cb20 = reader.GetDecimal("CB20");
			info.Cb21 = reader.GetDecimal("CB21");
			info.Cb22 = reader.GetDecimal("CB22");
			info.Cb23 = reader.GetDecimal("CB23");
			info.Cb24 = reader.GetDecimal("CB24");
			info.Cb25 = reader.GetDecimal("CB25");
			info.Cb26 = reader.GetDecimal("CB26");
			info.Cb27 = reader.GetDecimal("CB27");
			info.Cb28 = reader.GetDecimal("CB28");
			info.Cb29 = reader.GetDecimal("CB29");
			info.Cb30 = reader.GetDecimal("CB30");
			info.Cb31 = reader.GetDecimal("CB31");
			info.Cb32 = reader.GetDecimal("CB32");
			info.Cb33 = reader.GetDecimal("CB33");
			info.Cb34 = reader.GetDecimal("CB34");
			info.Cb35 = reader.GetDecimal("CB35");
			info.Cb36 = reader.GetDecimal("CB36");
			info.Cb37 = reader.GetDecimal("CB37");
			info.Cb38 = reader.GetDecimal("CB38");
			info.Cb39 = reader.GetDecimal("CB39");
			info.Cb40 = reader.GetDecimal("CB40");
			info.Cb41 = reader.GetDecimal("CB41");
			info.Cb42 = reader.GetDecimal("CB42");
			info.Cb43 = reader.GetDecimal("CB43");
			info.Cb44 = reader.GetDecimal("CB44");
			info.Cb45 = reader.GetDecimal("CB45");
			info.Cb46 = reader.GetDecimal("CB46");
			info.Cb47 = reader.GetDecimal("CB47");
			info.Cb48 = reader.GetDecimal("CB48");
			info.Cb49 = reader.GetDecimal("CB49");
			info.Cb50 = reader.GetDecimal("CB50");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(CbmxbInfo obj)
		{
		    CbmxbInfo info = obj as CbmxbInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("HosID", info.HosID);
 			hash.Add("Month", info.Month);
 			hash.Add("KKCB", info.Kkcb);
 			hash.Add("Total", info.Total);
 			hash.Add("ID", info.ID);
 			hash.Add("KSZD_ID", info.KszdId);
 			hash.Add("CB1", info.Cb1);
 			hash.Add("KSZD_Name", info.KSZD_Name);
 			hash.Add("Year", info.Year);
 			hash.Add("FKKCB", info.Fkkcb);
 			hash.Add("CB2", info.Cb2);
 			hash.Add("CB3", info.Cb3);
 			hash.Add("CB4", info.Cb4);
 			hash.Add("CB5", info.Cb5);
 			hash.Add("CB6", info.Cb6);
 			hash.Add("CB7", info.Cb7);
 			hash.Add("CB8", info.Cb8);
 			hash.Add("CB9", info.Cb9);
 			hash.Add("CB10", info.Cb10);
 			hash.Add("CB11", info.Cb11);
 			hash.Add("CB12", info.Cb12);
 			hash.Add("CB13", info.Cb13);
 			hash.Add("CB14", info.Cb14);
 			hash.Add("CB15", info.Cb15);
 			hash.Add("CB16", info.Cb16);
 			hash.Add("CB17", info.Cb17);
 			hash.Add("CB18", info.Cb18);
 			hash.Add("CB19", info.Cb19);
 			hash.Add("CB20", info.Cb20);
 			hash.Add("CB21", info.Cb21);
 			hash.Add("CB22", info.Cb22);
 			hash.Add("CB23", info.Cb23);
 			hash.Add("CB24", info.Cb24);
 			hash.Add("CB25", info.Cb25);
 			hash.Add("CB26", info.Cb26);
 			hash.Add("CB27", info.Cb27);
 			hash.Add("CB28", info.Cb28);
 			hash.Add("CB29", info.Cb29);
 			hash.Add("CB30", info.Cb30);
 			hash.Add("CB31", info.Cb31);
 			hash.Add("CB32", info.Cb32);
 			hash.Add("CB33", info.Cb33);
 			hash.Add("CB34", info.Cb34);
 			hash.Add("CB35", info.Cb35);
 			hash.Add("CB36", info.Cb36);
 			hash.Add("CB37", info.Cb37);
 			hash.Add("CB38", info.Cb38);
 			hash.Add("CB39", info.Cb39);
 			hash.Add("CB40", info.Cb40);
 			hash.Add("CB41", info.Cb41);
 			hash.Add("CB42", info.Cb42);
 			hash.Add("CB43", info.Cb43);
 			hash.Add("CB44", info.Cb44);
 			hash.Add("CB45", info.Cb45);
 			hash.Add("CB46", info.Cb46);
 			hash.Add("CB47", info.Cb47);
 			hash.Add("CB48", info.Cb48);
 			hash.Add("CB49", info.Cb49);
 			hash.Add("CB50", info.Cb50);
 				
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
            dict.Add("HosID", "所属医院");
             dict.Add("Month", "月度");
             dict.Add("Kkcb", "可控成本");
             dict.Add("Total", "总成本");
             dict.Add("ID", "内码");
             dict.Add("KszdId", "科室代码");
             dict.Add("Cb1", "CB1");
             dict.Add("KSZD_Name", "科室名称");
             dict.Add("Year", "年度");
             dict.Add("Fkkcb", "非可控成本");
             dict.Add("Cb2", "CB2");
             dict.Add("Cb3", "CB3");
             dict.Add("Cb4", "CB4");
             dict.Add("Cb5", "CB5");
             dict.Add("Cb6", "CB6");
             dict.Add("Cb7", "CB7");
             dict.Add("Cb8", "CB8");
             dict.Add("Cb9", "CB9");
             dict.Add("Cb10", "CB10");
             dict.Add("Cb11", "CB11");
             dict.Add("Cb12", "CB12");
             dict.Add("Cb13", "CB13");
             dict.Add("Cb14", "CB14");
             dict.Add("Cb15", "CB15");
             dict.Add("Cb16", "CB16");
             dict.Add("Cb17", "CB17");
             dict.Add("Cb18", "CB18");
             dict.Add("Cb19", "CB19");
             dict.Add("Cb20", "CB20");
             dict.Add("Cb21", "CB21");
             dict.Add("Cb22", "CB22");
             dict.Add("Cb23", "CB23");
             dict.Add("Cb24", "CB24");
             dict.Add("Cb25", "CB25");
             dict.Add("Cb26", "CB26");
             dict.Add("Cb27", "CB27");
             dict.Add("Cb28", "CB28");
             dict.Add("Cb29", "CB29");
             dict.Add("Cb30", "CB30");
             dict.Add("Cb31", "CB31");
             dict.Add("Cb32", "CB32");
             dict.Add("Cb33", "CB33");
             dict.Add("Cb34", "CB34");
             dict.Add("Cb35", "CB35");
             dict.Add("Cb36", "CB36");
             dict.Add("Cb37", "CB37");
             dict.Add("Cb38", "CB38");
             dict.Add("Cb39", "CB39");
             dict.Add("Cb40", "CB40");
             dict.Add("Cb41", "CB41");
             dict.Add("Cb42", "CB42");
             dict.Add("Cb43", "CB43");
             dict.Add("Cb44", "CB44");
             dict.Add("Cb45", "CB45");
             dict.Add("Cb46", "CB46");
             dict.Add("Cb47", "CB47");
             dict.Add("Cb48", "CB48");
             dict.Add("Cb49", "CB49");
             dict.Add("Cb50", "CB50");
             #endregion

            return dict;
        }

    }
}