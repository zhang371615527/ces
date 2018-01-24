namespace AnyWise.HWPMS.IDAL
{
    using System;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface ILoginLog : IBaseDAL<LoginLogInfo>
    {
        LoginLogInfo GetLastLoginInfo(string userId);
    }
}

