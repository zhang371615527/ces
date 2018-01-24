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
    /// DRGs工作量
    /// </summary>
    public interface IDrgsgzl : IBaseDAL<DrgsgzlInfo>
    {
        bool InsertBatch(List<DrgsgzlInfo> list);
        // 返回CMI折线图数据
        DataTable DRGSAna_CMIAna(string where);

    }
}
