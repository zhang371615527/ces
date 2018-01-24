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
    public interface IICDService : IBaseService<ICDInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<ICDInfo> list);
    }
}
