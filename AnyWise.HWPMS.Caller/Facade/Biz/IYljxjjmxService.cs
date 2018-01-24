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
    public interface IYljxjjmxService : IBaseService<YljxjjmxInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<YljxjjmxInfo> list);
        //医疗绩效奖金明细表
        [OperationContract]
        List<YljxjjmxInfo> Yljxjjmx_FWP(int intRecordCount, int intPageSize, int intPageCount, string where);
        //医疗绩效奖金明细表Calculate
        [OperationContract]
        DataTable Yljxjjmx_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID);
        [OperationContract]
        bool Yljxjjmx_Insert(List<YljxjjmxInfo> list);
        //医疗绩效奖金明细表BonusSumData
        [OperationContract]
        DataTable Yljxjjmx_BDD(string strYear, string strMonth, string strKSZD_ID, string strFPLBID);
    }
}
