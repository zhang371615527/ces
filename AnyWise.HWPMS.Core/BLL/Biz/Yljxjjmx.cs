using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 医疗绩效奖金明细
    /// </summary>
	public class Yljxjjmx : BaseBLL<YljxjjmxInfo>
    {
        private IYljxjjmx iYljxjjmx_0;
        public Yljxjjmx() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxjjmx_0 = base.baseDal as IYljxjjmx;
        }
        public bool SaveExcelData(List<YljxjjmxInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YljxjjmxInfo detail in list)
                    {
                        iYljxjjmx_0.Insert(detail, transaction);
                    }
                    transaction.Commit();
                    result = true;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    LogTextHelper.Error(exception);
                }
            }
            return result;
        }
        //医疗绩效奖金明细表
        public List<YljxjjmxInfo> Yljxjjmx_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            List<YljxjjmxInfo> list = new List<YljxjjmxInfo>();
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            dt = this.SqlTable("select Count(1) as RecordCount from Biz_Yljxjjmx where " + where);
            if (dt != null && dt.Rows.Count > 0)
                intRecordCount = Convert.ToInt32(dt.Rows[0]["RecordCount"]);
            int mSizeBackup = intPageSize;
            if (intPageCount * intPageSize > intRecordCount)
                intPageSize = intRecordCount - (intPageCount - 1) * intPageSize;
            if (intPageSize < 0)
                intPageSize = 0;
            sbsql.Append("Select * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageSize) + " * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageCount * mSizeBackup) + " * ");
            sbsql.Append(" from Biz_Yljxjjmx");
            sbsql.Append(" Where ");
            sbsql.Append(where);
            sbsql.Append(" Order By Year desc,Month desc,Biz_Yljxjjmx.ID");
            sbsql.Append(")a Order by a.Year,a.Month,a.ID desc)b");
            sbsql.Append(" Order by  b.Year desc, b.Month desc,b.ID");
            dt = this.SqlTable(sbsql.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                YljxjjmxInfo info = new YljxjjmxInfo();
                info.ID = dr["ID"].ToString();
                info.Year = dr["Year"].ToString();
                info.Month = dr["Month"].ToString();
                info.KszdId = dr["KSZD_ID"].ToString();
                info.KSZD_Name = dr["KSZD_Name"].ToString();
                info.Fpid = dr["FPID"].ToString();
                info.CardNum = dr["CardNum"].ToString();
                info.RYZD_Name = dr["RYZD_Name"].ToString();
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
        //医疗绩效奖金明细表Calculate
        public DataTable Yljxjjmx_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID)
        {
            DataTable dt = new DataTable();
            dt = iYljxjjmx_0.SqlTable(" exec P_Yljxjjmx_Params '" + strYear + "','" + strMonth + "'," + strKSID + ",'" + strZXZD_ID + "' ");
            return dt;
        }
        public bool Yljxjjmx_Insert(List<YljxjjmxInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = iYljxjjmx_0.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    foreach (YljxjjmxInfo detail in list)
                    {


                        this.DeleteByCondition("Year = '" + detail.Year + "' and Month = '" + detail.Month + "' and KSZD_ID = '" + detail.KszdId + "' and CardNum = '" + detail.CardNum + "' and Ryzd_Name = '" + detail.RYZD_Name + "'", sqlDbTransaction);

                        iYljxjjmx_0.Insert(detail, sqlDbTransaction);
                        
                        string vsUpdateSql = "update biz_Yljxjjmx set KSZD_Name = (select Name from T_ACL_OU where T_ACL_OU.ID =biz_Yljxjjmx.KSZD_ID)"
                                        + " where ID =  '" + detail.ID + "'";
                        baseDal.SqlExecute(vsUpdateSql, sqlDbTransaction);
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

        //医疗绩效奖金明细表BonusSumData
        public DataTable Yljxjjmx_BDD(string strYear, string strMonth, string strKSZD_ID, string strFPLBID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select  Year,Month,KSZD_ID,KSZD_Name,CardNum,Ryzd_Name,TB_DictData.Name as FPLBName,Biz_Yljxjjmx.Value,Note ");
            strSQL.Append(" from Biz_Yljxjjmx  ");
            strSQL.Append(" left Join TB_DictData on Biz_Yljxjjmx.FPID = TB_DictData.ID  ");
            strSQL.Append(" left Join TB_DictType on TB_DictType.ID = TB_DictData.DictType_ID  ");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "' and TB_DictType.Name = '分配类别' ");
            if (!String.IsNullOrEmpty(strKSZD_ID))
                strSQL.Append(" and KSZD_ID='" + strKSZD_ID + "'");
            if (!String.IsNullOrEmpty(strFPLBID))
                strSQL.Append(" and FPID='" + strFPLBID + "'");
            strSQL.Append(" order by Year,Month,KSZD_ID");
            DataTable dt = BLLFactory<Yljxjjhz>.Instance.SqlTable(strSQL.ToString());
            return dt;
        }
        
    }
}
