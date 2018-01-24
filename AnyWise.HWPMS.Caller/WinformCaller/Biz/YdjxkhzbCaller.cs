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
    public class YdjxkhzbCaller : BaseLocalService<YdjxkhzbInfo>, IYdjxkhzbService
    {
        private Ydjxkhzb bll = null;

        public YdjxkhzbCaller() : base(BLLFactory<Ydjxkhzb>.Instance)
        {
            bll = baseBLL as Ydjxkhzb;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YdjxkhzbInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool SaveScore(string Mid, string Ids)
        {
            return bll.SaveScore(Mid, Ids);
        }

        public bool SaveExcelData(List<YdjxkhzbInfo> list)
        {
            return bll.SaveExcelData(list);
        }

        public DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID, string strCheckKS_ID)
        {
            return bll.GetDataTable(strYear, strResKS_ID, strResKS_ID, strCheckKS_ID);
        }
    }
}
