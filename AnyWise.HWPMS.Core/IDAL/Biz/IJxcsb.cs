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
    /// 绩效参数表
    /// </summary>
	public interface IJxcsb : IBaseDAL<JxcsbInfo>
	{
        bool InsertBatch(List<JxcsbInfo> list);
    }
}