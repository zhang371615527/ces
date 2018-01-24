using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.Framework.Commons;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface IJZXSZDService : IBaseService<JZXSZDInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<JZXSZDInfo> list);
    }
}
