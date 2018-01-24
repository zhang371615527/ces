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
    public interface IYdmbService : IBaseService<YdmbInfo>
    {
        
        [OperationContract]
        DataTable GetNdmbDataByYear(string Year);

        [OperationContract]
        DataTable GetNdmbDataByCond(string where);

        [OperationContract]
        DataTable GetNdmbDataById(string ID);

        [OperationContract]
        DataTable GetNdmbDataByIds(string IDs);

        [OperationContract]
        bool SaveExcelData(List<YdmbInfo> list);

    }
}
