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
    /// 绩效奖金预算
    /// </summary>
    public class Jxys : BaseDALSQL<JxysInfo>, IJxys
    {
        #region 对象实例及构造函数
        public static Jxys Instance
		{
			get
			{
                return new Jxys();
			}
		}
        public Jxys()
            : base("BIZ_Jxys", "ID")
		{
		}
		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
        protected override JxysInfo DataReaderToEntity(IDataReader dataReader)
		{
            JxysInfo info = new JxysInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetString("ID");
            info.Year = reader.GetString("Year");
            info.ZXZD_ID = reader.GetString("ZXZD_ID");
            info.Value = reader.GetDecimal("Value");
            info.KSZD_ID = reader.GetString("KSZD_ID");
            info.Ratio = reader.GetString("Ratio");
            info.YsMoney = reader.GetDecimal("YsMoney");
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
        protected override Hashtable GetHashByEntity(JxysInfo obj)
		{
            JxysInfo info = obj as JxysInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
            hash.Add("Year", info.Year);
            hash.Add("ZXZD_ID", info.ZXZD_ID);
            hash.Add("Value", info.Value);
            hash.Add("KSZD_ID", info.KSZD_ID);
            hash.Add("Ratio", info.Ratio);
            hash.Add("YsMoney", info.YsMoney);
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
            dict.Add("ID", "内码");
            dict.Add("Year", "年度");
            dict.Add("ZXZD_ID", "职系");
            dict.Add("Value", "金额");
            dict.Add("KSZD_ID", "科室ID");
             dict.Add("Ratio", "核算比率");
             dict.Add("YsMoney", "预算金额");
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
