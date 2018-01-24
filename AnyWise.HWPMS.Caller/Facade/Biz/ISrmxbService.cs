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
    public interface ISrmxbService : IBaseService<SrmxbInfo>
    {
        
        [OperationContract]
        DataTable GetDataCount(string where);
        [OperationContract]
        DataTable GetSrmxbData(int intPageSize, int intPageCount, int mSizeBackup, string where);
        [OperationContract]
        DataTable GetSrhzSumData(string where);
        [OperationContract]
        bool SaveExcelData(List<SrmxbInfo> list);
    }
}
