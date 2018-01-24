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
    public class YljxkhzbzdCaller : BaseLocalService<YljxkhzbzdInfo>, IYljxkhzbzdService
    {
        private Yljxkhzbzd bll = null;

        public YljxkhzbzdCaller() : base(BLLFactory<Yljxkhzbzd>.Instance)
        {
            bll = baseBLL as Yljxkhzbzd;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<YljxkhzbzdInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public bool SaveExcelData(List<YljxkhzbzdInfo> list)
        {
            return bll.SaveExcelData(list);
        }

    }
}
