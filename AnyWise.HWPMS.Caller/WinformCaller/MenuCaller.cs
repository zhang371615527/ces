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
    public class MenuCaller : BaseLocalService<MenuInfo>, IMenuService
    {
        private Menu bll = null;

        public MenuCaller() : base(BLLFactory<Menu>.Instance)
        {
            bll = baseBLL as Menu;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<MenuInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}
        public List<MenuInfo> GetAllTree(string systemType)
        {
            return bll.GetAllTree(systemType);
        }

        public List<MenuInfo> GetTopMenu(string systemType)
        {
            return bll.GetTopMenu(systemType);
        }

        public List<MenuNodeInfo> GetTreeByID(string mainMenuID)
        {
            return bll.GetTreeByID(mainMenuID);
        }

        public List<MenuNodeInfo> GetTreeFunction(string systemType, string Functions)
        {
            return bll.GetTreeFunction(systemType, Functions);
        }

        public List<MenuInfo> GetTreeMenuFunctionByID(string mainMenuID, string Functions)
        {
            return bll.GetTreeMenuFunctionByID(mainMenuID, Functions);
        }
    }
}
