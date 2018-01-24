﻿using System;
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
    public interface IYljxkhzbzdService : IBaseService<YljxkhzbzdInfo>
    {
        [OperationContract]
        bool SaveExcelData(List<YljxkhzbzdInfo> list);

    }
}
