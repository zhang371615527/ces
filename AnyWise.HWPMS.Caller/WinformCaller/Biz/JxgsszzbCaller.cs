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
    public class JxgsszzbCaller : BaseLocalService<JxgsszzbInfo>, IJxgsszzbService
    {
        private Jxgsszzb bll = null;

        public JxgsszzbCaller() : base(BLLFactory<Jxgsszzb>.Instance)
        {
            bll = baseBLL as Jxgsszzb;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<JxgsszzbInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

    }
}
