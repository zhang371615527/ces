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
    /// 护理绩效间接工作量
    /// </summary>
    public class Hljxjjgzl : BaseDALSQL<HljxjjgzlInfo>, IHljxjjgzl
    {
        #region 对象实例及构造函数

        public static Hljxjjgzl Instance
        {
            get
            {
                return new Hljxjjgzl();
            }
        }
        public Hljxjjgzl()
            : base("BIZ_HLJXJJGZL", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override HljxjjgzlInfo DataReaderToEntity(IDataReader dataReader)
        {
            HljxjjgzlInfo info = new HljxjjgzlInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.Year = reader.GetString("Year");
            info.Month = reader.GetString("Month");
            info.Date = reader.GetDateTime("Date");
            info.KSZD_ID = reader.GetString("KSZD_ID");
            info.KSZD_Name = reader.GetString("KSZD_Name");
            info.BZCWS = reader.GetDecimal("BZCWS");
            info.KFCWS = reader.GetDecimal("KFCWS");
            info.ZYCWS = reader.GetDecimal("ZYCWS");
            info.CWSYL = reader.GetDecimal("CWSYL");
            info.PJZYR = reader.GetDecimal("PJZYR");
            info.RYRS = reader.GetDecimal("RYRS");
            info.CYRS = reader.GetDecimal("CYRS");
            info.SSLS = reader.GetDecimal("SSLS");
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
        protected override Hashtable GetHashByEntity(HljxjjgzlInfo obj)
        {
            HljxjjgzlInfo info = obj as HljxjjgzlInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("Date", info.Date);
            hash.Add("KSZD_ID", info.KSZD_ID);
            hash.Add("KSZD_Name", info.KSZD_Name);
            hash.Add("BZCWS", info.BZCWS);
            hash.Add("KFCWS", info.KFCWS);
            hash.Add("ZYCWS", info.ZYCWS);
            hash.Add("CWSYL", info.CWSYL);
            hash.Add("PJZYR", info.PJZYR);
            hash.Add("RYRS", info.RYRS);
            hash.Add("CYRS", info.CYRS);
            hash.Add("SSLS", info.SSLS);
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
            dict.Add("Year", "年");
            dict.Add("Month", "月");
            dict.Add("Date", "日期");
            dict.Add("KSZD_ID", "科室代码");
            dict.Add("KSZD_Name", "科室名称");
            dict.Add("BZCWS", "编制床位数");
            dict.Add("KFCWS", "实际开放床位数");
            dict.Add("ZYCWS", "实际占用床位数");
            dict.Add("CWSYL", "床位使用率");
            dict.Add("PJZYR", "平均住院日");
            dict.Add("RYRS", "入院人数");
            dict.Add("CYRS", "出院人数");
            dict.Add("SSLS", "手术例数");
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
