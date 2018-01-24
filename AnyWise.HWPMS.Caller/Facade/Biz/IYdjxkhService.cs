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
    public interface IYdjxkhService : IBaseService<YdjxkhInfo>
    {
        [OperationContract]
        bool InsertMainAndSub(string strYear, string strMonth, string strCreator);
        [OperationContract]
        bool UpdateStateByID(string ID, string State, string strEditor);
        [OperationContract]
        DataTable ExaSumExport(string strYear, string strMonth, string strResKS_ID);
        [OperationContract]
        DataTable GetDataTable(string strYear, string strMonth, string strResKS_ID);
        [OperationContract]
        DataTable GetDataTableByCheckKS(string strYear, string strMonth, string strCheckKS_ID);
    }
}
