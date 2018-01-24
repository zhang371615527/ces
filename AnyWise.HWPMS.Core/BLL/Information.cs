namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Data;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class Information : BaseBLL<InformationInfo>
    {
        public Information()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
        }

        public DataTable GetMyInformation(int userId, InformationCategory infoType)
        {
            IInformation baseDal = base.baseDal as IInformation;
            return baseDal.GetMyInformation(userId, InformationCategory.const_0);
        }
    }
}

