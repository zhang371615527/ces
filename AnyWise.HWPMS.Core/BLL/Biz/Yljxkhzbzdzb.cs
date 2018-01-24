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
    /// 医疗绩效二次考核指标字典子表
    /// </summary>
    public class Yljxkhzbzdzb : BaseBLL<YljxkhzbzdzbInfo>
    {
        private IYljxkhzbzdzb iYljxkhzbzdzb_0;
        public Yljxkhzbzdzb()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            this.iYljxkhzbzdzb_0 = base.baseDal as IYljxkhzbzdzb;
        }
        public bool SaveExcelData(List<YljxkhzbzdzbInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (YljxkhzbzdzbInfo detail in list)
                    {
                        iYljxkhzbzdzb_0.Insert(detail, transaction);
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
