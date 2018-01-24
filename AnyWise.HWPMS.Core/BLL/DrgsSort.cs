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
    /// Drgs诊疗分组
    /// </summary>
    public class DrgsSort : BaseBLL<DrgsSortInfo>
    {
        private IDrgsSort idrgssort_0;

        public DrgsSort()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.idrgssort_0 = base.baseDal as IDrgsSort;
        }
        public bool SaveExcelData(List<DrgsSortInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (DrgsSortInfo detail in list)
                    {
                        idrgssort_0.Insert(detail, transaction);
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
