using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using System.Data;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface INdmbService : IBaseService<NdmbInfo>
    {
        [OperationContract]
        DataTable GetNdmbData(string where);
        [OperationContract]
        bool SaveExcelData(List<NdmbInfo> list);
    }
}
