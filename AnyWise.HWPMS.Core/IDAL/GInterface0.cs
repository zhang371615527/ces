namespace AnyWise.HWPMS.IDAL
{
    using System;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;

    public interface GInterface0 : IBaseDAL<InformationStatusInfo>
    {
        bool CheckStatus(string UserID, InformationCategory InfoType, string InfoID, int Status);
        void SetStatus(string UserID, InformationCategory InfoType, string InfoID, int Status);
    }
}

