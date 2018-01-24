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
    /// 绩效分配参数表
    /// </summary>
    public interface IYljxfpcsb : IBaseDAL<YljxfpcsbInfo>
    {
        bool InsertBatch(List<YljxfpcsbInfo> list);
    }
}