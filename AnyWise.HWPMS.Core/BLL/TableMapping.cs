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
    /// 表映射关系表
    /// </summary>
    public class TableMapping : BaseBLL<TableMappingInfo>
    {
        private AnyWise.HWPMS.IDAL.ITableMapping itablemapping_0;

        public TableMapping()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.itablemapping_0 = (AnyWise.HWPMS.IDAL.ITableMapping)base.baseDal;
        }

        public bool SaveExcelData(List<TableMappingInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (TableMappingInfo detail in list)
                    {
                        itablemapping_0.Insert(detail, transaction);
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
