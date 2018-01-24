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
    public class Hljxjjgzl : BaseBLL<HljxjjgzlInfo>
    {
        private IHljxjjgzl iHljxjjgzl_0;
        public Hljxjjgzl() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iHljxjjgzl_0 = base.baseDal as IHljxjjgzl;
        }
        public bool SaveExcelData(List<HljxjjgzlInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (HljxjjgzlInfo detail in list)
                    {
                        iHljxjjgzl_0.Insert(detail, transaction);
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
