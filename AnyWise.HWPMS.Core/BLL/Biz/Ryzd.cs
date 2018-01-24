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
    /// 人员字典
    /// </summary>
	public class Ryzd : BaseBLL<RyzdInfo>
    {

        private IRyzd iryzd_0;

        public Ryzd()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.iryzd_0 = (IRyzd)base.baseDal;
        }

        public bool SaveExcelData(List<RyzdInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (RyzdInfo detail in list)
                    {
                        iryzd_0.Insert(detail, transaction);
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
