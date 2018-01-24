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
    /// Drgs工作量
    /// </summary>
    public class Drgsgzl : BaseDALSQL<DrgsgzlInfo>, IDrgsgzl
    {
        #region 对象实例及构造函数

        public static Drgsgzl Instance
        {
            get
            {
                return new Drgsgzl();
            }
        }
        public Drgsgzl()
            : base("BIZ_Drgsgzl", "ID")
        {
        }

        #endregion

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override DrgsgzlInfo DataReaderToEntity(IDataReader dataReader)
        {
            DrgsgzlInfo info = new DrgsgzlInfo();
            SmartDataReader reader = new SmartDataReader(dataReader);

            info.ID = reader.GetString("ID");
            info.Year = reader.GetString("Year");
            info.Month = reader.GetString("Month");
            info.Date = reader.GetDateTime("Date");
            info.DrgsID = reader.GetString("DrgsID");
            info.MainDiagnosis = reader.GetString("MainDiagnosis");
            info.OtherDiagnostics = reader.GetString("OtherDiagnostics");
            info.ICD_ID = reader.GetString("ICD_ID");
            info.Surgery_ID = reader.GetString("Surgery_ID");
            info.DischargeMethod = reader.GetString("DischargeMethod");
            info.KSZD_ID = reader.GetString("KSZD_ID");
            info.RYZD_ID = reader.GetString("RYZD_ID");
            info.ExecKSID = reader.GetString("ExecKSID");
            info.ExecRYZD_ID = reader.GetString("ExecRYZD_ID");
            info.Unit = reader.GetString("Unit");
            info.Quantity = reader.GetDecimal("Quantity");
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
        protected override Hashtable GetHashByEntity(DrgsgzlInfo obj)
        {
            DrgsgzlInfo info = obj as DrgsgzlInfo;
            Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
            hash.Add("Year", info.Year);
            hash.Add("Month", info.Month);
            hash.Add("Date", info.Date);
            hash.Add("DrgsID", info.DrgsID);
            hash.Add("MainDiagnosis", info.MainDiagnosis);
            hash.Add("OtherDiagnostics", info.OtherDiagnostics);
            hash.Add("ICD_ID", info.ICD_ID);
            hash.Add("Surgery_ID", info.Surgery_ID);
            hash.Add("DischargeMethod", info.DischargeMethod);
            hash.Add("KSZD_ID", info.KSZD_ID);
            hash.Add("RYZD_ID", info.RYZD_ID);
            hash.Add("ExecKSID", info.ExecKSID);
            hash.Add("ExecRYZD_ID", info.ExecRYZD_ID);
            hash.Add("Unit", info.Unit);
            hash.Add("Quantity", info.Quantity);
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
            dict.Add("Year", "年");
            dict.Add("Month", "月");
            dict.Add("Date", "日期");
            dict.Add("MainDiagnosis", "主要诊断");
            dict.Add("OtherDiagnostics", "其他诊断");
            dict.Add("ICD_ID", "疾病代码");
            dict.Add("Surgery_ID", "手术编码");
            dict.Add("DischargeMethod", "出院方式");
            dict.Add("KSZD_ID", "开单科室代码");
            dict.Add("RYZD_ID", "开单医生代码");
            dict.Add("ExecKSID", "执行科室代码");
            dict.Add("ExecRYZD_ID", "执行医生代码");
            dict.Add("Unit", "计量单位代码");
            dict.Add("Quantity", "数量");
            dict.Add("Value", "金额");
            dict.Add("Creator", "创建人");
            dict.Add("CreateTime", "创建时间");
            dict.Add("Editor", "修改人");
            dict.Add("EditTime", "修改时间");
            dict.Add("Note", "备注");
            #endregion

            return dict;
        }

        /// <summary>
        /// 使用事务批量添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(List<DrgsgzlInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (DrgsgzlInfo detail in list)
                    {
                        //detail.Seq = seq++;//增加1
                        /*
                        detail.CreateTime = DateTime.Now;
                        detail.Creator = CurrentUser.ID.ToString();
                        detail.Editor = CurrentUser.ID.ToString();
                        detail.EditTime = DateTime.Now;
                        */
                        this.Insert(detail, sqlDbTransaction);
                    }
                    sqlDbTransaction.Commit();
                    flag = true;
                }
                catch
                {
                    sqlDbTransaction.Rollback();
                    throw;
                }
            }
            return flag;
        }
        /// <summary>
        /// 返回CMI折线图数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable DRGSAna_CMIAna(string where)
        {
            DataTable dt = new DataTable();
            StringBuilder dtsql = new StringBuilder();
            dtsql.Append("select Year,Month,Sum(TB_DRGSSort.WeightPoint*BIZ_DRGSGZL.Quantity)/");
            dtsql.Append("(Select Sum(Quantity) from BIZ_DRGSGZL DRGs where DRGs.Year = BIZ_DRGSGZL.Year and DRGs.Month = BIZ_DRGSGZL.Month) as CMI ");
            dtsql.Append("from BIZ_DRGSGZL inner join TB_DRGSSort on BIZ_DRGSGZL.DRGsID = TB_DRGSSort.Code Where ");
            dtsql.Append(where);
            dtsql.Append(" group by Year,Month");
            dt = this.SqlTable(dtsql.ToString());
            return dt;
        }
    }
}
