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
using AnyWise.Pager.Entity;

namespace AnyWise.HWPMS.WinformCaller
{
	/// <summary>
	/// 基于传统Winform方式，直接访问本地数据库的Facade接口实现类
	/// </summary>
    public class InformationCaller : BaseLocalService<InformationInfo>, IInformationService
    {
        private Information bll = null;

        public InformationCaller() : base(BLLFactory<Information>.Instance)
        {
            bll = baseBLL as Information;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<InformationInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}
        public List<InformationInfo> FindAll4(PagerInfo info, string fieldToSort, bool isDescending)
        {
            List<InformationInfo> list = bll.GetAll(info, fieldToSort, isDescending);
            return list;
        }
    }
}
