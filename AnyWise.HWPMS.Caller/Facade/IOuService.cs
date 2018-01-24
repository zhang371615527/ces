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
    public interface IOuService : IBaseService<OUInfo>
    {
        [OperationContract]
        void AddUser(int userID, int ouID);
        [OperationContract]
        void RemoveUser(int userID, int ouID);
        [OperationContract]
        List<OUInfo> GetOUsByRole(int roleID);
        [OperationContract]
        List<OUInfo> GetOUsByUser(int userID);
        [OperationContract]
        OUInfo GetTopGroup();
        [OperationContract]
        List<OUInfo> GetAllCompany();
        [OperationContract]
        List<OUInfo> GetGroupCompany();
        [OperationContract]
        void DeleteByFlag(string IDs, string flag);
        [OperationContract]
        void Truncate(string flag);
        [OperationContract]
        void SaveGZLData(YljxflgzlInfo info);
        [OperationContract]
        void GZLZH(string IDs);
    }
}
