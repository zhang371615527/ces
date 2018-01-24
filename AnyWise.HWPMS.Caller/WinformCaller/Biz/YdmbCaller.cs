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
    public class YdmbCaller : BaseLocalService<YdmbInfo>, IYdmbService
    {
        private Ydmb bll = null;

        public YdmbCaller() : base(BLLFactory<Ydmb>.Instance)
        {
            bll = baseBLL as Ydmb;
        }

        public DataTable GetNdmbDataByYear(string Year)
        {
            return bll.GetNdmbDataByYear(Year);
        }
        public DataTable GetNdmbDataByCond(string where)
        {
            return bll.GetNdmbDataByCond(where);
        }
        public DataTable GetNdmbDataById(string ID)
        {
            return bll.GetNdmbDataById(ID);
        }
        public DataTable GetNdmbDataByIds(string IDs)
        {
            return bll.GetNdmbDataByIds(IDs);
        }
        public bool SaveExcelData(List<YdmbInfo> list)
        {
            return bll.SaveExcelData(list);
        }
    }
}
