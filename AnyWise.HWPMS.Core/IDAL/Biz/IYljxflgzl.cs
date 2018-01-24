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
    /// 医疗绩效分类工作量
    /// </summary>
    public interface IYljxflgzl : IBaseDAL<YljxflgzlInfo>
    {
        bool InsertBatch(List<YljxflgzlInfo> list);
    }
}