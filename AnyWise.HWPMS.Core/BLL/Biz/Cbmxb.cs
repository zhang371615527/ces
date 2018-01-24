using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using System.Reflection;
using AnyWise.Framework.Commons;
using System.Text;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 成本明细表
    /// </summary>
	public class Cbmxb : BaseBLL<CbmxbInfo>
    {
        private AnyWise.HWPMS.IDAL.ICbmxb icbmxb_0;
        public Cbmxb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.icbmxb_0 = base.baseDal as AnyWise.HWPMS.IDAL.ICbmxb;
        }
        
        public DataTable GetDataCount(string where)
        {
            DataTable dt = new DataTable();
            dt = icbmxb_0.SqlTable("select Count(1) as RecordCount from Biz_CBMXB where " + where);
            return dt;
        }

        public DataTable GetCbmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("Select * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageSize) + " * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageCount * mSizeBackup));
            sbsql.Append(" * from Biz_CBMXB Where ");
            sbsql.Append(where);
            sbsql.Append(" Order by  Year desc,Month desc,ID asc) a	");
            sbsql.Append("Order by a.Year,a.Month,a.ID desc)b ");
            sbsql.Append("Order by  b.Year desc, b.Month desc,b.ID asc");

            dt = icbmxb_0.SqlTable(sbsql.ToString());
            return dt;
        }

        public DataTable GetCbSrhzSumData(string where)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select a.Year,a.Month,a.KSZD_Name,ISNULL(a.Total,0) as CbTotal,ISNULL(a.KKCB,0) as KKCB,ISNULL(a.FKKCB,0) as FKKCB,");
            sbsql.Append(" ISNULL(b.Total,0) as SrTotal,ISNULL(b.YLSR,0) as YLSR,ISNULL(b.YPSR,0) as YPSR,ISNULL(b.QTSR,0) as QTSR ");
            sbsql.Append(" from BIZ_CBMXB a full join BIZ_SRMXB b on a.KSZD_ID=b.KSZD_ID and a.Year=b.Year and a.Month=b.Month where(1=1)");
            sbsql.Append(where);
            sbsql.Append(" union all ");
            sbsql.Append("select 'all','', '合计金额',ISNULL(sum(a.Total),0),ISNULL(sum(a.KKCB),0),ISNULL(sum(a.FKKCB),0),");
            sbsql.Append(" ISNULL(sum(b.Total),0),ISNULL(sum(b.YLSR),0),ISNULL(sum(b.YPSR),0),ISNULL(sum(b.QTSR),0)");
            sbsql.Append(" from BIZ_CBMXB a full join BIZ_SRMXB b on a.KSZD_ID=b.KSZD_ID and a.Year=b.Year and a.Month=b.Month where(1=1)");
            sbsql.Append(where);
            sbsql.Append(" order by a.Year,a.Month desc");

            dt = icbmxb_0.SqlTable(sbsql.ToString());
            return dt;
        }

        public bool SaveExcelData(List<CbmxbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (CbmxbInfo detail in list)
                    {
                        icbmxb_0.Insert(detail, transaction);
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
    }
}
