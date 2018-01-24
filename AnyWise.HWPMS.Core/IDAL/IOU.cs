namespace AnyWise.HWPMS.IDAL
{
    using System;
    using System.Collections.Generic;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface IOU : IBaseDAL<OUInfo>
    {
        void AddUser(int userID, int ouID);
        List<OUInfo> GetOUsByRole(int roleID);
        List<OUInfo> GetOUsByUser(int userID);
        void RemoveUser(int userID, int ouID);
    }
}

