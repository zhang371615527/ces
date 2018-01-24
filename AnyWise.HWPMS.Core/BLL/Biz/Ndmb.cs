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
    /// 年度目标表
    /// </summary>
	public class Ndmb : BaseBLL<NdmbInfo>
    {
        private AnyWise.HWPMS.IDAL.INdmb indmb_0;
        public Ndmb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.indmb_0 = base.baseDal as AnyWise.HWPMS.IDAL.INdmb;
        }

        public DataTable GetNdmbData(string where)
        {
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select Biz_Ndmb.Code,Biz_Ndmb.HosID,Year,ManKS.Name as ManKSName,SubKS.Name as SubKSName,");
            sbsql.Append(" SubRy.Name as SubRyName,SubTime,Biz_Ndmb.Creator,Biz_Ndmb.CreateTime,Biz_Ndmb.Note");
            sbsql.Append(" from Biz_Ndmb");
            sbsql.Append(" Left Join T_ACL_OU ManKS on ManKS.ID = ManDep_ID");
            sbsql.Append(" Left Join T_ACL_OU SubKS on SubKS.ID = SubDep_ID");
            sbsql.Append(" Left Join TB_RYZD SubRy on SubRy.ID = SubUser_ID");
            sbsql.Append(" Where ");
            sbsql.Append(where);
            sbsql.Append(" order by Year desc,Code ");
            dt = indmb_0.SqlTable(sbsql.ToString());

            return dt;
        }

        public bool SaveExcelData(List<NdmbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (NdmbInfo detail in list)
                    {
                        indmb_0.Insert(detail, transaction);
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
