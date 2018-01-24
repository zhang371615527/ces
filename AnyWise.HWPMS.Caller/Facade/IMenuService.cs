using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface IMenuService : IBaseService<MenuInfo>
    {
        [OperationContract]
        List<MenuInfo> GetAllTree(string systemType);
        [OperationContract]
        List<MenuInfo> GetTopMenu(string systemType);
        [OperationContract]
        List<MenuNodeInfo> GetTreeByID(string mainMenuID);
        [OperationContract]
        List<MenuNodeInfo> GetTreeFunction(string systemType, string Functions);
        [OperationContract]
        List<MenuInfo> GetTreeMenuFunctionByID(string mainMenuID, string Functions);
    }
}
