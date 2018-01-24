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
    public class CbmxbCaller : BaseLocalService<CbmxbInfo>, ICbmxbService
    {
        private Cbmxb bll = null;

        public CbmxbCaller() : base(BLLFactory<Cbmxb>.Instance)
        {
            bll = baseBLL as Cbmxb;
        }

        
        public DataTable GetDataCount(string where)
        {
            return bll.GetDataCount(where);
        }
        public DataTable GetCbmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            return bll.GetCbmxbData(intPageSize, intPageCount, mSizeBackup, where);
        }
        public DataTable GetCbSrhzSumData(string where)
        {
            return bll.GetCbSrhzSumData(where);
        }
        public bool SaveExcelData(List<CbmxbInfo> list)
        {
            return bll.SaveExcelData(list);
        }
    }
}
