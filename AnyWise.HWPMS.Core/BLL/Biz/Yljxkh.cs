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
    /// 医疗绩效二次考核
    /// </summary>
	public class Yljxkh : BaseBLL<YljxkhInfo>
    {
        private IYljxkh iYljxkh_0;
        public Yljxkh() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxkh_0 = base.baseDal as IYljxkh;
        }
        public bool SaveExcelData(List<YljxkhInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YljxkhInfo detail in list)
                    {
                        iYljxkh_0.Insert(detail, transaction);
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
        public List<YljxkhInfo> Yljxkh_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            where = where.Replace("ZXZD_ID", "Biz_Yljxkh.ZXZD_ID");
            where = where.Replace("CODE", "Biz_Yljxkh.CODE");
            List<YljxkhInfo> list = new List<YljxkhInfo>();
            DataTable dt = new DataTable();
            StringBuilder sbsql = new StringBuilder();
            dt = this.SqlTable("select Count(1) as RecordCount from Biz_Yljxkh where " + where);
            if (dt != null && dt.Rows.Count > 0)
                intRecordCount = Convert.ToInt32(dt.Rows[0]["RecordCount"]);
            int mSizeBackup = intPageSize;
            if (intPageCount * intPageSize > intRecordCount)
                intPageSize = intRecordCount - (intPageCount - 1) * intPageSize;
            if (intPageSize < 0)
                intPageSize = 0;
            sbsql.Append("Select * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageSize) + " * from ");
            sbsql.Append("(Select top " + Convert.ToString(intPageCount * mSizeBackup) + " Biz_Yljxkh.ID,Biz_Yljxkh.Code,Biz_Yljxkh.HosID,Year,Month,Weight,");
            sbsql.Append(" ResPersion,ResRy.Name as ResPersionName,ResKS_ID,ResKS.Name as ResKS_Name,");
            sbsql.Append(" Checker,CheRy.Name as CheckerName,CheckKS_ID,CheKS.Name as CheckKS_Name,");
            sbsql.Append(" Biz_Yljxkh.BeginDate,Biz_Yljxkh.EndDate,Biz_Yljxkh.CheckTime,Biz_Yljxkh.ZXZD_ID,");
            sbsql.Append(" Biz_Yljxkh.Type,Biz_Yljxkh.State,");
            sbsql.Append(" Biz_Yljxkh.Creator,Biz_Yljxkh.CreateTime,");
            sbsql.Append(" Biz_Yljxkh.Editor,Biz_Yljxkh.EditTime,Biz_Yljxkh.Note");
            sbsql.Append(" from Biz_Yljxkh");
            sbsql.Append(" Left Join T_ACL_OU ResKS on ResKS.ID = ResKS_ID");
            sbsql.Append(" Left Join T_ACL_OU CheKS on CheKS.ID = CheckKS_ID");
            sbsql.Append(" Left Join TB_RYZD ResRy on ResRy.ID = ResPersion");
            sbsql.Append(" Left Join TB_RYZD CheRy on CheRy.ID = Checker");
            sbsql.Append(" Where ");
            sbsql.Append(where);
            sbsql.Append(" Order By Year desc,Month desc,Biz_Yljxkh.ID");
            sbsql.Append(")a Order by a.Year,a.Month,a.ID desc)b");
            sbsql.Append(" Order by  b.Year desc, b.Month desc,b.ID");
            dt = this.SqlTable(sbsql.ToString());

            foreach (DataRow dr in dt.Rows)
            {
                YljxkhInfo info = new YljxkhInfo();
                info.ID = dr["ID"].ToString();
                info.Code = dr["Code"].ToString();
                info.HosID = dr["HosID"].ToString();
                info.Year = dr["Year"].ToString();
                info.Month = dr["Month"].ToString();
                info.Weight = Convert.ToDecimal(dr["Weight"]);
                info.ResPersion = dr["ResPersion"].ToString();
                info.ResPersionName = dr["ResPersionName"].ToString();
                info.ResKS_ID = dr["ResKS_ID"].ToString();
                info.ResKS_Name = dr["ResKS_Name"].ToString();
                info.Checker = dr["Checker"].ToString();
                info.CheckerName = dr["CheckerName"].ToString();
                info.CheckKS_ID = dr["CheckKS_ID"].ToString();
                info.CheckKS_Name = dr["CheckKS_Name"].ToString();
                info.BeginDate = Convert.ToDateTime(dr["BeginDate"]);
                info.EndDate = Convert.ToDateTime(dr["EndDate"]);
                if (dr["CheckTime"] != null && dr["CheckTime"].ToString() != "")
                    info.CheckTime = Convert.ToDateTime(dr["CheckTime"]);
                info.ZXZD_ID = dr["ZXZD_ID"].ToString();
                info.State = dr["State"].ToString();
                info.Creator = dr["Creator"].ToString();
                info.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                info.Editor = dr["Editor"].ToString();
                info.EditTime = Convert.ToDateTime(dr["EditTime"]);
                info.Note = dr["Note"].ToString();
                list.Add(info);
            }
            return list;
        }

        //更改绩效考核状态
        public int UpdateState(string IDs)
        {
            string[] sArray = IDs.Split(new char[] { ',' });
            string vsWhere = "";
            for (int i = 0; i < sArray.Length; i++)
            {
                vsWhere += "'" + sArray[i] + "'" + ",";
            }
            vsWhere = vsWhere.Substring(0, vsWhere.Length - 1);
            return baseDal.SqlExecute("Update Biz_Yljxkh set State = '1' where ID in (" + vsWhere + ") and State = '0'");
        }
    }
}
