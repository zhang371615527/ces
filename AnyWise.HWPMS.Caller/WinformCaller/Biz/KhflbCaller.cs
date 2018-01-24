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
    public class KhflbCaller : BaseLocalService<KhflbInfo>, IKhflbService
    {
        private Khflb bll = null;

        public KhflbCaller() : base(BLLFactory<Khflb>.Instance)
        {
            bll = baseBLL as Khflb;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<KhflbInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public List<KhflbInfo> GetAllTree(string nodeType)
        {
            return bll.GetAllTree(nodeType);
        }

        public List<KhflbInfo> GetKhflbByID(string parentcode)
        {
            return bll.GetKhflbByID(parentcode);
        }

        public bool DeleteByCode(string strCode)
        {
            return bll.DeleteByCode(strCode);
        }

        public bool SaveExcelData(List<KhflbInfo> list)
        {
            return bll.SaveExcelData(list);
        }
    }
}
