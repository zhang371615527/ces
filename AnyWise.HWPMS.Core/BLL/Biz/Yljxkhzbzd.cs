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
    /// 医疗绩效二次考核指标字典
    /// </summary>
    public class Yljxkhzbzd : BaseBLL<YljxkhzbzdInfo>
    {
        private IYljxkhzbzd iYljxkhzbzd_0;
        public Yljxkhzbzd()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxkhzbzd_0 = base.baseDal as IYljxkhzbzd;
        }

        public bool SaveExcelData(List<YljxkhzbzdInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YljxkhzbzdInfo detail in list)
                    {
                        iYljxkhzbzd_0.Insert(detail, transaction);
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
