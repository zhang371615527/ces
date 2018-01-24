using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 医疗绩效二次考核子表
    /// </summary>
	public class Yljxkhzb : BaseBLL<YljxkhzbInfo>
    {
        private IYljxkhzb iYljxkhzb_0;
        public Yljxkhzb() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxkhzb_0 = base.baseDal as IYljxkhzb;
        }

        public int SqlExecute(string sql, DbTransaction trans)
        {
            return baseDal.SqlExecute(sql, trans);
        }
        public int SqlExecute(string sql)
        {
            return baseDal.SqlExecute(sql);
        }
        public bool SaveExcelData(List<YljxkhzbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YljxkhzbInfo detail in list)
                    {
                        iYljxkhzb_0.Insert(detail, transaction);
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
        //更改权重值
        public int SqlExe_Update(string id)
        {
            string vsUpdateSql = "update biz_yljxkh set Weight = (select sum(Point) from biz_yljxkhzb where JXKH_ID =biz_yljxkh.ID)"
                    + " where ID = (select JXKH_ID from biz_yljxkhzb where ID = '" + id + "')";
            return baseDal.SqlExecute(vsUpdateSql);
        }
        //更改权重值与点值
        public int SqlExe_SSI(string ids)
        {
            string vsID = "";
            foreach (string str in ids.Split(new char[] { ';' }))
            {
                if (!string.IsNullOrEmpty(str))
                {
                    string[] sArray = str.Split(new char[] { ',' });
                    baseDal.SqlExecute("Update Biz_Yljxkhzb set Point = " + Convert.ToDecimal(sArray[1]) + " where ID = '" + sArray[0] + "'");
                    vsID = sArray[0];
                }
            }
            string vsUpdateSql = "update biz_yljxkh set Weight = (select sum(Point) from biz_yljxkhzb where JXKH_ID =biz_yljxkh.ID)"
            + " where ID = (select JXKH_ID from biz_yljxkhzb where ID = '" + vsID + "')";
            return baseDal.SqlExecute(vsUpdateSql);
        }
    }
}
