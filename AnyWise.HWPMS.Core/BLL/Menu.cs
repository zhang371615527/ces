namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.IDAL;
    using AnyWise.HWPMS.Entity;

    public class Menu : BaseBLL<MenuInfo>
    {
        private IMenu imenu_0;

        public Menu()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.imenu_0 = base.baseDal as IMenu;
        }

        public List<MenuInfo> GetAllTree(string systemType)
        {
            return this.imenu_0.GetAllMenu(systemType);
        }

        public List<MenuInfo> GetMenuByID(string pid)
        {
            return this.imenu_0.GetMenuByID(pid);
        }

        public List<MenuInfo> GetTopMenu(string systemType)
        {
            return this.imenu_0.GetTopMenu(systemType);
        }

        public List<MenuNodeInfo> GetTree(string systemType)
        {
            return this.imenu_0.GetTree(systemType);
        }

        public List<MenuNodeInfo> GetTreeByID(string mainMenuID)
        {
            return this.imenu_0.GetTreeByID(mainMenuID);
        }

        public List<MenuNodeInfo> GetTreeFunction(string systemType, string Functions)
        {
            return this.imenu_0.GetTreeFunction(systemType, Functions);
        }

        public List<MenuNodeInfo> GetTreeFunctionByID(string mainMenuID, string Functions)
        {
            return this.imenu_0.GetTreeFunctionByID(mainMenuID, Functions);
        }

        public List<MenuInfo> GetTreeMenuFunctionByID(string mainMenuID, string Functions)
        {
            return this.imenu_0.GetTreeMenuFunctionByID(mainMenuID, Functions);
        }
    }
}

