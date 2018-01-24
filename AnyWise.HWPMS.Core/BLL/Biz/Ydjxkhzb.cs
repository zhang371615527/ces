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

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 月度绩效考核子表
    /// </summary>
	public class Ydjxkhzb : BaseBLL<YdjxkhzbInfo>
    {
        private IYdjxkhzb bll;
        public Ydjxkhzb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.bll = base.baseDal as IYdjxkhzb;
        }
        public bool SaveScore(string Mid, string Ids)
        {
            return bll.SaveScore(Mid, Ids);
        }
        public bool SaveExcelData(List<YdjxkhzbInfo> list)
        {
            bool flag = false;
            DbTransaction sqlDbTransaction = base.CreateTransaction();
            if (sqlDbTransaction != null)
            {
                try
                {
                    //int seq = 1;
                    foreach (YdjxkhzbInfo detail in list)
                    {
                        //detail.Seq = seq++;//增加1
                        /*
                        detail.CreateTime = DateTime.Now;
                        detail.Creator = CurrentUser.ID.ToString();
                        detail.Editor = CurrentUser.ID.ToString();
                        detail.EditTime = DateTime.Now;
                        */
                        bll.Insert(detail, sqlDbTransaction);
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

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID, string strCheckKS_ID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select  Year,Month,ResKS_ID,c.name as ResKS_Name,CheckKS_ID,d.name as CheckKS_Name,CheckTime,g.FullName as Checker,State, Code, ParentCode, b.Name, [Content], NodeType, b.WeightPoint, Time, Method, LowerLimit, StandValue, TargetValue, HighLimit, b.Value, Unit, f.name as UnitName, Point, Ratio, b.Note ");
            strSQL.Append(" from BIZ_YDJXKH a right join BIZ_YDJXKHZB b on a.ID = b.YDJXKH_ID");
            strSQL.Append(" inner join T_ACL_OU c on a.ResKS_ID = c.ID ");
            strSQL.Append(" inner join T_ACL_OU d on a.CheckKS_ID = d.ID");
            strSQL.Append(" inner join TB_DictData f on b.unit = f.ID");
            strSQL.Append(" left join T_ACL_User g on a.Checker = g.Name");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "' and b.nodetype='Leaf'  ");
            if (!String.IsNullOrEmpty(strResKS_ID))
                strSQL.Append(" and ResKS_ID='" + strResKS_ID + "'");
            if (!String.IsNullOrEmpty(strCheckKS_ID))
                strSQL.Append(" and CheckKS_ID='" + strCheckKS_ID + "'");
            strSQL.Append(" order by Year,Month,ResKS_ID,CheckKS_ID,State,Code");
            DataTable dt = bll.SqlTable(strSQL.ToString());
            return dt;
        }

        public DataTable ExaDetExport(string strYear, string strMonth, string strResKS_ID, string strCheckKS_ID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select  Year,Month,ResKS_ID,c.name as ResKS_Name,CheckKS_ID,d.name as CheckKS_Name,CheckTime,g.FullName as Checker,State, Code, ParentCode, b.Name, [Content], NodeType, b.WeightPoint, Time, Method, LowerLimit, StandValue, TargetValue, HighLimit, b.Value, Unit, f.name as UnitName, Point, Ratio, b.Note ");
            strSQL.Append(" from BIZ_YDJXKH a right join BIZ_YDJXKHZB b on a.ID = b.YDJXKH_ID");
            strSQL.Append(" inner join T_ACL_OU c on a.ResKS_ID = c.ID ");
            strSQL.Append(" inner join T_ACL_OU d on a.CheckKS_ID = d.ID");
            strSQL.Append(" left join TB_DictData f on b.unit = f.ID");
            strSQL.Append(" left join T_ACL_User g on a.Checker = g.Name");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "' and b.nodetype='Leaf'  ");
            if (!String.IsNullOrEmpty(strResKS_ID))
                strSQL.Append(" and ResKS_ID='" + strResKS_ID + "'");
            if (!String.IsNullOrEmpty(strCheckKS_ID))
                strSQL.Append(" and CheckKS_ID='" + strCheckKS_ID + "'");
            strSQL.Append(" order by Year,Month,ResKS_ID,CheckKS_ID,State,Code");
            DataTable dt = bll.SqlTable(strSQL.ToString());
            return dt;
        }
    }
}
