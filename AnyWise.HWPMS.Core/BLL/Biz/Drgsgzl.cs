 using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// DRGs工作量
    /// </summary>
    public class Drgsgzl : BaseBLL<DrgsgzlInfo>
    {
        private IDrgsgzl idrgsgzl_0;
        public Drgsgzl()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.idrgsgzl_0 = base.baseDal as IDrgsgzl;
        }
        public bool InsertBatch(List<DrgsgzlInfo> list)
        {
            return idrgsgzl_0.InsertBatch(list);
        }
        //DRGS,CMI折线图
        public DataTable DRGSAna_CMIAna(string where)
        {
            return idrgsgzl_0.DRGSAna_CMIAna(where);
        }

        #region 收入折线图
        public string DRGSAna_GetxAxis(string Year)
        {
            Year = Year.Substring(0, 4);
            StringBuilder sb = new StringBuilder();
            string vsSql = "select Distinct Year+Month as Period  from Biz_DrgsGzl where Year = '" + Year + "' order by Year+Month asc";
            DataTable dt = new DataTable();
            dt = this.SqlTable(vsSql);
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("\"" + dr["Period"].ToString() + "\",");
            }
            string s = "[]";
            if (sb.Length > 0)
                s = "[" + sb.Remove(sb.Length - 1, 1).ToString() + "]";
            return s;
        }
        public string DRGSAna_GetIncome(string Year)
        {
            Year = Year.Substring(0, 4);
            StringBuilder sb = new StringBuilder();
            string KsList = "全院,";
            string vsSql = "Select '全院' as Name,Month,Sum(Value) as Value from Biz_DrgsGzl where Year = '" + Year + "' "
                + " Group by Month "
                + " Union All "
                + " Select T_ACL_OU.Name as Name,Month,Sum(Value) as Value from Biz_DrgsGzl "
                + " Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID where Year = '" + Year + "' "
                + " Group by T_ACL_OU.Name,Month Order by Month ";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = this.SqlTable(vsSql);
            dt1 = dt.Copy();
            foreach (DataRow dr in dt.Rows)
            {
                if (KsList.IndexOf(dr["Name"].ToString()) >= 0)
                    continue;
                KsList += dr["Name"].ToString() + ",";
                dt1.DefaultView.RowFilter = "name= '" + dr["Name"].ToString() + "'";
                string vData = "";
                foreach (DataRow vRow in dt1.DefaultView.ToTable().Rows)
                {
                    vData += vRow["Value"].ToString() + ",";
                }
                if (vData.Length > 0)
                    sb.Append("{\"name\":\"" + dr["Name"].ToString() + "\",\"data\":[" + vData.Substring(0, vData.Length - 1) + "]},");
            }
            string s = "[]";
            if (sb.Length > 0)
                s = "[" + sb.Remove(sb.Length - 1, 1).ToString() + "]";
            return s;
        }
        #endregion

        #region DRGs绩效指标查询
        public List<ExpandoObject> DRGSAna_DRGsDetail(string BeginPeriod, string EndPeriod)
        {
            string vsWhere = "";
            StringBuilder sb = new StringBuilder();
            vsWhere = " Biz_DrgsGzl.Year+Biz_DrgsGzl.Month >= '" + BeginPeriod + "' and Biz_DrgsGzl.Year+Biz_DrgsGzl.Month<='" + EndPeriod + "'";
            #region 根据条件查询表数据
            sb.Append(" Select '全院' as KSName,'' as RYName,Count(AA.DRGsID) as DRGsCount from (select distinct DRGsID from Biz_DrgsGzl where " + vsWhere + " ) AA ");
            sb.Append(" Union All ");
            sb.Append(" Select KSName,'小计' as RYName,Count(AA.DRGsID) as DRGsCount from (select distinct T_ACL_OU.Name as KSName,DRGsID from Biz_DrgsGzl ");
            sb.Append(" Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID where " + vsWhere + " ) AA Group By KSName ");
            sb.Append(" Union All ");
            sb.Append(" Select KSName,RYName,Count(AA.DRGsID) as DRGsCount from (select distinct T_ACL_OU.Name as KSName,TB_Ryzd.Name as RYName,DRGsID from Biz_DrgsGzl ");
            sb.Append(" Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID Inner Join TB_Ryzd on Biz_DrgsGzl.ExecRYZD_ID = TB_Ryzd.ID where " + vsWhere + " ) AA Group By KSName,RYName ");
            DataTable dt1 = this.SqlTable(sb.ToString());

            sb.Clear();
            sb.Append(" Select '全院' as KSName,'' as RYName,IsNull(Sum(WeightPoint*Quantity),0) as RW,IsNull(Sum(Quantity),0) as Quan from Biz_DrgsGzl ");
            sb.Append(" Inner Join TB_DRGsSort on Biz_DrgsGzl.DrgsID = TB_DRGsSort.Code");
            sb.Append(" where " + vsWhere + " ");
            sb.Append(" Union All ");
            sb.Append(" Select T_ACL_OU.Name as KSName,'小计' as RYName,IsNull(Sum(WeightPoint*Quantity),0) as RW,IsNull(Sum(Quantity),0) as Quan from Biz_DrgsGzl ");
            sb.Append(" Inner Join TB_DRGsSort on Biz_DrgsGzl.DrgsID = TB_DRGsSort.Code");
            sb.Append(" Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID");
            sb.Append(" where " + vsWhere + " ");
            sb.Append(" Group by T_ACL_OU.Name");
            sb.Append(" Union All");
            sb.Append(" Select T_ACL_OU.Name as KSName,TB_Ryzd.Name as RYName,IsNull(Sum(WeightPoint*Quantity),0) as RW,IsNull(Sum(Quantity),0) as Quan from Biz_DrgsGzl ");
            sb.Append(" Inner Join TB_DRGsSort on Biz_DrgsGzl.DrgsID = TB_DRGsSort.Code");
            sb.Append(" Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID");
            sb.Append(" Inner Join TB_Ryzd on Biz_DrgsGzl.ExecRYZD_ID = TB_Ryzd.ID");
            sb.Append(" where " + vsWhere + " ");
            sb.Append(" Group by T_ACL_OU.Name,TB_Ryzd.Name");
            DataTable dt2 = this.SqlTable(sb.ToString());

            sb.Clear();
            sb.Append(" select '全院' as KSName,'' as RYName,IsNull(Sum(TB_DRGSSort.WeightPoint*BIZ_DRGSGZL.Quantity)/");
            sb.Append(" (Select Sum(Quantity) from BIZ_DRGSGZL DRGs where Year = '2017'),0) as CMI ");
            sb.Append(" from BIZ_DRGSGZL inner join TB_DRGSSort on BIZ_DRGSGZL.DRGsID = TB_DRGSSort.Code  ");
            sb.Append(" where " + vsWhere + "");
            sb.Append(" Union ALL ");
            sb.Append(" select T_ACL_OU.Name as KSName,'小计' as RYName,IsNull(Sum(TB_DRGSSort.WeightPoint*BIZ_DRGSGZL.Quantity)/");
            sb.Append(" (Select Sum(Quantity) from BIZ_DRGSGZL DRGs where Year = '2017' and DRGs.ExecKSID = BIZ_DRGSGZL.ExecKSID),0) as CMI ");
            sb.Append(" from BIZ_DRGSGZL inner join TB_DRGSSort on BIZ_DRGSGZL.DRGsID = TB_DRGSSort.Code  ");
            sb.Append(" Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID ");
            sb.Append(" where " + vsWhere + "");
            sb.Append(" Group BY BIZ_DRGSGZL.ExecKSID,T_ACL_OU.Name");
            sb.Append(" Union ALL");
            sb.Append(" select T_ACL_OU.Name as KSName,TB_Ryzd.Name as RYName,IsNull(Sum(TB_DRGSSort.WeightPoint*BIZ_DRGSGZL.Quantity)/");
            sb.Append(" (Select Sum(Quantity) from BIZ_DRGSGZL DRGs ");
            sb.Append(" where Year = '2017' and DRGs.ExecKSID = BIZ_DRGSGZL.ExecKSID and DRGs.ExecRYZD_ID = BIZ_DRGSGZL.ExecRYZD_ID),0) as CMI ");
            sb.Append(" from BIZ_DRGSGZL inner join TB_DRGSSort on BIZ_DRGSGZL.DRGsID = TB_DRGSSort.Code  ");
            sb.Append(" Inner Join T_ACL_OU on Biz_DrgsGzl.ExecKSID = T_ACL_OU.ID ");
            sb.Append(" Inner Join TB_Ryzd on Biz_DrgsGzl.ExecRYZD_ID = TB_Ryzd.ID");
            sb.Append(" where " + vsWhere + "");
            sb.Append(" Group BY BIZ_DRGSGZL.ExecKSID,BIZ_DRGSGZL.ExecRYZD_ID,T_ACL_OU.Name,TB_Ryzd.Name");
            DataTable dt3 = this.SqlTable(sb.ToString());
            #endregion

            List<ExpandoObject> objList = new List<ExpandoObject>();
            dt1.DefaultView.RowFilter = "KSName = '全院'";
            foreach (DataRow dr in dt1.DefaultView.ToTable().Rows)
            {
                dynamic obj = new ExpandoObject();
                obj.KSName = dr["KSName"].ToString();
                obj.RYName = dr["RYName"].ToString();
                obj.DRGsCount = Convert.ToInt32(dr["DRGsCount"]);
                dt2.DefaultView.RowFilter = "KSName = '" + dr["KSName"].ToString() + "' and RYName = '" + dr["RYName"].ToString() + "'";
                foreach (DataRow vRow in dt2.DefaultView.ToTable().Rows)
                {
                    obj.RW = Convert.ToDecimal(vRow["RW"]);
                    obj.Quan = Convert.ToDecimal(vRow["Quan"]);
                }
                dt3.DefaultView.RowFilter = "KSName = '" + dr["KSName"].ToString() + "' and RYName = '" + dr["RYName"].ToString() + "'";
                foreach (DataRow vRow in dt3.DefaultView.ToTable().Rows)
                {
                    obj.CMI = Convert.ToDecimal(vRow["CMI"]);
                }
                objList.Add(obj);
            }
            dt1.DefaultView.RowFilter = "RYName = '小计'";
            foreach (DataRow dr in dt1.DefaultView.ToTable().Rows)
            {
                dynamic obj = new ExpandoObject();
                obj.KSName = dr["KSName"].ToString();
                obj.RYName = dr["RYName"].ToString();
                obj.DRGsCount = Convert.ToInt32(dr["DRGsCount"]);
                dt2.DefaultView.RowFilter = "KSName = '" + dr["KSName"].ToString() + "' and RYName = '" + dr["RYName"].ToString() + "'";
                foreach (DataRow vRow in dt2.DefaultView.ToTable().Rows)
                {
                    obj.RW = Convert.ToDecimal(vRow["RW"]);
                    obj.Quan = Convert.ToDecimal(vRow["Quan"]);
                }
                dt3.DefaultView.RowFilter = "KSName = '" + dr["KSName"].ToString() + "' and RYName = '" + dr["RYName"].ToString() + "'";
                foreach (DataRow vRow in dt3.DefaultView.ToTable().Rows)
                {
                    obj.CMI = Convert.ToDecimal(vRow["CMI"]);
                }
                objList.Add(obj);
                foreach (DataRow RyRow in dt1.Copy().Select("KSName = '" + dr["KSName"].ToString() + "' and RYName <> '" + dr["RYName"].ToString() + "'"))
                {
                    dynamic objDetail = new ExpandoObject();
                    objDetail.KSName = RyRow["KSName"].ToString();
                    objDetail.RYName = RyRow["RYName"].ToString();
                    objDetail.DRGsCount = Convert.ToInt32(RyRow["DRGsCount"]);
                    dt2.DefaultView.RowFilter = "KSName = '" + RyRow["KSName"].ToString() + "' and RYName = '" + RyRow["RYName"].ToString() + "'";
                    foreach (DataRow vRow in dt2.DefaultView.ToTable().Rows)
                    {
                        objDetail.RW = Convert.ToDecimal(vRow["RW"]);
                        objDetail.Quan = Convert.ToDecimal(vRow["Quan"]);
                    }
                    dt3.DefaultView.RowFilter = "KSName = '" + RyRow["KSName"].ToString() + "' and RYName = '" + RyRow["RYName"].ToString() + "'";
                    foreach (DataRow vRow in dt3.DefaultView.ToTable().Rows)
                    {
                        objDetail.CMI = Convert.ToDecimal(vRow["CMI"]);
                    }
                    objList.Add(objDetail);
                }
            }
            return objList;
        }
        #endregion
    }
}
