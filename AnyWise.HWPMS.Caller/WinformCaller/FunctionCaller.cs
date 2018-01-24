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
    public class FunctionCaller : BaseLocalService<FunctionInfo>, IFunctionService
    {
        private Function bll = null;

        public FunctionCaller() : base(BLLFactory<Function>.Instance)
        {
            bll = baseBLL as Function;
        }

        ///// <summary>
        ///// 根据名称查找对象(自定义接口使用范例)
        ///// </summary>
        //public List<FunctionInfo> FindByName(string name)
        //{
        //    return bll.FindByName(name);
        //}

        public List<FunctionInfo> GetAllFunction(string systemType)
        {
            return bll.GetAllFunction(systemType);
        }

        public List<FunctionInfo> GetFunctions(string roleIDs, string typeID)
        {
            return bll.GetFunctions(roleIDs, typeID);
        }

        public List<FunctionInfo> GetFunctionsByRole(int roleID)
        {
            return bll.GetFunctionsByRole(roleID);
        }

        public List<FunctionInfo> GetFunctionsByUser(int userID, string typeID)
        {
            return bll.GetFunctionsByUser(userID, typeID);
        }
    }
}
