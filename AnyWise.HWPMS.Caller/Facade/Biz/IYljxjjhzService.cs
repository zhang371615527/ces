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
    public interface IYljxjjhzService : IBaseService<YljxjjhzInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<YljxjjhzInfo> list);
        //医疗绩效奖金汇总表
        [OperationContract]
        List<YljxjjhzInfo> Yljxjjhz_FWP(int intPageSize, int intPageCount, int mSizeBackup, string where);
        //医疗绩效奖金汇总表Calculate
        [OperationContract]
        DataTable Yljxjjhz_Cal(string strYear, string strMonth, string strKSID, string strZXZD_ID);

        [OperationContract]
        bool Yljxjjhz_Insert(List<YljxjjhzInfo> listjj);
        //医疗绩效奖金汇总表BonusSumData
        [OperationContract]
        DataTable Yljxjjhz_BSD(string strYear, string strMonth, string strKSZD_ID);
    }
}
