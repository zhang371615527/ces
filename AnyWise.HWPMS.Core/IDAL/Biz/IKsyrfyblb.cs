using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using AnyWise.Pager.Entity;
using AnyWise.Framework.ControlUtil;
using AnyWise.HWPMS.Entity;

namespace AnyWise.HWPMS.IDAL
{
    /// <summary>
    /// 科室用人费用比率
    /// </summary>
	public interface IKsyrfyblb : IBaseDAL<KsyrfyblbInfo>
	{
        bool InsertBatch(List<KsyrfyblbInfo> list);
    }
}