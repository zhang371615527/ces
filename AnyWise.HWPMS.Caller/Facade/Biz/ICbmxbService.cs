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
    public interface ICbmxbService : IBaseService<CbmxbInfo>
    {
        [OperationContract]
        DataTable GetDataCount(string where);
        [OperationContract]
        DataTable GetCbmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where);
        [OperationContract]
        DataTable GetCbSrhzSumData(string where);
        [OperationContract]
        bool SaveExcelData(List<CbmxbInfo> list);
    }
}
