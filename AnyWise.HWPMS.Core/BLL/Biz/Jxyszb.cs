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
using System.Reflection;

namespace AnyWise.HWPMS.BLL
{
    /// <summary>
    /// 绩效预算
    /// </summary>
	public class Jxyszb : BaseBLL<JxyszbInfo>
    {
        private AnyWise.HWPMS.IDAL.IJxyszb ijxyszb_0;
        public Jxyszb()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.ijxyszb_0 = base.baseDal as AnyWise.HWPMS.IDAL.IJxyszb;
        }

        public bool SaveExcelData(List<JxyszbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (JxyszbInfo detail in list)
                    {
                        ijxyszb_0.Insert(detail, transaction);
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
