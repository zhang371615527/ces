namespace AnyWise.HWPMS.IDAL
{
    using System;
    using System.Data;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface IInformation : IBaseDAL<InformationInfo>
    {
        DataTable GetMyInformation(int userId, InformationCategory infoType);
    }
}

