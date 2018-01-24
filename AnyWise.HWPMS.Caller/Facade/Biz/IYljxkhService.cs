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
    public interface IYljxkhService : IBaseService<YljxkhInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<YljxkhInfo> list);
        //医疗绩效考核
        [OperationContract]
        List<YljxkhInfo> Yljxkh_FWP(int intRecordCount, int intPageSize, int intPageCount, string where);
        //更改绩效考核状态
        [OperationContract]
        int UpdateState(string IDs);
    }
}
