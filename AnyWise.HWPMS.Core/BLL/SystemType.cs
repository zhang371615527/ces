namespace AnyWise.HWPMS.BLL
{
    using System;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
    using AnyWise.HWPMS.IDAL;

    public class SystemType : BaseBLL<SystemTypeInfo>
    {
        private ISystemType isystemType_0;

        public SystemType()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
            this.isystemType_0 = (ISystemType) base.baseDal;
        }

        public SystemTypeInfo method_0(string oid)
        {
            return this.isystemType_0.imethod_1(oid);
        }

        public bool VerifySystem(string serialNumber, string typeID, int authorizeAmount)
        {
            return this.isystemType_0.VerifySystem(serialNumber, typeID, authorizeAmount);
        }
    }
}

