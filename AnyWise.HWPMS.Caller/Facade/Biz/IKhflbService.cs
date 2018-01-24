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
    public interface IKhflbService : IBaseService<KhflbInfo>
    {
        [OperationContract]
        List<KhflbInfo> GetAllTree(string nodeType);

        [OperationContract]
        List<KhflbInfo> GetKhflbByID(string parentcode);

        [OperationContract]
        bool DeleteByCode(string strCode);

        [OperationContract]
        bool SaveExcelData(List<KhflbInfo> list);
    }
}
