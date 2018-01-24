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
    /// 月度绩效考核表
    /// </summary>
	public class Ydjxkh : BaseBLL<YdjxkhInfo>
    {
        private IYdjxkh bll;
        public Ydjxkh() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.bll = base.baseDal as IYdjxkh;
        }

        public bool InsertMainAndSub(string strYear, string strMonth, string strCreator)
        {
            return bll.InsertMainAndSub(strYear, strMonth, strCreator);
        }

        public bool UpdateStateByID(string ID, string State, string strEditor)
        {
            return bll.UpdateStateByID(ID, State, strEditor);
        }

        public DataTable ExaSumExport(string strYear, string strMonth, string strResKS_ID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select  Year,Month,ResKS_ID,b.Name as ResKS_Name,State, SUM(ISNULL(TotalPoint,0)) as TotalPoint, AVG(ISNULL(AverageRatio,0)) as AverageRatio ");
            strSQL.Append(" from BIZ_YDJXKH  a inner join T_ACL_OU b on a.ResKS_ID = b.ID ");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "'");
            if (!String.IsNullOrEmpty(strResKS_ID))
                strSQL.Append(" and ResKS_ID='" + strResKS_ID + "'");
            strSQL.Append(" group by Year,Month,ResKS_ID,State,b.Name");
            strSQL.Append(" order by Year,Month,ResKS_ID,State");
            DataTable dt = bll.SqlTable(strSQL.ToString());
            return dt;
        }

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select Year,Month,ResKS_ID,b.Name as ResKS_Name, SUM(ISNULL(TotalPoint,0)) as TotalPoint, SUM(ISNULL(TOTALPOINT,0))/SUM(ISNULL(WeightPOINT,0)) as AverageRatio ");
            strSQL.Append(" from BIZ_YDJXKH  a inner join T_ACL_OU b on a.ResKS_ID = b.ID ");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "'");
            if (!String.IsNullOrEmpty(strResKS_ID))
                strSQL.Append(" and ResKS_ID='" + strResKS_ID + "'");
            strSQL.Append(" group by Year,Month,ResKS_ID,b.Name");
            strSQL.Append(" order by Year,Month,ResKS_ID");
            DataTable dt = bll.SqlTable(strSQL.ToString());
            return dt;
        }

        public DataTable GetDataTableByCheckKS(string strYear, string strMonth, string strCheckKS_ID)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("SELECT  ID, Year, Month, [Desc], ResKS_ID, CheckKS_ID , State ");
            strSQL.Append(" from BIZ_YDJXKH ");
            strSQL.Append(" where Year='" + strYear + "' and Month='" + strMonth + "' and (State='0' or State='2')");
            if (!String.IsNullOrEmpty(strCheckKS_ID))
                strSQL.Append(" and CheckKS_ID='" + strCheckKS_ID + "'");
            strSQL.Append(" order by Year,Month,ResKS_ID,State");
            DataTable dt = bll.SqlTable(strSQL.ToString());
            return dt;
        }
    }
}
