namespace AnyWise.HWPMS.IDAL
{
    using System;
    using System.Collections.Generic;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface IUser : IBaseDAL<UserInfo>
    {
        byte[] GetPersonImageBytes(UserImageType imagetype, int userId);
        List<SimpleUserInfo> GetSimpleUsers();
        List<SimpleUserInfo> GetSimpleUsers(string userIDs);
        List<SimpleUserInfo> GetSimpleUsersByOU(int ouID);
        List<SimpleUserInfo> GetSimpleUsersByRole(int roleID);
        List<UserInfo> GetUsersByOU(int ouID);
        List<UserInfo> GetUsersByRole(int roleID);
        bool UpdatePersonImageBytes(UserImageType imagetype, int userId, byte[] imageBytes);
        bool UpdateUserLoginData(int id, string ip, string macAddr);
        bool InsertBatch(List<UserInfo> list);
    }
}

