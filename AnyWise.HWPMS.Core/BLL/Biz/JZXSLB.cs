namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;
    public class JZXSLB : BaseBLL<JZXSLBInfo>
    {
        private IJZXSLB ijzxslb_0;

        public JZXSLB()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.ijzxslb_0 = (IJZXSLB)base.baseDal;
        }
    }
}