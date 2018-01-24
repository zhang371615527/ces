using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using System.Text;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 医疗绩效奖金汇总
    /// </summary>
	public class Yljxjjhz : BaseBLL<YljxjjhzInfo>
    {
        private IYljxjjhz iYljxjjhz_0;
        public Yljxjjhz() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxjjhz_0 = base.baseDal as IYljxjjhz;
        }

        /// <summary>
        /// 使用事务批量添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveExcelData(List<YljxjjhzInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = iYljxjjhz_0.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (YljxjjhzInfo detail in list)
                    {
                        BLLFactory<Yljxjjhz>.Instance.Insert(detail, sqlDbTransaction);
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
        /// 医疗绩效奖金汇总表
        /// </summary>
        /// <param name="intPageSize"></param>
        /// <param name="intPageCount"></param>
        /// <param name="mSizeBackup"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<YljxjjhzInfo> Yljxjjhz_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            dt = this.SqlTable("select Count(1) as RecordCount from Biz_Yljxjjhz where " + where);
            if (dt != null && dt.Rows.Count > 0)
                intRecordCount = Convert.ToInt32(dt.Rows[0]["RecordCount"]);
            int mSizeBackup = intPageSize;
            if (intPageCount * intPageSize > intRecordCount)
                intPageSize = intRecordCount - (intPageCount - 1) * intPageSize;
            if (intPageSize < 0)
                intPageSize = 0;
            sbsql.Append("Select * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageSize) + " * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageCount * mSizeBackup) + " Biz_Yljxjjhz.ID,Year,Month,AccountWay,Formula,Detail,");
            sbsql.Append(" Biz_Yljxjjhz.ZXZD_ID,Biz_Yljxjjhz.KSZD_ID,T_ACL_OU.Name as KSZD_Name,Value,");
            sbsql.Append(" Biz_Yljxjjhz.Creator,Biz_Yljxjjhz.CreateTime,");
            sbsql.Append(" Biz_Yljxjjhz.Editor,Biz_Yljxjjhz.EditTime,Biz_Yljxjjhz.Note");
            sbsql.Append(" from Biz_Yljxjjhz");
            sbsql.Append(" Left Join T_ACL_OU on T_ACL_OU.ID = KSZD_ID");
            sbsql.Append(" Where ");
            sbsql.Append(where);
            sbsql.Append(" Order By Year desc,Month desc,Biz_Yljxjjhz.ID");
            sbsql.Append(")a Order by a.Year,a.Month,a.ID desc)b");
            sbsql.Append(" Order by  b.Year desc, b.Month desc,b.ID");
            dt = iYljxjjhz_0.SqlTable(sbsql.ToString());

            List<YljxjjhzInfo> list = new List<YljxjjhzInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                YljxjjhzInfo info = new YljxjjhzInfo();
                info.ID = dr["ID"].ToString();
                info.Year = dr["Year"].ToString();
                info.Month = dr["Month"].ToString();
                info.AccountWay = dr["AccountWay"].ToString();
                info.Formula = dr["Formula"].ToString();
                info.Detail = dr["Detail"].ToString();
                info.ZxzdId = dr["ZXZD_ID"].ToString();
                info.KszdId = dr["KSZD_ID"].ToString();
                info.KszdName = dr["KSZD_Name"].ToString();
                info.Value = Convert.ToDecimal(dr["Value"]);
                info.Creator = dr["Creator"].ToString();
                //info.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                info.Editor = dr["Editor"].ToString();
                //info.EditTime = Convert.ToDateTime(dr["EditTime"]);
                info.Note = dr["Note"].ToString();
                list.Add(info);
            }
            return list;
        }
        public DataTable Yljxjjhz_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            DataTable dt = new DataTable();
            dt = iYljxjjhz_0.SqlTable(" exec P_Yljxjjhz_Params '" + strYear + "','" + strMonth + "'," + strKSID + ",'" + strZXZD_ID + "' ");
            return dt;
        }

        public bool Yljxjjhz_Insert(List<YljxjjhzInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = iYljxjjhz_0.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    foreach (YljxjjhzInfo detail in list)
                    {
                        iYljxjjhz_0.DeleteByCondition("Year = '" + detail.Year + "' and Month = '" + detail.Month + "' and KSZD_ID = '" + detail.KszdId + "'", sqlDbTransaction);
                        iYljxjjhz_0.Insert(detail, sqlDbTransaction);
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
        public DataTable Yljxjjhz_BSD(string strYear, string strMonth, string strKSZD_ID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select  Year,Month,KSZD_ID,b.Name as KSZD_Name,isnull(Formula,'') as Formula,Value ");
            strSQL.Append(" from Biz_Yljxjjhz  a inner join T_ACL_OU b on a.KSZD_ID = b.ID ");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "'");
            if (!String.IsNullOrEmpty(strKSZD_ID))
                strSQL.Append(" and KSZD_ID='" + strKSZD_ID + "'");
            strSQL.Append(" order by Year,Month,KSZD_ID");
            DataTable dt = iYljxjjhz_0.SqlTable(strSQL.ToString());
            return dt;
        }
    }
}
