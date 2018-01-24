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
    public class YljxkhzbCaller : BaseLocalService<YljxkhzbInfo>, IYljxkhzbService
    {
        private Yljxkhzb bll = null;

        public YljxkhzbCaller() : base(BLLFactory<Yljxkhzb>.Instance)
        {
            bll = baseBLL as Yljxkhzb;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxkhzbInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool SaveExcelData(List<YljxkhzbInfo> list)
        {
            return bll.SaveExcelData(list);
        }

        public int SqlExe_Update(string id)
        {
            return bll.SqlExe_Update(id);
        }

        public int SqlExe_SSI(string ids)
        {
            return bll.SqlExe_SSI (ids);
        }
    }
}
