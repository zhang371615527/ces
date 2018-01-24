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

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 年度目标子表
    /// </summary>
	public class Ndmbzb : BaseBLL<NdmbzbInfo>
    {
        private AnyWise.HWPMS.IDAL.INdmbzb indmbzb_0;
        public Ndmbzb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.indmbzb_0 = base.baseDal as AnyWise.HWPMS.IDAL.INdmbzb;
        }

        public bool SaveExcelData(List<NdmbzbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (NdmbzbInfo detail in list)
                    {
                        indmbzb_0.Insert(detail, transaction);
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
