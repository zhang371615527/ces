using System;
using System.Data;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

using AnyWise.Framework.Commons;
using AnyWise.Framework.ControlUtil;
using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.HWPMS.BLL;
using AnyWise.HWPMS.Facade;

namespace AnyWise.HWPMS.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class TableMappingCaller : BaseLocalService<TableMappingInfo>, ITableMappingService
    {
        private TableMapping bll = null;

        public TableMappingCaller() : base(BLLFactory<TableMapping>.Instance)
        {
            bll = baseBLL as TableMapping;
        }

        public bool SaveExcelData(List<TableMappingInfo> list)
        {
            return bll.SaveExcelData(list);
        }

    }
}
