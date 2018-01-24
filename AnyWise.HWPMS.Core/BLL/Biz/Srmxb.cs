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
using System.Text;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 收入明细表
    /// </summary>
	public class Srmxb : BaseBLL<SrmxbInfo>
    {
        private AnyWise.HWPMS.IDAL.ISrmxb isrmxb_0;
        public Srmxb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.isrmxb_0 = base.baseDal as AnyWise.HWPMS.IDAL.ISrmxb;
        }

        public DataTable GetDataCount(string where)
        {
            DataTable dt = new DataTable();
            dt = isrmxb_0.SqlTable("select Count(1) as RecordCount from Biz_SRMXB where " + where);
            return dt;
        }

        public DataTable GetSrmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("Select * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageSize) + " * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageCount * mSizeBackup));
            sbsql.Append(" * from Biz_SRMXB Where ");
            sbsql.Append(where);
            sbsql.Append(" Order by  Year desc,Month desc,ID asc) a	");
            sbsql.Append("Order by a.Year,a.Month,a.ID desc)b ");
            sbsql.Append("Order by  b.Year desc, b.Month desc,b.ID asc");

            dt = isrmxb_0.SqlTable(sbsql.ToString());
            return dt;
        }

        public DataTable GetSrhzSumData(string where)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select  Year,Month,KSZD_Name,ISNULL(YLSR,0) as YLSR,ISNULL(YPSR,0) as YPSR,ISNULL(QTSR,0) as QTSR,ISNULL(Total,0) as Total from BIZ_SRMXB where(1=1)");
            sbsql.Append(where);
            sbsql.Append(" order by Year,Month");

            dt = isrmxb_0.SqlTable(sbsql.ToString());
            return dt;
        }

        public bool SaveExcelData(List<SrmxbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (SrmxbInfo detail in list)
                    {
                        isrmxb_0.Insert(detail, transaction);
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
