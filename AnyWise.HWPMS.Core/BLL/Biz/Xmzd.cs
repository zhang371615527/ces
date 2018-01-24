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
    /// 项目字典
    /// </summary>
	public class Xmzd : BaseBLL<XmzdInfo>
    {
        private IXmzd ixmzd_0;

        public Xmzd()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.ixmzd_0 = (IXmzd)base.baseDal;
        }
        public bool SaveExcelData(List<XmzdInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (XmzdInfo detail in list)
                    {
                        ixmzd_0.Insert(detail, transaction);
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
