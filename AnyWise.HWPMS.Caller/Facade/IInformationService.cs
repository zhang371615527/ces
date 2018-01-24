using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AnyWise.Framework.ControlUtil.Facade;
using AnyWise.HWPMS.Entity;
using AnyWise.Pager.Entity;

namespace AnyWise.HWPMS.Facade
{
    [ServiceContract]
    public interface IInformationService : IBaseService<InformationInfo>
    {
        [OperationContract]
        List<InformationInfo> FindAll4(PagerInfo info, string fieldToSort, bool isDescending);
    }
}
