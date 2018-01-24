using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using System.Dynamic;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface IDrgsgzlService : IBaseService<DrgsgzlInfo>
    {
        [OperationContract]
        bool InsertBatch(List<DrgsgzlInfo> list);
        // 返回CMI折线图数据
        [OperationContract]
        DataTable DRGSAna_CMIAna(string where);

        // 收入折线图数据
        [OperationContract]
        string DRGSAna_GetxAxis(string Year);

        [OperationContract]
        string DRGSAna_GetIncome(string Year);

        //DRGs绩效指标查询
        [OperationContract]
        List<ExpandoObject> DRGSAna_DRGsDetail(string BeginPeriod, string EndPeriod);
    }
}
