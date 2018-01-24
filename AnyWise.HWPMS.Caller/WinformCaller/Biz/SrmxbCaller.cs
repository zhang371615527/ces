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
    public class SrmxbCaller : BaseLocalService<SrmxbInfo>, ISrmxbService
    {
        private Srmxb bll = null;

        public SrmxbCaller() : base(BLLFactory<Srmxb>.Instance)
        {
            bll = baseBLL as Srmxb;
        }


        public DataTable GetDataCount(string where)
        {
            return bll.GetDataCount(where);
        }
        public DataTable GetSrmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where)
        {
            return bll.GetSrmxbData(intPageSize, intPageCount, mSizeBackup, where);
        }
        public DataTable GetSrhzSumData(string where)
        {
            return bll.GetSrhzSumData(where);
        }
        public bool SaveExcelData(List<SrmxbInfo> list)
        {
            return bll.SaveExcelData(list);
        }
    }
}
