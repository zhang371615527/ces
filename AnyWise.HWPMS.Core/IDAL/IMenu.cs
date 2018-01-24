namespace AnyWise.HWPMS.IDAL
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface IMenu : IBaseDAL<MenuInfo>
    {
        List<MenuInfo> GetAllMenu(string systemType);
        List<MenuInfo> GetMenuByID(string pid);
        List<MenuInfo> GetTopMenu(string systemType);
        List<MenuNodeInfo> GetTree(string systemType);
        List<MenuNodeInfo> GetTreeFunction(string systemType, string Functions);
        List<MenuNodeInfo> GetTreeByID(string id);
        List<MenuNodeInfo> GetTreeFunctionByID(string mainMenuID, string Functions);
        List<MenuInfo> GetTreeMenuFunctionByID(string mainMenuID, string Functions);
    }
}

