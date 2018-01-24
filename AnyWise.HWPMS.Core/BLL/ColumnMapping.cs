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
    /// 列映射关系表
    /// </summary>
	public class ColumnMapping : BaseBLL<ColumnMappingInfo>
    {
        private AnyWise.HWPMS.IDAL.IColumnMapping icolumnmapping_0;
        public ColumnMapping()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.icolumnmapping_0 = base.baseDal as AnyWise.HWPMS.IDAL.IColumnMapping;
        }
        public bool SaveExcelData(List<ColumnMappingInfo> list)
        {
            bool result = false;
            DbTransaction transaction = base.CreateTransaction();
            if (transaction != null)
            {
                try
                {
                    foreach (ColumnMappingInfo detail in list)
                    {
                        icolumnmapping_0.Insert(detail, transaction);
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
