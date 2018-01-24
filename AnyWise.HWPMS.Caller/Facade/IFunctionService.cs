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
    public interface IFunctionService : IBaseService<FunctionInfo>
    {
        [OperationContract]
        List<FunctionInfo> GetAllFunction(string systemType);
        [OperationContract]
        List<FunctionInfo> GetFunctions(string roleIDs, string typeID);
        [OperationContract]
        List<FunctionInfo> GetFunctionsByRole(int roleID);
        [OperationContract]
        List<FunctionInfo> GetFunctionsByUser(int userID, string typeID);
    }
}
