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
    /// 月度目标表
    /// </summary>
	public class Ydmb : BaseBLL<YdmbInfo>
    {
        private AnyWise.HWPMS.IDAL.IYdmb iydmb_0;
        public Ydmb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.iydmb_0 = base.baseDal as AnyWise.HWPMS.IDAL.IYdmb;
        }
        
        public DataTable GetNdmbDataByCond(string where)
        {
            DataTable dt = iydmb_0.SqlTable("Select Biz_Ndmbzb.ID,Biz_Ndmb.Code,Biz_Ndmbzb.Type,KHZB_ID,Biz_Khflb.Name as KHZB_Name "
                            + " From Biz_Ndmbzb "
                            + " Inner Join Biz_Ndmb on Biz_Ndmbzb.Ndmb_ID = Biz_Ndmb.ID "
                            + " Left Join Biz_Khflb on Biz_Ndmbzb.KHZB_ID = Biz_Khflb.ID where " + where);
            return dt;
        }

        public DataTable GetNdmbDataById(string ID)
        {
            DataTable dt = iydmb_0.SqlTable("Select Biz_Ndmbzb.ID,Biz_Ndmb.Code,Biz_Ndmbzb.Type,KHZB_ID,Biz_Khflb.Name as KHZB_Name "
                    + " From Biz_Ndmbzb "
                    + " Inner Join Biz_Ndmb on Biz_Ndmbzb.Ndmb_ID = Biz_Ndmb.ID "
                    + " Left Join Biz_Khflb on Biz_Ndmbzb.KHZB_ID = Biz_Khflb.ID where BIZ_NDMBZB.ID = '" + ID + "'");
            return dt;
        }

        public DataTable GetNdmbDataByIds(string IDs)
        {
            DataTable dt = iydmb_0.SqlTable("Select Biz_Ndmbzb.ID,Biz_Ndmb.Code,Biz_Ndmbzb.Type,KHZB_ID,Biz_Khflb.Name as KHZB_Name "
                    + " From Biz_Ndmbzb "
                    + " Inner Join Biz_Ndmb on Biz_Ndmbzb.Ndmb_ID = Biz_Ndmb.ID "
                    + " Left Join Biz_Khflb on Biz_Ndmbzb.KHZB_ID = Biz_Khflb.ID where BIZ_NDMBZB.ID in (" + IDs + ")");
            return dt;
        }
        public DataTable GetNdmbDataByYear(string Year)
        {
            string vsSql = "";
            if (Year != null && Year != "")
                vsSql = "SELECT BIZ_NDMBZB.ID,BIZ_NDMB.CODE,BIZ_NDMB.ManDep_ID,Man.Name as ManDep_Name, "
                    + " BIZ_NDMB.SubDep_ID,Sub.Name as SubDep_Name,BIZ_NDMBZB.Type,KHZB_ID,BIZ_KHFLB.NAME AS KHZB_Name "
                    + " From Biz_Ndmbzb "
                    + " Inner Join Biz_Ndmb on Biz_Ndmbzb.Ndmb_ID = Biz_Ndmb.ID "
                    + " Left Join Biz_Khflb on Biz_Ndmbzb.KHZB_ID = Biz_Khflb.ID "
                    + " Left Join T_ACL_OU Man on BIZ_NDMB.ManDep_ID = Man.ID "
                    + " Left Join T_ACL_OU Sub on BIZ_NDMB.SubDep_ID = Sub.ID "
                    + " where Biz_Ndmb.Year = '" + Year + "'";
            else
                vsSql = "SELECT BIZ_NDMBZB.ID,BIZ_NDMB.CODE,BIZ_NDMB.ManDep_ID,Man.Name as ManDep_Name, "
                        + " BIZ_NDMB.SubDep_ID,Sub.Name as SubDep_Name,BIZ_NDMBZB.Type,KHZB_ID,BIZ_KHFLB.NAME AS KHZB_Name "
                        + " From Biz_Ndmbzb "
                        + " Inner Join Biz_Ndmb on Biz_Ndmbzb.Ndmb_ID = Biz_Ndmb.ID "
                        + " Left Join Biz_Khflb on Biz_Ndmbzb.KHZB_ID = Biz_Khflb.ID "
                        + " Left Join T_ACL_OU Man on BIZ_NDMB.ManDep_ID = Man.ID "
                        + " Left Join T_ACL_OU Sub on BIZ_NDMB.SubDep_ID = Sub.ID ";
            DataTable dt = iydmb_0.SqlTable(vsSql);

            return dt;
        }
        
        public bool SaveExcelData(List<YdmbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YdmbInfo detail in list)
                    {
                        iydmb_0.Insert(detail, transaction);
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
