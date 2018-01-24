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
    /// 月度目标子表
    /// </summary>
	public class Ydmbzb : BaseBLL<YdmbzbInfo>
    {
        private AnyWise.HWPMS.IDAL.IYdmbzb iydmbzb_0;
        public Ydmbzb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.iydmbzb_0 = base.baseDal as AnyWise.HWPMS.IDAL.IYdmbzb;
        }

        public bool SaveExcelData(List<YdmbzbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YdmbzbInfo detail in list)
                    {
                        iydmbzb_0.Insert(detail, transaction);
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
