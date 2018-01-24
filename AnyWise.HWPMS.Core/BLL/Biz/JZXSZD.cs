namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.IDAL;
    using System.Data.Common;
    using System.Collections.Generic;
    using AnyWise.Framework.Commons;

    public class JZXSZD : BaseBLL<JZXSZDInfo>
    {
        private IJZXSZD ijzxszd_0;

        public JZXSZD()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.ijzxszd_0 = (IJZXSZD)base.baseDal;
        }
        public bool SaveExcelData(List<JZXSZDInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (JZXSZDInfo detail in list)
                    {
                        ijzxszd_0.Insert(detail, transaction);
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