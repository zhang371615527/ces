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
    public interface IUserService : IBaseService<UserInfo>
    {
        [OperationContract]
        List<UserInfo> GetUsersByOU(int ouID);
        [OperationContract]
        List<UserInfo> GetUsersByRole(int roleID);
        [OperationContract]
        bool ModifyPassword(string userName, string userPassword);
        [OperationContract(Name = "ModifyPassword2")]
        bool ModifyPassword(string userName, string userPassword, string systemType, string ip, string macAddr);
        [OperationContract]
        string VerifyUser(string userName, string userPassword, string systemType);
        [OperationContract(Name = "VerifyUser3")]
        string VerifyUser(string userName, string userPassword, string systemType, string ip, string macAddr);
        [OperationContract]
        string VerifyUser2(string userName, string userPassword, string systemType, string ip, string macAddr);
        [OperationContract]
        UserInfo GetUserByName(string userName);
        [OperationContract]
        bool InsertBatch(List<UserInfo> list);
    }
}
