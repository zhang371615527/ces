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
    /// 绩效公式设置
    /// </summary>
	public interface IJxgssz : IBaseDAL<JxgsszInfo>
	{
        bool InsertBatch(List<JxgsszInfo> list);
    }
}