using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface IYdjxkhzbService : IBaseService<YdjxkhzbInfo>
    {
        [OperationContract]
        bool SaveScore(string Mid, string Ids);
        [OperationContract]
        bool SaveExcelData(List<YdjxkhzbInfo> list);
        [OperationContract]
        DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID, string strCheckKS_ID);
    }
}
