namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class InformationStatus : BaseBLL<InformationStatusInfo>
    {
        public InformationStatus()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
        }

        public bool CheckStatus(string UserID, InformationCategory InfoType, string InfoID, int Status)
        {
            GInterface0 baseDal = base.baseDal as GInterface0;
            return baseDal.CheckStatus(UserID, InfoType, InfoID, Status);
        }

        public void SetStatus(string UserID, InformationCategory InfoType, string InfoID, int Status)
        {
            (base.baseDal as GInterface0).SetStatus(UserID, InfoType, InfoID, Status);
        }
    }
}

