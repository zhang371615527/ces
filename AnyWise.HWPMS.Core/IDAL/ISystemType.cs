namespace AnyWise.HWPMS.IDAL
{
    using System;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface ISystemType : IBaseDAL<SystemTypeInfo>
    {
        SystemTypeInfo imethod_1(string oid);
        bool VerifySystem(string serialNumber, string typeID, int authorizeAmount);
    }
}

