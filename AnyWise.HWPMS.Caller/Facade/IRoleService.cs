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
    public interface IRoleService : IBaseService<RoleInfo>
    {
        [OperationContract]
        void AddFunction(int functionID, int roleID);
        [OperationContract]
        void AddOU(int ouID, int roleID);
        [OperationContract]
        void AddUser(int userID, int roleID);
        [OperationContract]
        RoleInfo GetRoleByName(string roleName);
        [OperationContract]
        List<RoleInfo> GetRolesByFunction(int functionID);
        [OperationContract]
        List<RoleInfo> GetRolesByOU(int ouID);
        [OperationContract]
        List<RoleInfo> GetRolesByUser(int userID);
        [OperationContract]
        void RemoveFunction(int functionID, int roleID);
        [OperationContract]
        void RemoveOU(int ouID, int roleID);
        [OperationContract]
        void RemoveUser(int userID, int roleID);

    }
}
