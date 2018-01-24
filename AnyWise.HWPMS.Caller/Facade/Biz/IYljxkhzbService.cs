using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface IYljxkhzbService : IBaseService<YljxkhzbInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<YljxkhzbInfo> list);
        [OperationContract]
        int SqlExe_Update(string id);
        [OperationContract]
        int SqlExe_SSI(string ids);
    }
}
