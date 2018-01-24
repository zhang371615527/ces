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
    public class YljxkhCaller : BaseLocalService<YljxkhInfo>, IYljxkhService
    {
        private Yljxkh bll = null;

        public YljxkhCaller() : base(BLLFactory<Yljxkh>.Instance)
        {
            bll = baseBLL as Yljxkh;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxkhInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}
        public bool SaveExcelData(List<YljxkhInfo> list)
        {
            return bll.SaveExcelData(list);
        }

        public List<YljxkhInfo> Yljxkh_FWP(int intRecordCount, int intPageSize, int intPageCount, string where)
        {
            return bll.Yljxkh_FWP(intRecordCount, intPageSize, intPageCount, where);
        }

        public int UpdateState(string IDs)
        {
            return bll.UpdateState(IDs);
        }
    }
}
