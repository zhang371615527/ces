    using System;
    using System.Reflection;
    using AnyWise.Framework.ControlUtil;
    using AnyWise.HWPMS.Entity;
namespace AnyWise.HWPMS.BLL
{

    public class DictType : BaseBLL<DictTypeInfo>
    {
        public DictType()
        {
            base.Init(base.GetType().FullName, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}

