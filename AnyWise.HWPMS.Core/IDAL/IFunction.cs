namespace AnyWise.HWPMS.IDAL
{
    using System;
    using System.Collections.Generic;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface IFunction : IBaseDAL<FunctionInfo>
    {
        List<FunctionInfo> GetAllFunction(string systemType);
        List<FunctionNodeInfo> GetFunctionNodes(string roleIDs, string typeID);
        List<FunctionInfo> GetFunctions(string roleIDs, string typeID);
        List<FunctionInfo> GetFunctionsByRole(int roleID);
        List<FunctionNodeInfo> GetTree(string systemType);
        List<FunctionNodeInfo> GetTreeByID(string mainID);
    }
}

